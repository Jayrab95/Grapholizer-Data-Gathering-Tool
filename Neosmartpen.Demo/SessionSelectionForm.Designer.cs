namespace PenDemo
{
    partial class SessionSelectionForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListBoxParticipantID = new System.Windows.Forms.ListBox();
            this.listBoxPageNumber = new System.Windows.Forms.ListBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.ListBoxParticipantID);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxPageNumber);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAccept);
            this.splitContainer1.Size = new System.Drawing.Size(800, 272);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 0;
            // 
            // ListBoxParticipantID
            // 
            this.ListBoxParticipantID.FormattingEnabled = true;
            this.ListBoxParticipantID.ItemHeight = 20;
            this.ListBoxParticipantID.Location = new System.Drawing.Point(12, 12);
            this.ListBoxParticipantID.Name = "ListBoxParticipantID";
            this.ListBoxParticipantID.Size = new System.Drawing.Size(360, 244);
            this.ListBoxParticipantID.TabIndex = 0;
            this.ListBoxParticipantID.SelectedIndexChanged += new System.EventHandler(this.ListBoxSessionID_SelectedIndexChanged);
            // 
            // listBoxPageNumber
            // 
            this.listBoxPageNumber.FormattingEnabled = true;
            this.listBoxPageNumber.ItemHeight = 20;
            this.listBoxPageNumber.Location = new System.Drawing.Point(3, 12);
            this.listBoxPageNumber.Name = "listBoxPageNumber";
            this.listBoxPageNumber.Size = new System.Drawing.Size(206, 244);
            this.listBoxPageNumber.TabIndex = 1;
            this.listBoxPageNumber.SelectedIndexChanged += new System.EventHandler(this.listBoxPageNumber_SelectedIndexChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(235, 100);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(126, 60);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.button1_Click);
            // 
            // SessionSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 272);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SessionSelectionForm";
            this.Text = "SessionSelectionForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox ListBoxParticipantID;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ListBox listBoxPageNumber;
    }
}