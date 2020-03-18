using Neosmartpen.Net;
using Neosmartpen.Net.Bluetooth;
using Neosmartpen.Net.Metadata;
using Neosmartpen.Net.Metadata.Exceptions;
using Neosmartpen.Net.Metadata.Model;
using Neosmartpen.Net.Protocol.v1;
using Neosmartpen.Net.Protocol.v2;
using Neosmartpen.Net.Support;
using Neosmartpen.Net.Support.Encryption;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PenDemo
{
    public delegate void delPassParticipantID(String ID);
    public delegate void delPassSession(Session session);

    public delegate void delSelectParticipant(String ParticipantID, int pageNumber);
    public delegate void delDeletePage(String ParticipantID, int pageNumber);
    public delegate void delDeleteParticipant(String ParticipantID);
    public delegate void delRenameParticipant(String OldParticipantID, String NewParticipantID);

    public partial class MainForm : Form, PenCommV1Callbacks, PenCommV2Callbacks
    {
        public PressureFilter mFilter;

        public static string DefaultPassword = "0000";

        private Bitmap mBitmap;

        private Stroke mStroke;

        private int mWidth, mHeight;

        private object mDrawLock = new object();

        private PasswordInputForm mPwdForm;

        private ProgressForm mPrgForm;

        // Adapter for Bluetooth communication control
        private BluetoothAdapter mBtAdt;

        // Communication with F110
        private PenCommV1 mPenCommV1;

        // Communication with devices other than F110
        private PenCommV2 mPenCommV2;

        private IMetadataManager mMetadataManager;

        private int maxForce;

        private Session session { get; set; }

        public delegate void RequestDele();

        public MainForm()
        {
            InitializeComponent();
            mBtAdt = new BluetoothAdapter();

            // Create MetadataManager
            mMetadataManager = new GenericMetadataManager(new NProjParser());

            mPenCommV1 = new PenCommV1( this );
            mPenCommV2 = new PenCommV2( this );

            // Bind MetadataManager to PenComm.
            mPenCommV1.MetadataManager = mMetadataManager;
            mPenCommV2.MetadataManager = mMetadataManager;

            mWidth = pictureBox1.Width;
            mHeight = pictureBox1.Height;

            mBitmap = new Bitmap( pictureBox1.Width, pictureBox1.Height );

            mPwdForm = new PasswordInputForm( OnInputPassword );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadMetadata();
        }

        private void LoadMetadata()
        {
            try
            {
                // Load the Metadata file.
                mMetadataManager.Load(Application.StartupPath + "\\Resources\\shapes1.nproj");
            }
            catch (ParseException)
            {
                // todo : Handling of parsing errors
            }
            catch (FileNotFoundException)
            {
            }
            catch
            {
            }

            try
            {
                // Load the Metadata file.
                mMetadataManager.Load(Application.StartupPath + "\\Resources\\note_603.nproj");
            }
            catch
            {
            }
        }

        private void OnInputPassword( string password )
        {
            Request( 
                delegate { 
                    mPenCommV1.ReqInputPassword( password ); 
                }, delegate {
                    mPenCommV2.ReqInputPassword( password );
                } );
        }

        private void InitImage()
        {
            Graphics g = Graphics.FromImage( mBitmap );
            g.Clear( Color.Transparent );
            g.Dispose();
            pictureBox1.Invalidate();
        }

        private void btnSearch_Click( object sender, EventArgs e )
        {
            btnSearch.Enabled = false;

            Thread thread = new Thread( unused =>
            {
                PenDevice[] devices = mBtAdt.FindAllDevices();

                this.BeginInvoke( new MethodInvoker( delegate()
                {
                    lbDevices.Items.Clear();

                    if ( devices == null || devices.Length <= 0 )
                    {
                        MessageBox.Show( "device does not exist" );
                    }
                    else
                    {
                        lbDevices.Items.AddRange( devices );
                    }

                    btnSearch.Enabled = true;
                } ) );
            } );

            thread.IsBackground = true;
            thread.Start();
        }

        private void Request( RequestDele onRequestToV1, RequestDele onRequestToV2, RequestDele onFailure = null, RequestDele onAfter = null )
        {
            if ( !mBtAdt.Connected )
            {
                MessageBox.Show( "Device is not connected." );

                if ( onFailure != null )
                {
                    onFailure();
                }
            }
            else if ( mBtAdt.DeviceClass == mPenCommV1.DeviceClass )
            {
                onRequestToV1();

                if ( onAfter != null )
                {
                    onAfter();
                }
            }
            else if ( mBtAdt.DeviceClass == mPenCommV2.DeviceClass )
            {
                onRequestToV2();

                if ( onAfter != null )
                {
                    onAfter();
                }
            }
        }

        private void btnConnect_Click( object sender, EventArgs e )
        {
            if (btnConnect.Text == "Connect")
            {
                if (txtMacAddress.Text == "")
                {
                    MessageBox.Show("Select Mac Address of Pen!!");
                    return;
                }

                btnConnect.Enabled = false;
                Thread thread = new Thread(unused =>
               {
                // Binds a socket created by connecting with pen through Bluetooth interface according to Device Class
                bool result = mBtAdt.Connect(txtMacAddress.Text, delegate (uint deviceClass)
                {
                    // Binding when Device Class is F110
                    if (deviceClass == mPenCommV1.DeviceClass)
                       {
                           mBtAdt.Bind(mPenCommV1);
                       }
                    // Binding if Device Class is not F110
                    else if (deviceClass == mPenCommV2.DeviceClass)
                       {
                           mBtAdt.Bind(mPenCommV2);
                       }
                   });
                   if (!result)
                   {
                       MessageBox.Show("Fail to connect");

                       this.BeginInvoke(new MethodInvoker(delegate ()
                       {
                           btnConnect.Enabled = true;
                       }));
                   }
               });
                thread.IsBackground = true;
                thread.Start();
                thread.Join();
                groupBoxExport.Enabled = true;
            }
            else
            {
                if (!mBtAdt.Disconnect())
                {
                    btnConnect.Text = "Connect";
                    btnConnect.Enabled = true;
                }
                groupBoxExport.Enabled = false;
            }
        }

        private void ProcessDot(Dot dot)
        {
            if (session != null)
            {
                dot.Force = mFilter.Filter(dot.Force);
                if (dot.DotType == DotTypes.PEN_DOWN)
                {
                    mStroke = new Stroke(dot.Section, dot.Owner, dot.Note, dot.Page);
                    mStroke.Add(dot);
                }
                else if (dot.DotType == DotTypes.PEN_MOVE)
                {
                    mStroke.Add(dot);
                }
                else if (dot.DotType == DotTypes.PEN_UP)
                {
                    mStroke.Add(dot);
                    ProcessStroke(mStroke);
                    DrawStroke(mStroke);
                    mFilter.Reset();
                }
            }
        }

        private void ProcessStroke(Stroke stroke)
        {   
            Page page = new Page();
            page.Number = stroke.Page;
            page.Book = stroke.Note;
            page.Owner = stroke.Owner;
            page.Section = stroke.Section;
            //Check if this is the first page this participant writes on

            if (session.CurrentPage == null)
            {
                session.NewPage(page);
                //labelPageNumberInput.Text = "" + page.Number;
            }
            if (session.CurrentPage.Number != page.Number)
            {
                if (session.GetPage(page.Number) != null)
                {
                    session.ChangePage(session.GetPageIndex(page.Number));
                }
                else
                {
                    session.NewPage(page);
                }
                //labelPageNumberInput.Text = "" + page.Number;
                session.AddStrokeToParticipantPage(stroke);
                InitImage();
                DrawSession();
            }
            else
            {
                session.AddStrokeToParticipantPage(stroke);
            }
        }

        private void DrawStroke( Stroke stroke )
        {
            this.Invoke( new MethodInvoker( delegate()
            {
                lock ( mDrawLock )
                {
                    //603 Ring Note Height  5.52  5.41 	63.46 	88.88 
                    int dx = (int)( ( 5.52 * mWidth ) / 63.46 );
                    int dy = (int)( ( 5.41 * mHeight ) / 88.88 );

                    Renderer.draw( mBitmap, stroke, (float)( mWidth / 63.46f ), (float)( mHeight / 88.88f ), -dx, -dy, 1, Color.FromArgb( 200, Color.Blue ) );
                    pictureBox1.Image = mBitmap;
                }
            } ) );
        }

        private void DrawSession()
        {
            if (session.CurrentPage != null)
            {
                foreach (Stroke stroke in session.CurrentPage.Strokes)
                {
                    DrawStroke(stroke);
                }
            }
        }

        private void lbDevices_SelectedIndexChanged( object sender, EventArgs e )
        {
            ListBox lbEvent = sender as ListBox;
            PenDevice dev = lbEvent.SelectedItem as PenDevice;
            if( dev != null )
                txtMacAddress.Text = dev.Address;
        }

        private void lbHistory_SelectedIndexChanged( object sender, EventArgs e )
        {
            ListBox lbEvent = sender as ListBox;
            string dev = lbEvent.SelectedItem as string;
            txtMacAddress.Text = dev;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                InitImage();
            }) );
        }
        private void buttonNewSession_Click(object sender, EventArgs e)
        {
            ToggleSessionButtons();
            if (session == null)
            {
                buttonNewSession.Text = "Stop Session";
                NewSessionForm sessForm = new NewSessionForm(new delPassSession(acceptNewSessionFormInput), maxForce);
                sessForm.Show();
            }
            else {
                session.SaveSessionToFile();
                session = null;
                buttonNewSession.Text = "New Session";
                labelPageNumberInput.Text = "";
                labelParticipantIDInput.Text = "";
            }
        }

        private void ToggleSessionButtons() {
            bool toggle = buttonNextParticipant.Enabled;
            buttonNextParticipant.Enabled = !toggle;
            buttonpLastParticipant.Enabled = !toggle;
            buttonExport.Enabled = !toggle;
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            buttonExport.Text = "Save ....";
            ToggleSessionButtons();
            session.SaveSessionToFile();
            ToggleSessionButtons();
            buttonExport.Text = "Save";
        }

        private void buttonNextParticipant_Click(object sender, EventArgs e) {
            session.SaveSessionToFile();
            ParticipantCreateForm pCForm = new ParticipantCreateForm(new delPassParticipantID(acceptNewParticipantInput));
            pCForm.Show();
        }

        public void acceptNewParticipantInput(String participantId)
        {
            bool hasWorked = session.NewParticipant(participantId);
            if (hasWorked)
            {
                labelParticipantIDInput.Text = participantId;
                InitImage();
                DrawSession();
            }
            else {
                MessageBox.Show("This ID is already in use, choose another name or delete the old one");
            }
        }

        /// <summary>
        /// Delegate Function that receives the id of the participant that needs to be deleted
        /// </summary>
        /// <param name="participantID"></param>
        public void acceptParticipantDeleteRequest(String participantID)
        {
            session.DeleteParticipant(participantID);
        }

        /// <summary>
        /// Delegate Function that receives the participantId and Page number that should be deleted
        /// </summary>
        /// <param name="participantID"></param>
        /// <param name="pageNumber"></param>
        public void acceptPageDeleteRequest(String participantID, int pageNumber)
        {
            session.DeletePage(participantID, pageNumber);
        }

        /// <summary>
        /// Delegate Function receives a new Session from the NewSessionForm
        /// </summary>
        /// <param name="session"></param>
        public void acceptNewSessionFormInput(Session session)
        {
            this.session = session;
            labelParticipantIDInput.Text =  session.CurrentParticipantID;
            buttonNextParticipant.Enabled = true;
            buttonExport.Enabled = true;
        }
        
        public void acceptParticipantChangedInput(String ParticipantID, int PageNum)
        {
            session.ChangeParticipant(ParticipantID);
            session.ChangePage(session.GetPageIndex(PageNum));
            labelParticipantIDInput.Text = session.CurrentParticipantID;
            labelPageNumberInput.Text = "" + session.CurrentPage.Number;
            InitImage();
            DrawSession();
        }

        public void acceptParticipantRenameRequest(String oldParticipantID, String newParticipantID)
        {
            session.RenameParticipant(oldParticipantID, newParticipantID);
        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( mBtAdt != null )
            {
                if ( mBtAdt.Connected )
                {
                    mBtAdt.Disconnect();
                }
            }
        }

        #region PenCommV1Callbacks
        void PenCommV1Callbacks.onConnected( IPenComm sender, int maxForce, string swVersion )
        {
            this.maxForce = maxForce;
            Console.WriteLine("Max Force: " + maxForce);
            mFilter = new PressureFilter( maxForce );

            this.BeginInvoke( new MethodInvoker( delegate()
            {
                btnConnect.Text = "Disconnect";
                btnConnect.Enabled = true;
                tbPenInfo.Text = String.Format( "Firmware Version : {0}", swVersion );
                ToggleOption( true );
            } ) );
        }

        void PenCommV1Callbacks.onDisconnected( IPenComm sender )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lbOfflineData.Items.Clear();
                btnConnect.Text = "Connect";
                tbPenInfo.Text = "";
                groupBox8.Enabled = true;
                ToggleOption( false );
            } ) );

            CloseProgress();
        }

        void PenCommV1Callbacks.onPenPasswordRequest( IPenComm sender, int retryCount, int resetCount )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                mPwdForm.ShowDialog();
            } ) );
        }

        void PenCommV1Callbacks.onPenAuthenticated( IPenComm sender )
        {
            mPenCommV1.ReqAddUsingNote();
            mPenCommV1.ReqOfflineDataList();
            mPenCommV1.ReqPenStatus();

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                groupBox8.Enabled = false;
            }));
        }

        void PenCommV1Callbacks.onReceiveDot( IPenComm sender, Dot dot )
        {
            ProcessDot( dot );
        }

        void PenCommV1Callbacks.onReceivedPenStatus( IPenComm sender, int timeoffset, long timetick
            , int forcemax, int battery, int usedmem
            , int pencolor, bool autopower, bool accel
            , bool hovermode, bool beep, short autoshutdownTime
            , short penSensitivity, string modelName )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                prgPower.Maximum = 100;
                prgPower.Value = battery;

                prgStorage.Maximum = 100;
                prgStorage.Value = usedmem;
            } ) );
        }


        void PenCommV1Callbacks.onPenSensitivitySetUpResponse( IPenComm sender, bool isSuccess )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onPenAutoShutdownTimeSetUpResponse( IPenComm sender, bool isSuccess )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onPenBeepSetUpResponse( IPenComm sender, bool isSuccess )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onPenAutoPowerOnSetUpResponse( IPenComm sender, bool isSuccess )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onPenColorSetUpResponse( IPenComm sender, bool isSuccess )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onPenHoverSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV1.ReqPenStatus();
        }

        void PenCommV1Callbacks.onReceivedFirmwareUpdateResult( IPenComm sender, bool isSuccess )
        {
            CloseProgress();
        }
        
        private object mProgressLock = new object();

        private void DisplayProgress( string title, int total, int amountDone )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lock ( mProgressLock )
                {
                    if ( mPrgForm == null )
                    {
                        mPrgForm = new ProgressForm();
                    }

                    if ( mPrgForm != null )
                    {
                        mPrgForm.SetStatus( title, total, amountDone );
                    }

                    if ( !mPrgForm.Visible )
                    {
                        mPrgForm.ShowDialog();
                    }
                }
            } ) );
        }

        private void CloseProgress()
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lock ( mProgressLock )
                {
                    if ( mPrgForm != null && mPrgForm.Visible )
                    {
                        mPrgForm.Close();
                        mPrgForm.Dispose();
                        mPrgForm = null;
                    }
                }
            } ) );
        }
        
        public const string ProgressTitleOffline = "Download Offline Data";
        public const string ProgressTitleFirmware = "Firmware Update";

        void PenCommV1Callbacks.onReceivedFirmwareUpdateStatus( IPenComm sender, int total, int progress )
        {
            DisplayProgress( ProgressTitleFirmware, total, progress );
        }

        void PenCommV1Callbacks.onOfflineDataList( IPenComm sender, OfflineDataInfo[] notes )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lbOfflineData.Items.Clear();

                foreach ( OfflineDataInfo item in notes )
                {
                    lbOfflineData.Items.Add( item );
                }
            } ) );
        }

        void PenCommV2Callbacks.onReceiveOfflineDataPageList(IPenComm sender, int section, int owner, int note, int[] pageNumbers)
        {
        }

        void PenCommV1Callbacks.onStartOfflineDownload( IPenComm sender )
        {
            DisplayProgress( ProgressTitleOffline, 100, 0 );
        }

        void PenCommV1Callbacks.onUpdateOfflineDownload( IPenComm sender, int total, int progress )
        {
            DisplayProgress( ProgressTitleOffline, total, progress );
        }

        void PenCommV1Callbacks.onFinishedOfflineDownload( IPenComm sender, bool status )
        {
            CloseProgress();
            mPenCommV1.ReqOfflineDataList();
        }

        void PenCommV1Callbacks.onReceiveOfflineStrokes( IPenComm sender, Stroke[] strokes, Symbol[] symbols )
        {
            foreach ( Stroke stroke in strokes )
            {
                ProcessStroke(stroke);
                DrawStroke( stroke );
            }
        }
		void PenCommV1Callbacks.onErrorDetected(IPenComm sender, ErrorType errorType, long timestamp,  Dot dot, string extraData)
		{
		}

        void PenCommV1Callbacks.onSymbolDetected(IPenComm sender, List<Symbol> symbols)
        {
            // TODO : Processing for detected symbols
            // Implement functions corresponding to predefined Actions.
            // For example, if Symbol's Action is email, it sends an email.
        }
        #endregion

        #region PenCommV2Callbacks
        void PenCommV2Callbacks.onConnected( IPenComm sender, string macAddress, string deviceName, string fwVersion, string protocolVersion, string subName, int maxForce )
        {
            mFilter = new PressureFilter( maxForce );
            this.maxForce = maxForce;
            Console.WriteLine("Max Force: " + maxForce);
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                btnConnect.Text = "Disconnect";
                btnConnect.Enabled = true;
                tbPenInfo.Text = String.Format( "Mac : {0}\r\n\r\nName : {1}\r\n\r\nSubName : {2}\r\n\r\nFirmware Version : {3}\r\n\r\nProtocol Version : {4}", macAddress, deviceName, subName, fwVersion, protocolVersion );
                ToggleOption( true );
            }));
        }

        void PenCommV2Callbacks.onPenAuthenticated( IPenComm sender )
        {
            mPenCommV2.ReqAddUsingNote();
            mPenCommV2.ReqOfflineDataList();
            mPenCommV2.ReqPenStatus();

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                groupBox8.Enabled = false;
            }));
        }

        void PenCommV2Callbacks.onDisconnected( IPenComm sender )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lbOfflineData.Items.Clear();
                btnConnect.Text = "Connect";
                tbPenInfo.Text = "";
                groupBox8.Enabled = true;
                ToggleOption( false );
            }));

            CloseProgress();
        }

        void PenCommV2Callbacks.onAvailableNoteAccepted(IPenComm sender, bool result)
        {
        }

        void PenCommV2Callbacks.onReceiveDot(IPenComm sender, Dot dot, ImageProcessingInfo info)
        {
            ProcessDot(dot);
        }

        void PenCommV2Callbacks.onReceiveOfflineDataList( IPenComm sender, params OfflineDataInfo[] offlineNotes )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                lbOfflineData.Items.Clear();
                foreach ( OfflineDataInfo item in offlineNotes )
                {
                    lbOfflineData.Items.Add( item );
                }
            } ) );
        }

        void PenCommV2Callbacks.onStartOfflineDownload( IPenComm sender )
        {
            DisplayProgress( ProgressTitleOffline, 100, 0 );
        }

        void PenCommV2Callbacks.onReceiveOfflineStrokes( IPenComm sender, int total, int progress, Stroke[] strokes, Symbol[] symbols )
        {
            foreach ( Stroke stroke in strokes )
            {
                ProcessStroke(stroke);
                DrawStroke( stroke );
            }
            DisplayProgress( ProgressTitleOffline, total, progress );
            Array.Clear( strokes, 0, strokes.Length );
        }

        void PenCommV2Callbacks.onFinishedOfflineDownload( IPenComm sender, bool isSuccess )
        {
            CloseProgress();
            mPenCommV2.ReqOfflineDataList();
        }

        void PenCommV2Callbacks.onRemovedOfflineData( IPenComm sender, bool result )
        {
            mPenCommV2.ReqOfflineDataList();
        }

        void PenCommV2Callbacks.onReceivePenStatus( IPenComm sender, bool locked, int passwdMaxReTryCount
            , int passwdRetryCount, long timestamp, short autoShutdownTime
            , int maxForce, int battery, int usedmem, bool useOfflineData
            , bool autoPowerOn, bool penCapPower, bool hoverMode
            , bool beep, short penSensitivity
            , PenCommV2.UsbMode usbmode, bool downsampling, string btLocalName
            , PenCommV2.DataTransmissionType dataTransmissionType )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                prgPower.Maximum = 100;
                prgPower.Value = battery > 100 ? 100 : battery;

                prgStorage.Maximum = 100;
                prgStorage.Value = usedmem;
            } ) );
        }

        void PenCommV2Callbacks.onPenPasswordRequest( IPenComm sender, int retryCount, int resetCount )
        {
            this.BeginInvoke( new MethodInvoker( delegate() 
            {
                mPwdForm.ShowDialog();
            } ) );
        }

        void PenCommV2Callbacks.onPenPasswordSetUpResponse( IPenComm sender, bool result )
        {
            //not implemented
        }

        void PenCommV2Callbacks.onPenOfflineDataSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenTimestampSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenSensitivitySetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenAutoShutdownTimeSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenAutoPowerOnSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenCapPowerOnOffSetupResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenBeepSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenHoverSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenColorSetUpResponse( IPenComm sender, bool result )
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onReceiveFirmwareUpdateStatus( IPenComm sender, int total, int progress )
        {
            DisplayProgress( ProgressTitleFirmware, total, progress );
        }

        void PenCommV2Callbacks.onReceiveFirmwareUpdateResult( IPenComm sender, bool result )
        {
            CloseProgress();
        }

        void PenCommV2Callbacks.onReceiveBatteryAlarm( IPenComm sender, int battery )
        {
            this.BeginInvoke( new MethodInvoker( delegate()
            {
                prgPower.Maximum = 100;
                prgPower.Value = battery;
            }));
        }

        void PenCommV2Callbacks.onPenUsbModeSetUpResponse(IPenComm sender, bool result)
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenDownSamplingSetUpResponse(IPenComm sender, bool result)
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenBtLocalNameSetUpResponse(IPenComm sender, bool result)
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenFscSensitivitySetUpResponse(IPenComm sender, bool result)
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onPenDataTransmissionTypeSetUpResponse(IPenComm sender, bool result)
        {
            mPenCommV2.ReqPenStatus();
        }

        void PenCommV2Callbacks.onErrorDetected(IPenComm sender, ErrorType errorType, long timestamp, Dot dot, string extraData, ImageProcessErrorInfo imageProcessErrorInfo)
        {
        }

        void PenCommV2Callbacks.onPenBeepAndLightResponse(IPenComm sender, bool result)
        {
        }

        void PenCommV2Callbacks.onPenProfileReceived(IPenComm sender, PenProfileReceivedCallbackArgs args)
        {
        }

        void PenCommV2Callbacks.onSymbolDetected(IPenComm sender, List<Symbol> symbols)
        {
            // TODO : Processing for detected symbols
            // Implement functions corresponding to predefined Actions.
            // For example, if Symbol's Action is email, it sends an email.
        }

        void PenCommV2Callbacks.onSecureCommunicationFailureOccurred(IPenComm sender, PenCommV2.SecureCommunicationFailureReason reason)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                MessageBox.Show("Secure communication failed : " + reason.ToString());
            }));
        }

        void PenCommV2Callbacks.onReceiveCertificateUpdateResult(IPenComm sender, PenCommV2.CertificateUpdateResult result)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (result == PenCommV2.CertificateUpdateResult.Success)
                    MessageBox.Show("Certificate Update Succeeded");
                else
                    MessageBox.Show("Certificate update failed : " + result.ToString());
            }));
        }

        void PenCommV2Callbacks.onReceiveCertificateDeleteResult(IPenComm sender, PenCommV2.CertificateDeleteResult result)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (result == PenCommV2.CertificateDeleteResult.Success)
                    MessageBox.Show("Certificate Deletion Successful");
                else
                    MessageBox.Show("Certificate Deletion Failed : " + result.ToString());
            }));
        }

        void PenCommV2Callbacks.onPrivateKeyRequest(IPenComm sender)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                MessageBox.Show("Please select a private key file.");
                btnSelectPrivateKey.Focus();
            }));
        }
        #endregion

        #region penControl
        private void button3_Click( object sender, EventArgs e )
        {
            if ( lbOfflineData.SelectedItem == null )
            {
                return;
            }
            OfflineDataInfo data = lbOfflineData.SelectedItem as OfflineDataInfo;
            Request(
                delegate { mPenCommV1.ReqOfflineData( data );  }, 
                delegate { mPenCommV2.ReqOfflineData( data.Section, data.Owner, data.Note, false, data.Pages );
            });
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if ( lbOfflineData.SelectedItem == null )
            {
                return;
            }
            OfflineDataInfo data = lbOfflineData.SelectedItem as OfflineDataInfo;
            Request( 
                delegate { mPenCommV1.ReqRemoveOfflineData( data.Section, data.Owner ); }, 
                delegate { mPenCommV2.ReqRemoveOfflineData( data.Section, data.Owner, new int[] { data.Note } );
            });
        }

        private void ToggleOption(bool enabled)
        {
            groupBox3.Enabled = enabled;
            groupBox5.Enabled = enabled;
            groupBox4.Enabled = enabled;
        }

        private void buttonpLastParticipant_Click(object sender, EventArgs e)
        {
            delSelectParticipant select = new delSelectParticipant(acceptParticipantChangedInput);
            delDeletePage deletePage = new delDeletePage(acceptPageDeleteRequest);
            delDeleteParticipant deleteParticipant = new delDeleteParticipant(acceptParticipantDeleteRequest);
            delRenameParticipant rename = new delRenameParticipant(acceptParticipantRenameRequest);
            SessionSelectionForm sessSelectForm = new SessionSelectionForm(select, deletePage, deleteParticipant, rename, session);
            sessSelectForm.Show();
        }

        private void loadSessionBtn_Click(object sender, EventArgs e)
        {
            session.SaveSessionToFile();
            String filePath = openFileDialog("Load Session", "No valid file selected", "Json file|*.json");
            if (filePath != null) {
                if (!session.LoadSessionFromFile(filePath)) {
                    MessageBox.Show("Loading the new Session from file failed");
                }
                else
                {
                    session = new Session(null, null, filePath, maxForce);
                    labelParticipantIDInput.Text = session.CurrentParticipantID;
                    labelPageNumberInput.Text = "" + session.CurrentPage.Number;
                    buttonNewSession.Text = "Stop Session";
                    InitImage();
                    DrawSession();
                }

            }
        }

        private void btnSelectPrivateKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Private Key Files|*.*";
            openFileDialog.Title = "Select a Private Key File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbPrivateKeyFilePath.Text = openFileDialog.FileName;
                if (mPenCommV2.SetPrivateKey(PrivateKeyFileReader.GetPrivateKeyFromFile(openFileDialog.FileName)))
                {
                    MessageBox.Show("The private key has been set");
                }
                else
                {
                    MessageBox.Show("Private key failed to set");
                }
            }
        }

        private String openFileDialog(String title, String errorDialog, String filter) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Title = title;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null)
                    return openFileDialog.FileName;
                else MessageBox.Show(errorDialog);

            }
            return null;
        }

        public void onAvailableNoteAccepted(IPenComm sender, bool result)
        {
            throw new NotImplementedException();
        }

        public void onUpDown(IPenComm sender, bool isUp)
        {
            throw new NotImplementedException();
        }

        public void onPenPasswordSetUpResponse(IPenComm sender, bool result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
