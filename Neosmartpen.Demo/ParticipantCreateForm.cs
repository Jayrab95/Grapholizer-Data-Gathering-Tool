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
        delPassParticipantID callback;

        public ParticipantCreateForm(delPassParticipantID callback)
        {
            this.callback = callback;
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxParticipant.Text == "" || textBoxParticipant.Text == null) return;
            callback(textBoxParticipant.Text);
            this.Close();

        }
    }
}
