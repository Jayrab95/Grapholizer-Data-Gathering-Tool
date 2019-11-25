using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Export_Import
{
    class CompressedDot
    {
        public CompressedDot(Dot dot, byte timeDiff) {
            X = dot.X;
            Fx = dot.Fx;
            Y = dot.Y;
            Fy = dot.Fy;
            TiltX = dot.TiltX;
            TiltY = dot.TiltY;
            Force = dot.Force;
            DotType = (int) dot.DotType;
            TimeDiff = timeDiff;
        }
        public int X { get; set; }

        public int Fx { get; set; }

        public int Y { get; set; }

        public int Fy { get; set; }

        public int TiltX { get; set; }

        public int TiltY { get; set; }

        public int Force { get; set; }

        public int DotType { get; set; }

        /*
         * time difference between two dots in miliseconds
         */
        public byte TimeDiff { get; set; }

    }
}
