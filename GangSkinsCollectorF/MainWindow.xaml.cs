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

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
            sendSpn.Visibility = Visibility.Visible;
            txbCompleated.Visibility = Visibility.Visible;
            txbCompleated.Text = "Wait";
            try
            {

                Task<SummonerInfo> SummonerID = LCUMethods.GetSummonerID();
                Task<List<SkinsCollections>> SkinsOfSummoner = LCUMethods.GetSkinsOfSummoner(SummonerID.Result.summonerId.GetValueOrDefault());
                string SumonerFinal = String.Concat(SummonerID.Result.displayName.Where(c => !Char.IsWhiteSpace(c)));
                var ConM = new MongoClient(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                var db = ConM.GetDatabase("GangSkins");
                var collections = db.ListCollectionNames().ToList();
                if (collections.Contains(SumonerFinal.ToLower() + "Collection"))
                {
                    db.DropCollection(SumonerFinal.ToLower() + "Collection");
                }
                var SummonerCollection = db.GetCollection<BsonDocument>(SumonerFinal.ToLower() + "Collection");
                db.CreateCollection(SumonerFinal.ToLower() + "Collection");
                Task<List<SkinsCollections>> BsonmToInstert = LCUMethods.GetSkinsOfSummonerInBSON(SummonerID.Result.summonerId.GetValueOrDefault());
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
            }

            btnSend.IsEnabled = true;
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            InfoModal modal = new InfoModal();
            modal.Owner = this;
            modal.ShowDialog();
        }
        private void LlamarModalClick(object sender, RoutedEventArgs e)
        {
            InfoModal modal = new InfoModal();
            modal.Owner = this;
            modal.ShowDialog();
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            DeleteData modal = new DeleteData();
            modal.Owner = this;
            modal.ShowDialog();
        }
    }
}
