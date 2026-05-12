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

namespace Konyvtar_Kezelo
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            sp_Megjelenites.Visibility = Visibility.Collapsed;
            sp_Hozzaadas.Visibility = Visibility.Visible;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (lb_Konyvek.SelectedItem != null)
            {
                lb_Konyvek.Items.Remove(lb_Konyvek.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text;
            string author = AuthorBox.Text;

            lb_Konyvek.Items.Add(title + " - " + author);

            TitleBox.Text = "";
            AuthorBox.Text = "";

            sp_Hozzaadas.Visibility = Visibility.Collapsed;
            sp_Megjelenites.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            TitleBox.Text = "";
            AuthorBox.Text = "";

            sp_Hozzaadas.Visibility = Visibility.Collapsed;
            sp_Megjelenites.Visibility = Visibility.Visible;
        }
    }
}