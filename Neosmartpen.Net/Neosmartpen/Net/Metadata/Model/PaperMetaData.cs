using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Neosmartpen.Net.Metadata.Model
{
    class PaperMetaData
    {
        public PaperInformation IdeaPad = new PaperInformation("Idea Pad", 609, 595.275f, 771.023f, 36.8503f, 107.716f);
        public PaperInformation RingNote = new PaperInformation("RingNote", 603, 425.196f, 595.275f, 36.8503f, 36.8503f);
        public PaperInformation IdeaPadMini = new PaperInformation("Idea Pad Mini", 620, 360f, 566.929f, 36.8503f, 36.8503f);
        public PaperInformation A4 = new PaperInformation("A4", 0, 595f, 842f, 0f, 0f);
        public PaperInformation CollegeNote = new PaperInformation("College Note", 617, 612.283f, 793.7f, 36.8503f, 36.8503f);
        public PaperInformation PlainNote = new PaperInformation("Plain Note", 604, 498.897f, 708.661f, 36.8503f, 36.8503f);
    }
    public class PaperInformation
    {
        public string Title;
        public float Width, Height, OffsetX, OffsetY;
        public int BookId;

        public PaperInformation(string title, int bookId, float width, float height, float offsetx, float offsety)
        {
            Title = title;
            BookId = bookId;
            Width = width;
            Height = height;
            OffsetX = offsetx;
            OffsetY = offsety;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
