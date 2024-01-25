using GangSkinsCollectorF.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;



namespace GangSkinsCollectorF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string logPath = System.IO.Directory.GetCurrentDirectory();
        
        public MainWindow()
        {
            InitializeComponent();
            CreateLog();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
            sendSpn.Visibility = Visibility.Visible;
            txbCompleated.Visibility = Visibility.Visible;
            txbCompleated.Text = "Wait";
            using (StreamWriter w = File.AppendText(logPath + "\\" + "log.txt"))
            {
                try
                {

                    Task<SummonerInfo> SummonerID = LCUMethods.GetSummonerID();
                    Log("GetSummonerInfo from LCU", w);
                    Task<List<SkinsCollections>> SkinsOfSummoner = LCUMethods.GetSkinsOfSummoner(SummonerID.Result.summonerId.GetValueOrDefault());
                    Log("Get SkinstOfSummoner LCU", w);
                    var ConM = new MongoClient(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    var db = ConM.GetDatabase("GangSkins");
                    Log("Det DB From GangSkins", w);
                    var collections = db.ListCollectionNames().ToList();
                    Log("Get CollectionNames List from Mongo", w);

                    if (collections.Contains(SummonerID.Result.displayName + "Collection"))
                    {
                        db.DropCollection(SummonerID.Result.displayName + "Collection");
                    }
                    db.CreateCollection(SummonerID.Result.displayName + "Collection");
                    Log("New collecionsummoner created", w);
                    string SumonerFinal = String.Concat(SummonerID.Result.displayName.Where(c => !Char.IsWhiteSpace(c))); ;
                    var SummonerCollection = db.GetCollection<BsonDocument>(SumonerFinal.ToLower() + "Collection");
                    Task<List<SkinsCollections>> BsonmToInstert = LCUMethods.GetSkinsOfSummonerInBSON(SummonerID.Result.summonerId.GetValueOrDefault());
                    Log("GetSkinsOfSummonerInBSON compleated", w);
                    List<SkinsCollectionFull> SCFull = ToolsMethods.TransformSC(BsonmToInstert.Result);
                    List<BsonDocument> ListOfBsons = new List<BsonDocument>();
                    foreach (var item in SCFull)
                    {
                        string jsonString = JsonSerializer.Serialize(item);
                        BsonDocument onebson = BsonDocument.Parse(jsonString);
                        ListOfBsons.Add(onebson);
                    }
                    await SummonerCollection.InsertManyAsync(ListOfBsons);
                    sendSpn.Visibility = Visibility.Collapsed;
                    txbCompleated.Visibility = Visibility.Visible;
                    txbCompleated.Text = "Completed";
                    txbCompleated.Padding = new Thickness(0, 20, 0, 0);
                    Style txtOnline = Application.Current.FindResource("LeagueOnlineText") as Style;
                    txbCompleated.Style = txtOnline;
                    Log("DB Creada", w);
                }
                catch (Exception error)
                {
                    sendSpn.Visibility = Visibility.Hidden;
                    txbCompleated.Visibility = Visibility.Visible;
                    txbLog.Visibility = Visibility.Visible;
                    txbCompleated.Text = (error.Message == "Not connected to LCU") ? "Maybe you dont opened yout lol ¬¬" : "Maybe you dont opened yout lol ¬¬";
                    txbCompleated.Padding = new Thickness(0, 0, 0, 0);
                    Style txtOnline = Application.Current.FindResource("LeagueBusyText") as Style;
                    txbCompleated.Style = txtOnline;
                    Log(error.Message, w);
                }
            }
            btnSend.IsEnabled = true;
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            InfoModal modal = new InfoModal();
            modal.Owner = this;
            modal.ShowDialog();         
        }
        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(logPath + "\\" + "log.txt")
            {
                UseShellExecute = true
            };
            p.Start();
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
        public void CreateLog()
        {
            try
            {
                if (File.Exists(logPath + "\\" + "log.txt"))
                {
                    File.Delete(logPath + "\\" + "log.txt");
                }
                using (FileStream fs = File.Create(logPath + "\\" + "log.txt"))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("Created at: " + DateTime.Today.ToString());
                    fs.Write(title, 0, title.Length);              
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        
        private void LlamarModalClick(object sender, RoutedEventArgs e)
        {
            InfoModal modal = new InfoModal();
            modal.Owner = this;
            modal.ShowDialog();
        }
    }
}
