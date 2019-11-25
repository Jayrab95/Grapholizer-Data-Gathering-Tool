using System;
using Neosmartpen.Net.Metadata.Model;
using Newtonsoft.Json;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public static class JsonFormatter { 
        ///<summary>
        ///Serializes the given ParticipantsMap into a json object
        ///</summary>
        public static String Format(System.Collections.Generic.Dictionary<String, Participant> ParticipantsMap) {
            String dataJson = "";
            foreach (String k in ParticipantsMap.Keys)
            {
               dataJson += JsonConvert.SerializeObject(new CompressedParticipant(ParticipantsMap[k]));
            }
            return dataJson;
        }
    }
}
