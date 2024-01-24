using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GangSkinsCollectorF
{
    public class SummonerInfo
    {
        [JsonPropertyName("accountId")]
        public int? accountId { get; set; }

        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("gameName")]
        public string gameName { get; set; }

        [JsonPropertyName("internalName")]
        public string internalName { get; set; }

        [JsonPropertyName("nameChangeFlag")]
        public bool? nameChangeFlag { get; set; }

        [JsonPropertyName("percentCompleteForNextLevel")]
        public int? percentCompleteForNextLevel { get; set; }

        [JsonPropertyName("privacy")]
        public string privacy { get; set; }

        [JsonPropertyName("profileIconId")]
        public int? profileIconId { get; set; }

        [JsonPropertyName("puuid")]
        public string puuid { get; set; }

        [JsonPropertyName("rerollPoints")]
        public RerollPoints rerollPoints { get; set; }

        [JsonPropertyName("summonerId")]
        public int? summonerId { get; set; }

        [JsonPropertyName("summonerLevel")]
        public int? summonerLevel { get; set; }

        [JsonPropertyName("tagLine")]
        public string tagLine { get; set; }

        [JsonPropertyName("unnamed")]
        public bool? unnamed { get; set; }

        [JsonPropertyName("xpSinceLastLevel")]
        public int? xpSinceLastLevel { get; set; }

        [JsonPropertyName("xpUntilNextLevel")]
        public int? xpUntilNextLevel { get; set; }
        public class RerollPoints
        {
            [JsonPropertyName("currentPoints")]
            public int? currentPoints { get; set; }

            [JsonPropertyName("maxRolls")]
            public int? maxRolls { get; set; }

            [JsonPropertyName("numberOfRolls")]
            public int? numberOfRolls { get; set; }

            [JsonPropertyName("pointsCostToRoll")]
            public int? pointsCostToRoll { get; set; }

            [JsonPropertyName("pointsToReroll")]
            public int? pointsToReroll { get; set; }
        }
    }
}
