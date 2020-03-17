using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PenDemo
{
    public partial class ParticipantCreateForm : Form
    {
        MainForm MainFormRef;
        public delegate void delPassData(String participantID);

        public ParticipantCreateForm(MainForm mainFormRef)
        {
            this.MainFormRef = mainFormRef;
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxParticipant.Text == "" || textBoxParticipant.Text == null) return;
            delPassData deleg = new delPassData(MainFormRef.acceptNewParticipantInput);
            deleg(textBoxParticipant.Text);
            this.Close();

        }
    }
}
