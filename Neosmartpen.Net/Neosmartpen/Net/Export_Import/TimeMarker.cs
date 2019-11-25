using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    class TimeMarker
    {
        String Tag { get; set; }

        String Comment { get; set; }

        long StartTimeStamp { get; set; }

        long EndTimeStamp { get; set; }

        public long GetDurationInMiliSecond() {
            return EndTimeStamp - StartTimeStamp;
        }
    }
}
