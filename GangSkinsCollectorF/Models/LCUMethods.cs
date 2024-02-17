using Newtonsoft.Json;
using PoniLCU;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PoniLCU.LeagueClient;


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
