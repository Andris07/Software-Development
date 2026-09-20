using LabdarugasLIB;
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

namespace LabdarugasGUI
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
            cb_torna.ItemsSource = DataStore.Instance!.Tornak;
        }

        private void cb_torna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var torna = cb_torna.SelectedItem as Torna;

            if (torna == null) return;

            var csapatok = DataStore.Instance!.Csapatok.Where(x => x.TornaID == torna.TornaID).ToList();
            cb_csapat.ItemsSource = csapatok;
            cb_csapat.DisplayMemberPath = "Nev";
            cb_csapat.IsEnabled = csapatok.Any();
            grid_adatok.Visibility = Visibility.Hidden;
            cb_csapat.SelectedItem = null;
        }

        private void cb_csapat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var csapat = cb_csapat.SelectedItem as Csapat;

            if (csapat == null) return;

            var edzo = DataStore.Instance!.Edzok.FirstOrDefault(x => x.EdzoID == csapat.EdzoID);

            if (edzo == null)
            {
                grid_adatok.Visibility = Visibility.Hidden;
                return;
            }

            t_tornapontok.Text = csapat.TornaPontok.ToString();
            t_trofeak.Text = csapat.Trofeak.ToString();
            t_edzonev.Text = edzo.Nev;
            t_edzoev.Text = edzo.EvekSzama.ToString();
            t_edzotrofea.Text = edzo.Trofeak.ToString();
            t_edzoosszbevetel.Text = edzo.OsszBevetel.ToString("N0");
            grid_adatok.Visibility = Visibility.Visible;
        }
    }
}