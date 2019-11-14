using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Neosmartpen.Net.obsolete
{
    class CompressedDot
    {
        public CompressedDot(Dot dot, byte TimeDifference) {
            //int result = Convert.ToInt32("0001", 16);
            //Console.WriteLine("Converted back the shit ::: " + result);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(NumberToHexString(dot.X, 8));
            sBuilder.Append(NumberToHexString(dot.Y, 8));
            sBuilder.Append(NumberToHexString(dot.Fx, 8));
            sBuilder.Append(NumberToHexString(dot.Fy, 8));
            sBuilder.Append(NumberToHexString(dot.TiltX, 8));
            sBuilder.Append(NumberToHexString(dot.TiltY, 8));
            sBuilder.Append(NumberToHexString(dot.Force, 8));
            sBuilder.Append(NumberToHexString((int)dot.DotType, 8));
            sBuilder.Append(NumberToHexString(TimeDifference, 2));
            HexString = sBuilder.ToString();
        }

        public Dot GetDot() {
            //TODO implement this function
            return new Dot();
        }
        public String HexString { get; private set; }

        private String NumberToHexString(int value, int hexLength) {
            string hexString = value.ToString("X");
            return fillUpRemainingSpace(hexString, hexLength - hexString.Length);
        }

        private String fillUpRemainingSpace(String hex, int amount) {
            for(int i = 0; i < amount; i++)
            {
               hex = "0" + hex;
            }
            return hex;
        }
    }
}
