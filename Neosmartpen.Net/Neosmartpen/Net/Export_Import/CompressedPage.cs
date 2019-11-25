using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neosmartpen.Net;

namespace Neosmartpen.Net.Export_Import
{
    class CompressedPage
    {
        public CompressedPage(Page page) {
            Section = page.Section;
            Owner = page.Owner;
            Book = page.Book;
            Number = page.Number;
            X1 = page.X1;
            Y1 = page.Y1;
            X2 = page.X2;
            Y2 = page.Y2;
            MarginB = page.MarginB;
            MarginL = page.MarginL;
            MarginR = page.MarginR;
            MarginT = page.MarginT;

            List<Stroke> standin = page.Strokes;
            Strokes = new List<CompressedStroke>();
            for (int i = 0; i < standin.Count; i++) {
                Stroke temp = standin[i];
                this.Strokes.Add(new CompressedStroke(temp));
            }
        }

        public int Section { get; set; }

        public int Owner { get; set; }

        public int Book { get; set; }

        public int Number { get; set; }

        public float X1 { get; set; }

        public float Y1 { get; set; }

        public float X2 { get; set; }

        public float Y2 { get; set; }

        public float MarginL { get; set; }

        public float MarginR { get; set; }

        public float MarginT { get; set; }

        public float MarginB { get; set; }
   
        public List<CompressedStroke> Strokes { get; set; }
    }
}
