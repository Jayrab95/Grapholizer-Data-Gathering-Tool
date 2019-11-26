using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neosmartpen.Net.Metadata.Model;

namespace PenDemo
{
    public partial class SessionSelectionForm : Form
    {
        MainForm MainFormRef;
        Session session;
        String SelectedParticipantID = null;
        int SelectedPageNum = -1;
        public delegate void delPassData(String ParticipantID, int pageNumber);
        public SessionSelectionForm(MainForm MainformRef, Session session)
        {
            this.MainFormRef = MainformRef;
            this.session = session;
            InitializeComponent();
            //Load the data from the session
            foreach (String key in session.ParticipantsMap.Keys)
            {
                ListBoxParticipantID.Items.Add(key);
            }
        }

        private void ListBoxSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedParticipantID = (String) ListBoxParticipantID.SelectedItem;
            //After every selected participant clean old entries in list and load the new pageNumbers
            listBoxPageNumber.Items.Clear();
            foreach (Page page in session.ParticipantsMap[SelectedParticipantID].Pages) {
                listBoxPageNumber.Items.Add(page.Number);
            }
        }
        private void listBoxPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPageNum = (int) listBoxPageNumber.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedParticipantID != null && SelectedPageNum != -1)
            {
                delPassData deleg = new delPassData(MainFormRef.acceptParticipantChangedInput);
                deleg(SelectedParticipantID, SelectedPageNum);
                this.Close();
            }
            else
            {
                //TODO(lukas) Error no element selected
            }
        }
    }
}
