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
using Tanacsado_LIB;

namespace TanacsadoGUI
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
            cb_szakterulet.ItemsSource = DataStore.Instance!.Szakteruletek.OrderBy(x => x.Megnevezes).ToList();
        }

        private void cb_szakterulet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (cb_szakterulet.SelectedItem as Szakterulet)!.ID;
            var tanacsadok = DataStore.Instance!.Tanacsadok.Where(x => x.SzakteruletID == id);
            cb_tanacsado.ItemsSource = tanacsadok.OrderBy(x => x.Nev).ToList();

            if (tanacsadok.Any())
            {
                cb_tanacsado.IsEnabled = true;
            }
            else
            {
                cb_tanacsado.IsEnabled = false;
            }
        }

        private void cb_tanacsado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tanacsado = (cb_tanacsado.SelectedItem as Tanacsado);

            if (tanacsado is null)
            {
                return;
            }
            else
            {
                tb_telefon.Text = tanacsado.Telefon;
                tb_email.Text = tanacsado.Email;
                tb_oradij.Text = tanacsado.Oradij.ToString();
            }
        }
    }
}