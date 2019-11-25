using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neosmartpen.Net.Export_Import
{
    class Timeline
    {
        long ID { get; set; }

        String Name { get; set; }

        List<TimeMarker> TimeMarkers;
    }
}
