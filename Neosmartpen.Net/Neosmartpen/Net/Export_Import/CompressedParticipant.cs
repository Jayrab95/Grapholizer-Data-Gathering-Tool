﻿using System;
using System.Collections.Generic;
using Neosmartpen.Net.Metadata.Model;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public class CompressedParticipant
    {
        public CompressedParticipant() {}
        public CompressedParticipant(Participant participant, int maxForce) {
            Id = participant.Id;
            List<Page> standin = participant.Pages;
            Pages = new List<CompressedPage>();
            for (int i = 0; i < standin.Count; i++)
            {
                Page temp = standin[i];
                this.Pages.Add(new CompressedPage(temp, Id, maxForce));
            }
        }
        public String Id { get; set; }

        public List<CompressedPage> Pages { get; set; }
    }
}
