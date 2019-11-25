namespace PenDemo
{
    partial class NewSessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.acceptButton = new System.Windows.Forms.Button();
            this.textBoxSessionId = new System.Windows.Forms.TextBox();
            this.textBoxParticipantId = new System.Windows.Forms.MaskedTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelSessionId = new System.Windows.Forms.Label();
            this.labelParticipantId = new System.Windows.Forms.Label();
            this.labelOutputFile = new System.Windows.Forms.Label();
            this.buttonOutputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(340, 292);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(104, 36);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptingButton_Click);
            // 
            // textBoxSessionId
            // 
            this.textBoxSessionId.Location = new System.Drawing.Point(59, 80);
            this.textBoxSessionId.Name = "textBoxSessionId";
            this.textBoxSessionId.Size = new System.Drawing.Size(233, 26);
            this.textBoxSessionId.TabIndex = 1;
            // 
            // textBoxParticipantId
            // 
            this.textBoxParticipantId.Location = new System.Drawing.Point(59, 164);
            this.textBoxParticipantId.Name = "textBoxParticipantId";
            this.textBoxParticipantId.Size = new System.Drawing.Size(233, 26);
            this.textBoxParticipantId.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "data.json";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // labelSessionId
            // 
            this.labelSessionId.AutoSize = true;
            this.labelSessionId.Location = new System.Drawing.Point(59, 54);
            this.labelSessionId.Name = "labelSessionId";
            this.labelSessionId.Size = new System.Drawing.Size(87, 20);
            this.labelSessionId.TabIndex = 3;
            this.labelSessionId.Text = "Session ID";
            // 
            // labelParticipantId
            // 
            this.labelParticipantId.AutoSize = true;
            this.labelParticipantId.Location = new System.Drawing.Point(59, 138);
            this.labelParticipantId.Name = "labelParticipantId";
            this.labelParticipantId.Size = new System.Drawing.Size(105, 20);
            this.labelParticipantId.TabIndex = 4;
            this.labelParticipantId.Text = "Participant ID";
            // 
            // labelOutputFile
            // 
            this.labelOutputFile.AutoSize = true;
            this.labelOutputFile.Location = new System.Drawing.Point(55, 215);
            this.labelOutputFile.Name = "labelOutputFile";
            this.labelOutputFile.Size = new System.Drawing.Size(118, 20);
            this.labelOutputFile.TabIndex = 5;
            this.labelOutputFile.Text = "Output File:: C:\\";
            // 
            // buttonOutputFile
            // 
            this.buttonOutputFile.Location = new System.Drawing.Point(59, 249);
            this.buttonOutputFile.Name = "buttonOutputFile";
            this.buttonOutputFile.Size = new System.Drawing.Size(233, 30);
            this.buttonOutputFile.TabIndex = 6;
            this.buttonOutputFile.Text = "Choose Output File";
            this.buttonOutputFile.UseVisualStyleBackColor = true;
            this.buttonOutputFile.Click += new System.EventHandler(this.buttonOutFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter the names of this session and the first participant";
            // 
            // NewSessionForm
            // 
            this.ClientSize = new System.Drawing.Size(487, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOutputFile);
            this.Controls.Add(this.labelOutputFile);
            this.Controls.Add(this.labelParticipantId);
            this.Controls.Add(this.labelSessionId);
            this.Controls.Add(this.textBoxParticipantId);
            this.Controls.Add(this.textBoxSessionId);
            this.Controls.Add(this.acceptButton);
            this.Name = "NewSessionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox textBoxSessionId;
        private System.Windows.Forms.MaskedTextBox textBoxParticipantId;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label labelSessionId;
        private System.Windows.Forms.Label labelParticipantId;
        private System.Windows.Forms.Label labelOutputFile;
        private System.Windows.Forms.Button buttonOutputFile;
        private System.Windows.Forms.Label label1;
    }
}