using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NyelviskolaLIB;

namespace NyelviskolaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore.InitCSV();
            cb_nyelv.ItemsSource = DataStore.Instance!.Nyelvek;
        }

        private void cb_nyelv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (cb_nyelv.SelectedItem as Nyelv)!.NyelvID;
            var tanarok = DataStore.Instance!.Tanarok.Where(x => x.NyelvID == id);
            cb_tanar.ItemsSource = tanarok;

            if (tanarok.Any())
            {
                cb_tanar.IsEnabled = true;
            }
            else
            {
                cb_tanar.IsEnabled = false;
                grid_adatok.Visibility = Visibility.Hidden;
                grid_adatok.Visibility = Visibility.Hidden;
            }
        }

        private void cb_tanar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tanar = cb_tanar.SelectedItem as Tanar;

            if (tanar == null)
            {
                grid_adatok.Visibility = Visibility.Hidden;
                return;
            }

            t_telefon.Text = tanar!.Telefon;
            t_email.Text = tanar!.Email;
            t_oradij.Text = tanar!.Oradij.ToString();
            chb_online.IsChecked = tanar!.Online;
            grid_adatok.Visibility = Visibility.Visible;
        }
    }
}