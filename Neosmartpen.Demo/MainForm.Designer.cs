namespace PenDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.buttonNewSession = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelNewSession = new System.Windows.Forms.Label();
            this.buttonNextParticipant = new System.Windows.Forms.Button();
            this.labelExportError = new System.Windows.Forms.Label();
            this.labelCurrentParticipant = new System.Windows.Forms.Label();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.loadSessionBtn = new System.Windows.Forms.Button();
            this.labelPageNumberInput = new System.Windows.Forms.Label();
            this.labelParticipantIDInput = new System.Windows.Forms.Label();
            this.labelCurrentPageNum = new System.Windows.Forms.Label();
            this.buttonpLastParticipant = new System.Windows.Forms.Button();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPenInfo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbOfflineData = new System.Windows.Forms.ListBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.prgPower = new System.Windows.Forms.ProgressBar();
            this.prgStorage = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSelectPrivateKey = new System.Windows.Forms.Button();
            this.tbPrivateKeyFilePath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBoxExport.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDevices
            // 
            this.lbDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.ItemHeight = 16;
            this.lbDevices.Location = new System.Drawing.Point(12, 26);
            this.lbDevices.Margin = new System.Windows.Forms.Padding(4);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(294, 210);
            this.lbDevices.TabIndex = 23;
            this.lbDevices.SelectedIndexChanged += new System.EventHandler(this.lbDevices_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 246);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 30);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // buttonNewSession
            // 
            this.buttonNewSession.Location = new System.Drawing.Point(13, 41);
            this.buttonNewSession.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNewSession.Name = "buttonNewSession";
            this.buttonNewSession.Size = new System.Drawing.Size(100, 33);
            this.buttonNewSession.TabIndex = 6;
            this.buttonNewSession.Text = "New Session";
            this.buttonNewSession.Click += new System.EventHandler(this.buttonNewSession_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(131, 44);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(61, 30);
            this.buttonExport.TabIndex = 22;
            this.buttonExport.Text = "Save";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelNewSession
            // 
            this.labelNewSession.Location = new System.Drawing.Point(6, 19);
            this.labelNewSession.Name = "labelNewSession";
            this.labelNewSession.Size = new System.Drawing.Size(172, 18);
            this.labelNewSession.TabIndex = 23;
            this.labelNewSession.Text = "Click to start new Session";
            // 
            // buttonNextParticipant
            // 
            this.buttonNextParticipant.Enabled = false;
            this.buttonNextParticipant.Location = new System.Drawing.Point(153, 174);
            this.buttonNextParticipant.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNextParticipant.Name = "buttonNextParticipant";
            this.buttonNextParticipant.Size = new System.Drawing.Size(124, 30);
            this.buttonNextParticipant.TabIndex = 22;
            this.buttonNextParticipant.Text = "Next Participant";
            this.buttonNextParticipant.UseVisualStyleBackColor = true;
            this.buttonNextParticipant.Click += new System.EventHandler(this.buttonNextParticipant_Click);
            // 
            // labelExportError
            // 
            this.labelExportError.AutoSize = true;
            this.labelExportError.Location = new System.Drawing.Point(13, 227);
            this.labelExportError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExportError.Name = "labelExportError";
            this.labelExportError.Size = new System.Drawing.Size(0, 17);
            this.labelExportError.TabIndex = 5;
            // 
            // labelCurrentParticipant
            // 
            this.labelCurrentParticipant.AutoSize = true;
            this.labelCurrentParticipant.Location = new System.Drawing.Point(9, 98);
            this.labelCurrentParticipant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentParticipant.Name = "labelCurrentParticipant";
            this.labelCurrentParticipant.Size = new System.Drawing.Size(151, 17);
            this.labelCurrentParticipant.TabIndex = 5;
            this.labelCurrentParticipant.Text = "Current Participant ID::";
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.loadSessionBtn);
            this.groupBoxExport.Controls.Add(this.labelPageNumberInput);
            this.groupBoxExport.Controls.Add(this.labelParticipantIDInput);
            this.groupBoxExport.Controls.Add(this.labelCurrentPageNum);
            this.groupBoxExport.Controls.Add(this.buttonpLastParticipant);
            this.groupBoxExport.Controls.Add(this.buttonNewSession);
            this.groupBoxExport.Controls.Add(this.buttonExport);
            this.groupBoxExport.Controls.Add(this.labelExportError);
            this.groupBoxExport.Controls.Add(this.buttonNextParticipant);
            this.groupBoxExport.Controls.Add(this.labelNewSession);
            this.groupBoxExport.Controls.Add(this.labelCurrentParticipant);
            this.groupBoxExport.Enabled = false;
            this.groupBoxExport.Location = new System.Drawing.Point(339, 124);
            this.groupBoxExport.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxExport.Size = new System.Drawing.Size(295, 222);
            this.groupBoxExport.TabIndex = 26;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "Participant Control";
            // 
            // loadSessionBtn
            // 
            this.loadSessionBtn.Location = new System.Drawing.Point(196, 44);
            this.loadSessionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadSessionBtn.Name = "loadSessionBtn";
            this.loadSessionBtn.Size = new System.Drawing.Size(91, 30);
            this.loadSessionBtn.TabIndex = 28;
            this.loadSessionBtn.Text = "Load Session";
            this.loadSessionBtn.UseVisualStyleBackColor = true;
            this.loadSessionBtn.Click += new System.EventHandler(this.loadSessionBtn_Click);
            // 
            // labelPageNumberInput
            // 
            this.labelPageNumberInput.AutoSize = true;
            this.labelPageNumberInput.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelPageNumberInput.Location = new System.Drawing.Point(121, 128);
            this.labelPageNumberInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPageNumberInput.Name = "labelPageNumberInput";
            this.labelPageNumberInput.Size = new System.Drawing.Size(18, 17);
            this.labelPageNumberInput.TabIndex = 27;
            this.labelPageNumberInput.Text = "\"\"";
            // 
            // labelParticipantIDInput
            // 
            this.labelParticipantIDInput.AutoSize = true;
            this.labelParticipantIDInput.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelParticipantIDInput.Location = new System.Drawing.Point(167, 98);
            this.labelParticipantIDInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParticipantIDInput.Name = "labelParticipantIDInput";
            this.labelParticipantIDInput.Size = new System.Drawing.Size(18, 17);
            this.labelParticipantIDInput.TabIndex = 26;
            this.labelParticipantIDInput.Text = "\"\"";
            // 
            // labelCurrentPageNum
            // 
            this.labelCurrentPageNum.AutoSize = true;
            this.labelCurrentPageNum.Location = new System.Drawing.Point(12, 128);
            this.labelCurrentPageNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentPageNum.Name = "labelCurrentPageNum";
            this.labelCurrentPageNum.Size = new System.Drawing.Size(107, 17);
            this.labelCurrentPageNum.TabIndex = 25;
            this.labelCurrentPageNum.Text = "Page Number:: ";
            // 
            // buttonpLastParticipant
            // 
            this.buttonpLastParticipant.Enabled = false;
            this.buttonpLastParticipant.Location = new System.Drawing.Point(12, 174);
            this.buttonpLastParticipant.Margin = new System.Windows.Forms.Padding(4);
            this.buttonpLastParticipant.Name = "buttonpLastParticipant";
            this.buttonpLastParticipant.Size = new System.Drawing.Size(124, 30);
            this.buttonpLastParticipant.TabIndex = 24;
            this.buttonpLastParticipant.Text = "Old Participant";
            this.buttonpLastParticipant.UseVisualStyleBackColor = true;
            this.buttonpLastParticipant.Click += new System.EventHandler(this.buttonpLastParticipant_Click);
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMacAddress.Location = new System.Drawing.Point(12, 290);
            this.txtMacAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(181, 22);
            this.txtMacAddress.TabIndex = 19;
            this.txtMacAddress.Text = "9C7BD20555EF";
            this.txtMacAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(200, 290);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 30);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.lbDevices);
            this.groupBox2.Controls.Add(this.txtMacAddress);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Location = new System.Drawing.Point(16, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(316, 332);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " 1. Search and select your device ";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(644, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(577, 986);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 2. Write something on your ncode note ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::PenDemo.Properties.Resources.background;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 775);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPenInfo);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(16, 354);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(316, 169);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pen Information";
            // 
            // tbPenInfo
            // 
            this.tbPenInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPenInfo.Location = new System.Drawing.Point(20, 30);
            this.tbPenInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPenInfo.Multiline = true;
            this.tbPenInfo.Name = "tbPenInfo";
            this.tbPenInfo.ReadOnly = true;
            this.tbPenInfo.Size = new System.Drawing.Size(276, 122);
            this.tbPenInfo.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.lbOfflineData);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(13, 531);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(317, 205);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offline Data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 163);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 163);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 30);
            this.button3.TabIndex = 1;
            this.button3.Text = "Download";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbOfflineData
            // 
            this.lbOfflineData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOfflineData.FormattingEnabled = true;
            this.lbOfflineData.ItemHeight = 16;
            this.lbOfflineData.Location = new System.Drawing.Point(8, 28);
            this.lbOfflineData.Margin = new System.Windows.Forms.Padding(4);
            this.lbOfflineData.Name = "lbOfflineData";
            this.lbOfflineData.Size = new System.Drawing.Size(301, 114);
            this.lbOfflineData.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Power";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Storage";
            // 
            // prgPower
            // 
            this.prgPower.Location = new System.Drawing.Point(77, 51);
            this.prgPower.Margin = new System.Windows.Forms.Padding(4);
            this.prgPower.Name = "prgPower";
            this.prgPower.Size = new System.Drawing.Size(200, 30);
            this.prgPower.TabIndex = 13;
            // 
            // prgStorage
            // 
            this.prgStorage.Location = new System.Drawing.Point(77, 89);
            this.prgStorage.Margin = new System.Windows.Forms.Padding(4);
            this.prgStorage.Name = "prgStorage";
            this.prgStorage.Size = new System.Drawing.Size(200, 30);
            this.prgStorage.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.prgPower);
            this.groupBox5.Controls.Add(this.prgStorage);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(339, 354);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(295, 225);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pen Setting";
            // 
            // btnSelectPrivateKey
            // 
            this.btnSelectPrivateKey.Location = new System.Drawing.Point(204, 50);
            this.btnSelectPrivateKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectPrivateKey.Name = "btnSelectPrivateKey";
            this.btnSelectPrivateKey.Size = new System.Drawing.Size(79, 30);
            this.btnSelectPrivateKey.TabIndex = 1;
            this.btnSelectPrivateKey.Text = "Browse";
            this.btnSelectPrivateKey.UseVisualStyleBackColor = true;
            this.btnSelectPrivateKey.Click += new System.EventHandler(this.btnSelectPrivateKey_Click);
            // 
            // tbPrivateKeyFilePath
            // 
            this.tbPrivateKeyFilePath.Location = new System.Drawing.Point(13, 52);
            this.tbPrivateKeyFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrivateKeyFilePath.Name = "tbPrivateKeyFilePath";
            this.tbPrivateKeyFilePath.ReadOnly = true;
            this.tbPrivateKeyFilePath.Size = new System.Drawing.Size(184, 22);
            this.tbPrivateKeyFilePath.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "* Private key file for authentication: ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbPrivateKeyFilePath);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.btnSelectPrivateKey);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(339, 18);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(295, 98);
            this.groupBox8.TabIndex = 26;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Authentication Parameter";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1323, 605);
            this.Controls.Add(this.groupBoxExport);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxExport.ResumeLayout(false);
            this.groupBoxExport.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button buttonNewSession;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonNextParticipant;
        private System.Windows.Forms.Label labelNewSession;
        private System.Windows.Forms.Label labelCurrentParticipant;
        private System.Windows.Forms.Label labelExportError;
        private System.Windows.Forms.GroupBox groupBoxExport;

        private System.Windows.Forms.ListBox lbOfflineData;
        private System.Windows.Forms.TextBox tbPenInfo;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar prgPower;
        private System.Windows.Forms.ProgressBar prgStorage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPrivateKeyFilePath;
        private System.Windows.Forms.Button btnSelectPrivateKey;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonpLastParticipant;
        private System.Windows.Forms.Label labelCurrentPageNum;
        private System.Windows.Forms.Label labelParticipantIDInput;
        private System.Windows.Forms.Label labelPageNumberInput;
        private System.Windows.Forms.Button loadSessionBtn;
    }
}

