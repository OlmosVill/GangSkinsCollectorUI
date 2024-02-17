using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GangSkinsCollectorF
{
    /// <summary>
    /// Interaction logic for DeleteData.xaml
    /// </summary>
    public partial class DeleteData : Window
    {
        public DeleteData()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void btnCloseModal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Task<SummonerInfo> SummonerID = LCUMethods.GetSummonerID();
            var ConM = new MongoClient("mongodb+srv://olmos:Lolcit0s@almosttesting.bz8a5nn.mongodb.net/");
            var db = ConM.GetDatabase("GangSkins");
            var collections = db.ListCollectionNames().ToList();
            string SumonersFinal = String.Concat(SummonerID.Result.displayName.Where(c => !Char.IsWhiteSpace(c)));
            string[] Summoners = SumonersFinal.ToLower().Split(',');
            try
            {
                if (collections.Contains(Summoners[0] + "Collection"))
                {
                    db.DropCollection(Summoners[0] + "Collection");
                }
                txbCompleated.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                txbCompleated.Visibility = Visibility.Visible;
                txbCompleated.Text = "Failed";
                throw;
            }
        }
    }
}
