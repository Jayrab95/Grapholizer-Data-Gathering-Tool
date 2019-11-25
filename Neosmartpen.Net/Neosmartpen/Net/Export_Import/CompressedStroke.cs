using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neosmartpen.Net.Metadata.Model;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    class CompressedStroke
    {
        public CompressedStroke(Stroke stroke) {
            long lastTimeStamp = stroke.TimeStart;
            CompressedDots = new List<CompressedDot>();
            for (int i = 0; i < stroke.Count; i++) {
                Dot temp = stroke[i];
                byte timeDiff = (byte) (temp.Timestamp - lastTimeStamp);
                lastTimeStamp = temp.Timestamp;
                CompressedDots.Add(new CompressedDot(temp,timeDiff));
            }
            if (stroke.Count != 0)
            {
                TimeStart = stroke[0].Timestamp;
                TimeEnd = stroke[stroke.Count - 1].Timestamp;
            }
        }

        public long TimeStart { get; private set; }

        public long TimeEnd { get; private set; }

        public List<CompressedDot> CompressedDots { get; set; }

        /*private String CompressDot(Dot dot, byte timeDiff) {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(NumberToHexString(dot.X, 8));
            sBuilder.Append(NumberToHexString(dot.Y, 8));
            sBuilder.Append(NumberToHexString(dot.Fx, 8));
            sBuilder.Append(NumberToHexString(dot.Fy, 8));
            sBuilder.Append(NumberToHexString(dot.TiltX, 8));
            sBuilder.Append(NumberToHexString(dot.TiltY, 8));
            sBuilder.Append(NumberToHexString(dot.Force, 8));
            sBuilder.Append(NumberToHexString((int)dot.DotType, 8));
            sBuilder.Append(NumberToHexString(timeDiff, 2));
            return sBuilder.ToString();
        }

        private String NumberToHexString(int value, int hexLength)
        {
            string hexString = value.ToString("X");
            return fillUpRemainingSpace(hexString, hexLength - hexString.Length);
        }

        private String fillUpRemainingSpace(String hex, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                hex = "0" + hex;
            }
            return hex;
        }
        */
    }

}
