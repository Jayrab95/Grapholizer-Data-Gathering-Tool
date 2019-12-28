using Neosmartpen.Net.Neosmartpen.Net.Export_Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Metadata.Model
{
    public class Participant
    {
        public Participant(String Id) {
            this.Id = Id;
            this.Pages = new List<Page>();
        }

        public Participant(CompressedParticipant cParticipant, int maxForce)
        {
            this.Id = cParticipant.Id;
            if (cParticipant.Pages != null)
            {
                if (cParticipant.Pages.Count > 0)
                {
                    foreach (CompressedPage cPage in cParticipant.Pages)
                    {
                        this.Pages.Add(new Page(cPage, maxForce));
                    }
                }
            }
        }
        public String Id { get; set; }

        public List<Page> Pages { get; set; }
    }
}
