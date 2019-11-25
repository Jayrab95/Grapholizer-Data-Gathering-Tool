using System;
using System.Collections.Generic;
using Neosmartpen.Net.Metadata.Model;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public class CompressedParticipant
    {
        public CompressedParticipant(Participant participant) {
            Id = participant.Id;
            Pages = new List<CompressedPage>();
            List<Page> pages = participant.Pages;
            for (int i = 0; i < pages.Count; i++) {
                Pages.Add(new CompressedPage(pages[i]));
            }
        }
        public String Id { get; set; }

        List<CompressedPage> Pages { get; set; }
    }
}
