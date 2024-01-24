using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace GangSkinsCollectorF
{
    /// <summary>
    /// Interaction logic for InfoModal.xaml
    /// </summary>
    public partial class InfoModal : Window
    {
        public InfoModal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void hyperlink_requestnavigate(object sender, RequestNavigateEventArgs e)
        {
            using (Process compiler = new Process())
            {
                e.Handled = true;
                compiler.StartInfo.UseShellExecute = true;
                compiler.StartInfo.FileName = e.Uri.AbsoluteUri.ToString();
                compiler.Start();
            }
        }
    }
}
