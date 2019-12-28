using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public class CompressedDot
    {
        /// <summary>
        /// Builds a Compressed Dot for Data Export with less Metadata
        /// </summary>
        public CompressedDot(Dot dot, byte timeDiff, int maxForce) {
            X = dot.X;
            Fx = dot.Fx;
            Y = dot.Y;
            Fy = dot.Fy;
            Twist = dot.Twist;
            TiltX = dot.TiltX;
            TiltY = dot.TiltY;
            this.Force = (float)dot.Force / (float)maxForce;
            DotType = (int) dot.DotType;
            TimeDiff = timeDiff;
        }
        public int X { get; set; }

        public int Fx { get; set; }

        public int Y { get; set; }

        public int Fy { get; set; }

        public int TiltX { get; set; }

        public int TiltY { get; set; }

        public int Twist { get; set; }

        /// <summary>
        /// Force that is applied to the pen while writing (is always a value between (0 - 1))
        /// </summary>
        public float Force { get; set; }

        public int DotType { get; set; }

        /*
         * time difference between two dots in miliseconds
         */
        public byte TimeDiff { get; set; }

    }
}
