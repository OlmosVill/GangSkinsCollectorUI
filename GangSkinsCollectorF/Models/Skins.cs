using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GangSkinsCollectorF.Models
{
    public class Skins
    {
        [JsonPropertyName("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId IdChampion { get; set; }

        [JsonPropertyName("skinkey")]
        public int? skinkey { get; set; }

        [JsonPropertyName("skinchampkey")]
        public Skinchampkey skinchampkey { get; set; }

        [BsonIgnoreExtraElements]
        public class Chroma
        {
            [JsonPropertyName("idChromaSkin")]
            public int? idChromaSkin { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("chromaPath")]
            public string chromaPath { get; set; }

            [JsonPropertyName("colors")]
            public List<string> colors { get; set; }

            [JsonPropertyName("descriptions")]
            public List<Description> descriptions { get; set; }

            [JsonPropertyName("rarities")]
            public List<Rarity> rarities { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class Description
        {
            [JsonPropertyName("region")]
            public string region { get; set; }

            [JsonPropertyName("description")]
            public string description { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class DescriptionInfo
        {
            [JsonPropertyName("title")]
            public string title { get; set; }

            [JsonPropertyName("description")]
            public string description { get; set; }

            [JsonPropertyName("iconPath")]
            public string iconPath { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class QuestSkinInfo
        {
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("productType")]
            public string productType { get; set; }

            [JsonPropertyName("collectionDescription")]
            public string collectionDescription { get; set; }

            [JsonPropertyName("descriptionInfo")]
            public List<DescriptionInfo> descriptionInfo { get; set; }

            [JsonPropertyName("splashPath")]
            public string splashPath { get; set; }

            [JsonPropertyName("uncenteredSplashPath")]
            public string uncenteredSplashPath { get; set; }

            [JsonPropertyName("tilePath")]
            public string tilePath { get; set; }

            [JsonPropertyName("collectionCardPath")]
            public string collectionCardPath { get; set; }

            [JsonPropertyName("tiers")]
            public List<Tier> tiers { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class Rarity
        {
            [JsonPropertyName("region")]
            public string region { get; set; }

            [JsonPropertyName("rarity")]
            public int? rarity { get; set; }
        }

        
        public class Skinchampkey
        {
            [JsonPropertyName("idSC")]
            public int? idSC { get; set; }

            [JsonPropertyName("isBase")]
            public bool? isBase { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("splashPath")]
            public string splashPath { get; set; }

            [JsonPropertyName("uncenteredSplashPath")]
            public string uncenteredSplashPath { get; set; }

            [JsonPropertyName("tilePath")]
            public string tilePath { get; set; }

            [JsonPropertyName("loadScreenPath")]
            public string loadScreenPath { get; set; }

            [JsonPropertyName("skinType")]
            public string skinType { get; set; }

            [JsonPropertyName("rarity")]
            public string rarity { get; set; }

            [JsonPropertyName("isLegacy")]
            public bool? isLegacy { get; set; }

            [JsonPropertyName("splashVideoPath")]
            public string splashVideoPath { get; set; }

            [JsonPropertyName("collectionSplashVideoPath")]
            public string collectionSplashVideoPath { get; set; }

            [JsonPropertyName("featuresText")]
            public string featuresText { get; set; }

            [JsonPropertyName("chromaPath")]
            public string chromaPath { get; set; }

            [JsonPropertyName("emblems")]
            public object emblems { get; set; }

            [JsonPropertyName("regionRarityId")]
            public int? regionRarityId { get; set; }

            [JsonPropertyName("rarityGemPath")]
            public object rarityGemPath { get; set; }

            [JsonPropertyName("skinLines")]
            public List<SkinLine> skinLines { get; set; }

            [JsonPropertyName("skinAugments")]
            public object skinAugments { get; set; }

            [JsonPropertyName("description")]
            public string description { get; set; }

            [JsonPropertyName("loadScreenVintagePath")]
            public string loadScreenVintagePath { get; set; }

            [JsonPropertyName("chromas")]
            public List<Chroma> chromas { get; set; }

            [JsonPropertyName("questSkinInfo")]
            public QuestSkinInfo questSkinInfo { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class SkinLine
        {
            [JsonPropertyName("idSkinlines")]
            public int? idSkinlines { get; set; }

            [JsonPropertyName("id")]
            public int? id { get; set; }
        }
        [BsonIgnoreExtraElements]
        public class Tier
        {
            [JsonPropertyName("id")]
            public int? id { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("stage")]
            public int? stage { get; set; }

            [JsonPropertyName("description")]
            public string description { get; set; }

            [JsonPropertyName("splashPath")]
            public string splashPath { get; set; }

            [JsonPropertyName("uncenteredSplashPath")]
            public string uncenteredSplashPath { get; set; }

            [JsonPropertyName("tilePath")]
            public string tilePath { get; set; }

            [JsonPropertyName("loadScreenPath")]
            public string loadScreenPath { get; set; }

            [JsonPropertyName("loadScreenVintagePath")]
            public string loadScreenVintagePath { get; set; }

            [JsonPropertyName("shortName")]
            public string shortName { get; set; }

            [JsonPropertyName("splashVideoPath")]
            public string splashVideoPath { get; set; }

            [JsonPropertyName("collectionSplashVideoPath")]
            public string collectionSplashVideoPath { get; set; }

            [JsonPropertyName("skinAugments")]
            public object skinAugments { get; set; }
        }
    }
}
