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
        public delegate void delDeletePage(String ParticipantID, int pageNumber);
        public delegate void delDeleteParticipant(String ParticipantID);
        public delegate void renameParticipant(String OldParticipantID, String NewParticipantID);

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
            if (ListBoxParticipantID.SelectedItem == null)
            {
                SelectedParticipantID = null;
            }
            else
            {
                SelectedParticipantID = (String)ListBoxParticipantID.SelectedItem;
                //After every selected participant clean old entries in list and load the new pageNumbers
                listBoxPageNumber.Items.Clear();
                foreach (Page page in session.ParticipantsMap[SelectedParticipantID].Pages)
                {
                    listBoxPageNumber.Items.Add(page.Number);
                }
            }
        }
        private void listBoxPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPageNumber.SelectedItem == null)
            {
                SelectedPageNum = -1;
            }
            else
            {
                SelectedPageNum = (int)listBoxPageNumber.SelectedItem;
            }
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPageNum != -1 && listBoxPageNumber.Items.Count > 1)
            {
                delDeletePage delPage = new delDeletePage(MainFormRef.acceptPageDeleteRequest);
                delPage(SelectedParticipantID, SelectedPageNum);
                listBoxPageNumber.Items.Remove(SelectedPageNum);
            }
            else {
                //TODO(lukas) Error no element selected or list has only one element
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (SelectedParticipantID != null && ListBoxParticipantID.Items.Count > 1)
            {
                delDeleteParticipant delParticipant = new delDeleteParticipant(MainFormRef.acceptParticipantDeleteRequest);
                delParticipant(SelectedParticipantID);
                ListBoxParticipantID.Items.Remove(SelectedParticipantID);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check if there is anything in the textbox and if there is a active selection
            if (SelectedParticipantID != null && textBoxPartId.Text != null && textBoxPartId.Text != "")
            {
                renameParticipant renameParticipant = new renameParticipant(MainFormRef.acceptParticipantRenameRequest);
                renameParticipant(SelectedParticipantID, textBoxPartId.Text);
                this.Close();
            }
        }
    }
}
