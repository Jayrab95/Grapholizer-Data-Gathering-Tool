using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neosmartpen.Net;
using Neosmartpen.Net.Metadata.Model;
using Neosmartpen.Net.Neosmartpen;
using Neosmartpen.Net.Neosmartpen.Net.Export_Import;

namespace PenDemo
{
    static class Program
    {
        /// <summary>
        /// The main starting point of this Application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            /*JsonFormatter json = new JsonFormatter();
            Dot dot = new Dot();
            dot.Fx = 2;
            dot.Fy = 2;
            dot.Timestamp = 20202020;
            Dot dot2 = new Dot();
            dot2.Fx = 2;
            dot2.Fy = 2;
            dot2.Timestamp = 20202025;

            Dot dot3 = new Dot();
            dot3.Fx = 2;
            dot3.Fy = 2;
            dot3.Timestamp = 20202025;

            Stroke stroke = new Stroke(1,1,1,1);
            stroke.Add(dot);
            stroke.Add(dot2);

            Stroke stroke2 = new Stroke(2, 2, 2, 2);
            stroke.Add(dot3);

            Page page = new Page();
            List<Stroke> strokes = new List<Stroke>();
            strokes.Add(stroke);
            strokes.Add(stroke2);
            page.Strokes = strokes;
            json.WritePage(page);*/

            Application.Run( new MainForm() );
        }
    }
}
