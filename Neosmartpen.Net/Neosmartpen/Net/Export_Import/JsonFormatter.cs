using System;
using System.Collections.Generic;
using Neosmartpen.Net.Metadata.Model;
using Newtonsoft.Json;

namespace Neosmartpen.Net.Neosmartpen.Net.Export_Import
{
    public static class JsonFormatter { 
        ///<summary>
        ///Serializes the given ParticipantsMap into a json object
        ///</summary>
        public static String Format(Dictionary<String, Participant> ParticipantsMap, int maxForce) {
            List<CompressedParticipant> comParticipants = new List<CompressedParticipant>();
            foreach (String k in ParticipantsMap.Keys)
            {
               comParticipants.Add(new CompressedParticipant(ParticipantsMap[k], maxForce));
            }
            return JsonConvert.SerializeObject(comParticipants, Formatting.Indented); ;
        }

        public static Dictionary<String, Participant> Deformat(String json, int maxForce) {
            List<CompressedParticipant> cParts = JsonConvert.DeserializeObject<List<CompressedParticipant>>(json);
            Dictionary<String, Participant> participantsMap = new Dictionary<string, Participant>();
            foreach (CompressedParticipant cPart in cParts) {
                Participant part = new Participant(cPart, maxForce);
                participantsMap.Add(part.Id, part);
            }
            return participantsMap;
            
        }
    }
}
