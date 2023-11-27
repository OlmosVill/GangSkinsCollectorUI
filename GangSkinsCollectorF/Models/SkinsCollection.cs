using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GangSkinsCollectorF
{
    public class SkinsCollections
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

        [JsonPropertyName("ownership")]
        public Ownership ownership { get; set; }

        [JsonPropertyName("splashPath")]
        public string splashPath { get; set; }

        [JsonPropertyName("stillObtainable")]
        public bool? stillObtainable { get; set; }

        [JsonPropertyName("tilePath")]
        public string tilePath { get; set; }

        // SkinsCollections myDeserializedClass = JsonSerializer.Deserialize<List<SkinsCollections>>(myJsonResponse);
        public class Ownership
        {
            [JsonPropertyName("loyaltyReward")]
            public bool? loyaltyReward { get; set; }

            [JsonPropertyName("owned")]
            public bool? owned { get; set; }

            [JsonPropertyName("rental")]
            public Rental rental { get; set; }

            [JsonPropertyName("xboxGPReward")]
            public bool? xboxGPReward { get; set; }
        }

        public class Rental
        {
            [JsonPropertyName("endDate")]
            public int? endDate { get; set; }

            [JsonPropertyName("purchaseDate")]
            public object purchaseDate { get; set; }

            [JsonPropertyName("rented")]
            public bool? rented { get; set; }

            [JsonPropertyName("winCountRemaining")]
            public int? winCountRemaining { get; set; }
        }

    }
}
