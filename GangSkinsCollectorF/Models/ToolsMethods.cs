using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;



namespace GangSkinsCollectorF.Models
{
    public class ToolsMethods
    {
        public static List<SkinsCollectionFull> TransformSC(List<SkinsCollections> O1)
        {
            var ConM = new MongoClient(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); ;
            var db = ConM.GetDatabase("GangSkins");
            var SummonerCollection = db.GetCollection<Skins>("Skins"); ;
            if (O1[1].name.Contains("Goth"))
                SummonerCollection =  db.GetCollection<Skins>("SkinsEN");
            if (O1[1].name.Contains("Gótica"))
                SummonerCollection = db.GetCollection<Skins>("SkinsES");

            List<Skins> AllSkins = SummonerCollection.Find(x => true).ToList();
            List<SkinsCollectionFull> FullList = new List<SkinsCollectionFull>();
            try
            {
                foreach (var obj1 in O1)
                {
                    foreach (var obj2 in AllSkins)
                    {
                        if (obj2.skinkey == null)
                        {
                            break;
                        }
                        if (obj2.skinchampkey.name == obj1.name)
                        {
                            SkinsCollectionFull item = new SkinsCollectionFull();
                            item.championId = obj1.championId;
                            item.chromaPath = obj1.chromaPath;
                            item.disabled = obj1.disabled;
                            item.id = obj1.id;
                            item.isBase = obj1.isBase;
                            item.lastSelected = obj1.lastSelected;
                            item.name = obj1.name;
                            item.owned = obj1.ownership.owned;
                            item.splashPath = obj1.splashPath;
                            item.stillObtainable = obj1.stillObtainable;
                            item.tilePath = obj1.tilePath;
                            if (obj2.skinchampkey.skinLines != null)
                            {
                                item.skinLines = obj2.skinchampkey.skinLines[0].idSkinlines;
                            }
                            FullList.Add(item);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }     
            return FullList;
        }
    }
}
