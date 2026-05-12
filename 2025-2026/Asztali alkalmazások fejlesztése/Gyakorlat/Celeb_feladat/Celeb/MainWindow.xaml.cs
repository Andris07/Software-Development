using System.IO;
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

using Celeb_LIB;

namespace Celeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ember> emberek = new List<Ember>();

        void Feltoltes()
        {
            foreach (var fajlSor in File.ReadAllLines("hires.txt").Skip(1))
            {
                emberek.Add(new Ember(fajlSor));
            }
        }

        void Nemzetisegek()
        {
            var nemzetisegek = emberek.Select(x => x.Nemzetiseg).Distinct().Order();
            cb_Nemzetiseg.Items.Clear();
            cb_Nemzetiseg.ItemsSource = nemzetisegek;
            cb_Nemzetiseg.SelectedIndex = 0;
        }

        void VisszaAllitas()
        {
            tb_Nev.Text = string.Empty;
            cb_Foglalkozas.SelectedIndex = 0;
            cb_Nemzetiseg.SelectedIndex = 0;
            ch_Vilaghiru.IsChecked = false;
            rb_Ferfi.IsChecked = true;
            rb_No.IsChecked = false;
        }

        public MainWindow()
        {
            InitializeComponent();
            Feltoltes();
            Nemzetisegek();
        }

        private void bt_Rogzit_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Nev.Text == string.Empty)
            {
                MessageBox.Show("Adja meg a híres ember nevét!", "Hiba!");
            }

            // név;foglalkozás;nemzetiség;világhírű;nem
            // Török Ferenc;sportoló;magyar;igen;férfi
            string urlapAdat = $"{tb_Nev.Text};{cb_Foglalkozas.Text};{cb_Nemzetiseg.Text};{(ch_Vilaghiru.IsChecked == true ? "igen" : "nem")};{(rb_Ferfi.IsChecked == true ? "férfi" : "nő")}";
            File.AppendAllText("hires.txt", urlapAdat, Encoding.UTF8);

            VisszaAllitas();
        }

        private void bt_Megsem_Click(object sender, RoutedEventArgs e)
        {
            VisszaAllitas();
        }
    }
}