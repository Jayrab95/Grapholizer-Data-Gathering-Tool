﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using Neosmartpen.Net.Metadata.Model;

namespace PenDemo
{
    public partial class NewSessionForm : Form
    {
        public delegate void delPassData(Session session);
        String FilePath;
        MainForm mainFormRef;
        Page currentPage;
        int maxForce;
        public NewSessionForm(MainForm mainFormRef, int maxForce)
        {
            this.mainFormRef = mainFormRef;
            this.maxForce = maxForce;
            InitializeComponent();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            labelOutputFile.Text = saveFileDialog.FileName;
            FilePath = saveFileDialog.FileName;
        }

        private void buttonOutFile_Click(object sender, EventArgs e)
        { 
            saveFileDialog.ShowDialog();
        }

        private void acceptingButton_Click(object sender, EventArgs e)
        { 
            if (saveFileDialog.FileName == "" || saveFileDialog.FileName == null) {
                labelOutputFile.Text = "Filename is invalid";
                return;
            }
            if (textBoxParticipantId.Text == "" 
                || textBoxSessionId.Text == "" 
                || textBoxSessionId.Text == null 
                || textBoxParticipantId.Text == null) {
                labelOutputFile.Text = "You need to enter both IDs";
                return;
            }
            Participant participant = new Participant(textBoxParticipantId.Text);
            Session session = new Session(textBoxSessionId.Text, textBoxParticipantId.Text, saveFileDialog.FileName, maxForce);
            delPassData deleg = new delPassData(mainFormRef.acceptNewSessionFormInput);
            deleg(session);
            this.Close();
        }
    }
}
