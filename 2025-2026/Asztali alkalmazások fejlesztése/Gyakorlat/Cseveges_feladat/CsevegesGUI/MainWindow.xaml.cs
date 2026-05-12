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
using Cseveges;

namespace CsevegesGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListakInicializalasaTxtAlapjan("csevegesek.txt", 1);
            KezdemenyezoComboInicializalas();
            FogadoComboInicializalas();
        }

        private List<string> kezdemenyezok_ABC_Sorrendben;
        private List<string> fogadok_ABC_Sorrendben;
        private Beszelgetesek csevegesek;

        private void CsevegesekInicializalasa()
        {
            CsevegesekListBox.Items.Clear();

            string kezdemenyezo = (cbKezdemenyezo.SelectedItem as string)!;
            string fogado = (cbFogado.SelectedItem as string)!;

            if (cbKezdemenyezo.SelectedItem == null || cbFogado.SelectedItem == null) return;

            List<string> beszelgetesek = csevegesek.RendezettBeszelgetesek.Where(x => (x.Kezdemenyezo == kezdemenyezo && x.Fogado==fogado) || (x.Fogado==kezdemenyezo && x.Kezdemenyezo==fogado)).Select(x => $"{x.Kezdet} --> {x.Veg}").ToList();
            
            foreach(string beszelgetes in beszelgetesek)
            {
                CsevegesekListBox.Items.Add($"{CsevegesekListBox.Items.Count + 1}. " + beszelgetes);
            }
            if (CsevegesekListBox.Items.Count == 0)
            {
                CsevegesekListBox.Items.Add("Nem történt beszélgetés!");
            }
        }

        private void ListakInicializalasaTxtAlapjan(string fajlNev, int kihagyas)
        {
            csevegesek = new Beszelgetesek(File.ReadAllLines(fajlNev).Skip(kihagyas));
            kezdemenyezok_ABC_Sorrendben = csevegesek.BeszelgetoKezdemenyezok.Order().ToList();
            fogadok_ABC_Sorrendben = csevegesek.BeszelgetoFogadok.Order().ToList();
        }

        private void KezdemenyezoComboInicializalas()
        {
            cbKezdemenyezo.Items.Clear();

            foreach(var kezdemenyezo in kezdemenyezok_ABC_Sorrendben)
            {
                cbKezdemenyezo.Items.Add(kezdemenyezo);
            }
            cbKezdemenyezo.SelectedIndex = 0;
        }

        private void FogadoComboInicializalas()
        {
            cbFogado.Items.Clear();

            foreach (var fogado in fogadok_ABC_Sorrendben)
            {
                cbFogado.Items.Add(fogado);
            }
            cbFogado.SelectedIndex = fogadok_ABC_Sorrendben.Count() - 1;
        }

        private void Cseveges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CsevegesekInicializalasa();
        }
    }
}