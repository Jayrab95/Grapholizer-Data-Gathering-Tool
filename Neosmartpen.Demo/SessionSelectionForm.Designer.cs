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
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPartId = new System.Windows.Forms.TextBox();
            this.ListBoxParticipantID = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPartId);
            this.splitContainer1.Panel1.Controls.Add(this.ListBoxParticipantID);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDelete);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxPageNumber);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAccept);
            this.splitContainer1.Size = new System.Drawing.Size(871, 334);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Participant ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 197);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete Participant";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Participant";
            // 
            // textBoxPartId
            // 
            this.textBoxPartId.Location = new System.Drawing.Point(307, 75);
            this.textBoxPartId.Name = "textBoxPartId";
            this.textBoxPartId.Size = new System.Drawing.Size(100, 22);
            this.textBoxPartId.TabIndex = 5;
            // 
            // ListBoxParticipantID
            // 
            this.ListBoxParticipantID.FormattingEnabled = true;
            this.ListBoxParticipantID.ItemHeight = 16;
            this.ListBoxParticipantID.Location = new System.Drawing.Point(12, 55);
            this.ListBoxParticipantID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBoxParticipantID.Name = "ListBoxParticipantID";
            this.ListBoxParticipantID.Size = new System.Drawing.Size(289, 228);
            this.ListBoxParticipantID.TabIndex = 0;
            this.ListBoxParticipantID.SelectedIndexChanged += new System.EventHandler(this.ListBoxSessionID_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Rename Participant";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Page";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(242, 55);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(112, 43);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete Page";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxPageNumber
            // 
            this.listBoxPageNumber.FormattingEnabled = true;
            this.listBoxPageNumber.ItemHeight = 16;
            this.listBoxPageNumber.Location = new System.Drawing.Point(21, 55);
            this.listBoxPageNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPageNumber.Name = "listBoxPageNumber";
            this.listBoxPageNumber.Size = new System.Drawing.Size(204, 228);
            this.listBoxPageNumber.TabIndex = 1;
            this.listBoxPageNumber.SelectedIndexChanged += new System.EventHandler(this.listBoxPageNumber_SelectedIndexChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(292, 275);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(112, 48);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Accept Select";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.button1_Click);
            // 
            // SessionSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 334);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SessionSelectionForm";
            this.Text = "Participant Selection Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox ListBoxParticipantID;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ListBox listBoxPageNumber;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPartId;
    }
}