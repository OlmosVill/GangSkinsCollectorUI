using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using PoniLCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PoniLCU.LeagueClient;
using static System.Net.Mime.MediaTypeNames;
using ThirdParty.Json.LitJson;

namespace GangSkinsCollectorF
{
    public class LCUMethods
    {
        static LeagueClient leagueClient = new LeagueClient(credentials.cmd);
        public async static Task<List<SkinsCollections>> GetSkinsOfSummoner(int SummonerID)
        {
            var data2 = await leagueClient.Request(requestMethod.GET, "/lol-champions/v1/inventories/" + SummonerID + "/skins-minimal");
            List<SkinsCollections> Skinscolleciondata = JsonConvert.DeserializeObject<List<SkinsCollections>>(data2);
            return Skinscolleciondata;
        }
        public async static Task<SummonerInfo> GetSummonerID()
        {
            var data = await leagueClient.Request(requestMethod.GET, "lol-summoner/v1/current-summoner");
            SummonerInfo CurrentSummoner = JsonConvert.DeserializeObject<SummonerInfo>(data);
            return CurrentSummoner;
        }
        public async static Task<List<SkinsCollections>> GetSkinsOfSummonerInBSON(int SummonerID)
        {
            var data2 = await leagueClient.Request(requestMethod.GET, "/lol-champions/v1/inventories/" + SummonerID + "/skins-minimal");
            List<SkinsCollections> Skinscolleciondata = JsonConvert.DeserializeObject<List<SkinsCollections>>(data2);
            
            return Skinscolleciondata;

        }
    }
}
