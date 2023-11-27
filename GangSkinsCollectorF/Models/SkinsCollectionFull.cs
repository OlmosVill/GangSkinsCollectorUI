using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GangSkinsCollectorF.Models
{
    public class SkinsCollectionFull
    {

        [JsonPropertyName("championId")]
        public int? championId { get; set; }

        [JsonPropertyName("chromaPath")]
        public string chromaPath { get; set; }

        [JsonPropertyName("disabled")]
        public bool? disabled { get; set; }

        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("isBase")]
        public bool? isBase { get; set; }

        [JsonPropertyName("lastSelected")]
        public bool? lastSelected { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }


        [JsonPropertyName("splashPath")]
        public string splashPath { get; set; }

        [JsonPropertyName("stillObtainable")]
        public bool? stillObtainable { get; set; }

        [JsonPropertyName("tilePath")]
        public string tilePath { get; set; }

        [JsonPropertyName("skinLines")]
        public int? skinLines { get; set; }

        [JsonPropertyName("owned")]
        public bool? owned { get; set; }

        // SkinsCollections myDeserializedClass = JsonSerializer.Deserialize<List<SkinsCollections>>(myJsonResponse);


    }
}
