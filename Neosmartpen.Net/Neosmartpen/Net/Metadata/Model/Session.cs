using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neosmartpen.Net.Neosmartpen.Net.Export_Import;
using System.IO;

namespace Neosmartpen.Net.Metadata.Model
{
    /// <summary>
    /// A class representing a Map Datastructure that manages the entire internal state of the evaluation 
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Only valid Constructor to guarantee correct inner state of Session
        /// </summary>
        public Session(String CurrentParticipantID, String FilePath) {
            this.FilePath = FilePath;
            this.CurrentPage = null;
            this.CurrentParticipantID = CurrentParticipantID;

            Participant participant = new Participant(CurrentParticipantID);
            ParticipantsMap = new Dictionary<string, Participant>();
            ParticipantsMap.Add(CurrentParticipantID, participant);

            ParticipantIDs = new List<String>();
            ParticipantIDs.Add(CurrentParticipantID);
        }
        /// <summary>
        /// Represents the Participant that is currently worked on by the application
        /// </summary>
        public String FilePath { get; set; }
        /// <summary>
        /// Represents the Participant that is currently worked on by the application
        /// </summary>
        public String CurrentParticipantID { get; set; }

        /// <summary>
        /// Represents all the Participant 
        /// </summary>
        public List<String> ParticipantIDs { get; set; }

        /// <summary>
        /// Current page that the Participant is writing on
        /// </summary>
        public Page CurrentPage{ get; set; }

        /// <summary>
        /// All data that has been created in this Session 
        /// </summary>
        public Dictionary<String, Participant> ParticipantsMap { get; }

        /// <summary>
        /// Changes Participant and therefore the inner state of the Session
        /// All new Pages and Strokes will be written to this new Participant-Object
        /// </summary>
        public void NewParticipant(String participantID)
        {
            Participant participant = new Participant(participantID);
            ParticipantIDs.Add(participantID);
            ParticipantsMap.Add(participantID, participant);
            CurrentPage = null;
            CurrentParticipantID = participantID;
        }

        /// <summary>
        /// Changes inner state of session to this participant
        /// </summary>
        public void ChangeParticipant(String participantID)
        {
            CurrentParticipantID = participantID;
        }
        /// <summary>
        /// Adds Stroke to the current State of the Session
        /// Represented by the CurrentParticipantID and CurrentPage Object
        /// </summary>
        public void AddStrokeToParticipantPage(Stroke stroke)
        {
            CurrentPage.Strokes.Add(stroke);
        }

        /// <summary>
        /// Changes the inner state of the session so that the new page of the current participant is loaded
        /// </summary>
        public void ChangePage(int pageIndex)
        {
            CurrentPage = ParticipantsMap[CurrentParticipantID].Pages[pageIndex];
        }

        /// <summary>
        /// Changes the inner state of the session so that the new page of the current participant is loaded
        /// </summary>
        public void NewPage(Page newPage)
        {
            ParticipantsMap[CurrentParticipantID].Pages.Add(newPage);
            CurrentPage = newPage;
        }

        public Page GetPage(int pageNumber)
        {
            List<Page> pages = ParticipantsMap[CurrentParticipantID].Pages;
            foreach (Page page in pages) 
            {
                if (page.Number == pageNumber) return page;
            }
            return null;
        }

        public int GetPageIndex(int pageNumber) {
            List<Page> pages = ParticipantsMap[CurrentParticipantID].Pages;
            for (int i = 0; i < pages.Count; i++ )
            {
                if (pages[i].Number == pageNumber) return i;
            }
            return -1;
        }
        /// <summary>
        /// Save the data structur to the file at FilePath
        /// </summary>
        public bool SaveSessionToFile()
        { 
            String data = "";
            data = JsonFormatter.Format(ParticipantsMap);
            File.WriteAllText(FilePath, data);
            return true;
        }

        public String toString()
        {
            return "Session:::: {FilePath:: } " + FilePath 
                + " {Current Participant} " + CurrentParticipantID 
                +" {currentPage} " + CurrentPage.ToString();
        }
    }
}
