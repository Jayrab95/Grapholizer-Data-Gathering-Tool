namespace PenDemo
{
    partial class ParticipantCreateForm
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
            this.components = new System.ComponentModel.Container();
            this.labelParticipant = new System.Windows.Forms.Label();
            this.textBoxParticipant = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelParticipant
            // 
            this.labelParticipant.AutoSize = true;
            this.labelParticipant.Location = new System.Drawing.Point(51, 34);
            this.labelParticipant.Name = "labelParticipant";
            this.labelParticipant.Size = new System.Drawing.Size(148, 20);
            this.labelParticipant.TabIndex = 0;
            this.labelParticipant.Text = "Enter Participant ID";
            this.labelParticipant.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxParticipant
            // 
            this.textBoxParticipant.Location = new System.Drawing.Point(48, 72);
            this.textBoxParticipant.Name = "textBoxParticipant";
            this.textBoxParticipant.Size = new System.Drawing.Size(151, 26);
            this.textBoxParticipant.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(83, 117);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 35);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "OK";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // ParticipantCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 173);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxParticipant);
            this.Controls.Add(this.labelParticipant);
            this.Name = "ParticipantCreateForm";
            this.Text = "New Participant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelParticipant;
        private System.Windows.Forms.TextBox textBoxParticipant;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonAccept;
    }
}