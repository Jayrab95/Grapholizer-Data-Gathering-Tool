using Neosmartpen.Net.Neosmartpen.Net.Export_Import;
using System.Collections.Generic;

namespace Neosmartpen.Net.Metadata.Model
{
    /// <summary>
    /// A class representing a Page in metadata
    /// </summary>
    public class Page
	{

        public Page() {
            Strokes = new List<Stroke>();
        }

        public Page(CompressedPage cPage, int maxForce) {
            this.Owner = cPage.Owner;
            this.Book = cPage.Book;
            this.Section = cPage.Section;
            this.Number = cPage.Number;
            this.MarginR = cPage.MarginR;
            this.MarginL = cPage.MarginL;
            this.MarginB = cPage.MarginB;
            this.MarginT = cPage.MarginT;
            this.X1 = cPage.X1;
            this.X2 = cPage.X2;
            this.Y1 = cPage.Y1;
            this.Y2 = cPage.Y2;

            Strokes = new List<Stroke>();
            if (cPage.Strokes != null)
            {
                if (cPage.Strokes.Count > 0)
                {
                    foreach (CompressedStroke cStroke in cPage.Strokes)
                    {
                        this.Strokes.Add(new Stroke(cStroke,maxForce));
                    }
                }
            }
        }
        /// <summary>
        /// Section
        /// </summary>
        public int Section { get; set; }
        /// <summary>
        /// Owner
        /// </summary>
        public int Owner { get; set; }
        /// <summary>
        /// Book Code(NoteID)
        /// </summary>
        public int Book { get; set; }
        /// <summary>
        /// Page Number
        /// </summary>
        public int Number { get; set; }
		/// <summary>
		/// coord X1 (Start Point)
		/// </summary>
		public float X1 { get; set; }
		/// <summary>
		/// coord Y1 (Start Point)
		/// </summary>
		public float Y1 { get; set; }
		/// <summary>
		/// coord X2 (End Point)
		/// </summary>
		public float X2 { get; set; }
		/// <summary>
		/// coord Y2 (End Point)
		/// </summary>
		public float Y2 { get; set; }
		/// <summary>
		/// Crop Margin Left
		/// </summary>
		public float MarginL { get; set; }
		/// <summary>
		/// Crop Margin Right
		/// </summary>
		public float MarginR { get; set; }
		/// <summary>
		/// Crop Margin Top
		/// </summary>
		public float MarginT { get; set; }
		/// <summary>
		/// Crop Margin Bottom
		/// </summary>
		public float MarginB { get; set; }

        public List<Stroke> Strokes { get; set; }
    }
}
