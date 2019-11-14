using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neosmartpen.Net.Metadata.Model;
using Newtonsoft.Json;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public class JsonFormatter { 
        public String Format(Page page) {
            return JsonConvert.SerializeObject(new CompressedPage(page));
        }
    }
}
