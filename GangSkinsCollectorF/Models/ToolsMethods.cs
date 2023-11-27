using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangSkinsCollectorF.Models
{
    public class ToolsMethods
    {
        public static List<SkinsCollectionFull> TransformSC(List<SkinsCollections>O1)
        {
            var ConM = new MongoClient("mongodb+srv://olmos:Lolcit0s@almosttesting.bz8a5nn.mongodb.net/");
            var db = ConM.GetDatabase("GangSkins");
            var SummonerCollection = db.GetCollection<Skins>("Skins");
            List<Skins> AllSkins = SummonerCollection.Find(x => true).ToList();
            List<SkinsCollectionFull> FullList = new List<SkinsCollectionFull>();
            for (int i = 0; i < AllSkins.Count; i++)
            {
                if (O1[i].name == AllSkins[i].skinchampkey.name)
                {
                    foreach (var obj in O1)
                    {
                        SkinsCollectionFull item = new SkinsCollectionFull();
                        item.championId = obj.championId;
                        item.chromaPath = obj.chromaPath;
                        item.disabled = obj.disabled;
                        item.id = obj.id;
                        item.isBase = obj.isBase;
                        item.lastSelected = obj.lastSelected;
                        item.name = obj.name;
                        item.owned = obj.ownership.loyaltyReward;
                        item.splashPath = obj.splashPath;
                        item.stillObtainable = obj.stillObtainable;
                        item.tilePath = obj.tilePath;
                        if (AllSkins[i].skinchampkey.skinLines != null)
                        {
                            item.skinLines = AllSkins[i].skinchampkey.skinLines[0].id;
                        }
                    }
                }
            }
            return FullList;
        }
    }
}
