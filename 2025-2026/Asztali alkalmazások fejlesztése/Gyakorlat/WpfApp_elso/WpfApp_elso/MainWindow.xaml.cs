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

namespace WpfApp_elso
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // button.Background = Brushes.Navy;
            listBox.Items.Clear();
            listBox.Items.Add("Application - info");
            listBox.Items.Add(Application.Current);
            listBox.Items.Add(Application.Current.MainWindow.Title);
            listBox.Items.Add(Application.Current.Windows);
            listBox.Items.Add(Application.Current.Windows);
            listBox.Items.Add(Application.Current.Windows.Count);
            listBox.Items.Add(Application.Current.StartupUri);
            Application.Current.Properties["Allat"] = "Tigris";
            Application.Current.Properties["Nev"] = "LAG";
            listBox.Items.Add(Application.Current.Properties.Count);

            foreach (var property in Application.Current.Properties)
            {
                listBox.Items.Add(property);
            }
        }
    }
}