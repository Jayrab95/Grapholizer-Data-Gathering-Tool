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
        public String Id { get; set; }

        public List<Page> Pages { get; set; }
    }
}
