using System;
using System.Collections.Generic;
using Neosmartpen.Net.Neosmartpen.Net.Export_Import;
using System.IO;
using System.Collections;

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
        public Session(String SessionID, String CurrentParticipantID, String FilePath, int maxForce) {
            this.FilePath = FilePath;
            this.CurrentPage = null;
            this.CurrentParticipantID = CurrentParticipantID;
            this.maxForce = maxForce;

            Participant participant = new Participant(CurrentParticipantID);
            ParticipantsMap = new Dictionary<string, Participant>();
            if(CurrentParticipantID != null) ParticipantsMap.Add(CurrentParticipantID, participant);
        }

        /// <summary>
        /// Represents the Participant that is currently worked on by the application
        /// </summary>
        public String SessionID{ get; set; }

        /// <summary>
        /// Represents the Participant that is currently worked on by the application
        /// </summary>
        public String FilePath { get; set; }

        /// <summary>
        /// Represents the Participant that is currently worked on by the application
        /// </summary>
        public String CurrentParticipantID { get; set; }

        /// <summary>
        /// Current page that the Participant is writing on
        /// </summary>
        public Page CurrentPage{ get; set; }

        /// <summary>
        /// All data that has been created in this Session 
        /// </summary>
        public Dictionary<String, Participant> ParticipantsMap { get; set; }

        /// <summary>
        /// Maximum Force that can be applied to the pen (needed for data export)
        /// </summary>
        private int maxForce { get; }

        /// <summary>
        /// Changes Participant and therefore the inner state of the Session
        /// All new Pages and Strokes will be written to this new Participant-Object
        /// </summary>
        public bool NewParticipant(String participantID)
        {
            try
            {
                Participant participant = new Participant(participantID);
                ParticipantsMap.Add(participantID, participant);
                CurrentParticipantID = participantID;
                CurrentPage = null;
                return true;
            }
            catch (Exception e) {
                return false;
            }
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

        public void DeletePage(String participantID,int pageNum)
        {
            List<Page> pages = ParticipantsMap[participantID].Pages;
            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i].Number == pageNum)
                {
                    ParticipantsMap[participantID].Pages.RemoveAt(i);
                    break;
                }
            }
            
        }

        public void DeleteParticipant(String participantID)
        {
            ParticipantsMap.Remove(participantID);
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
            data = JsonFormatter.Format(ParticipantsMap, maxForce);
            File.WriteAllText(FilePath, data);
            return true;
        }

        /// <summary>
        /// Load data from file path into internal data structure
        /// </summary>
        public bool LoadSessionFromFile(String filePath) {
            String content = File.ReadAllText(filePath);
            if (content == null) return false;
            Console.WriteLine("deformat");
            ParticipantsMap = JsonFormatter.Deformat(content, maxForce);

            Console.WriteLine("finished deformat");

            IEnumerator enumerator = ParticipantsMap.Keys.GetEnumerator();
            enumerator.MoveNext();
            Participant first = (Participant)enumerator.Current;

            String fileName = Path.GetFileName(filePath);
            CurrentParticipantID = first.Id;
            CurrentPage = first.Pages[0];
            SessionID = fileName;

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
