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

namespace Tej
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

        private void Milk35_Click(object sender, RoutedEventArgs e)
        {
            MilkBrush.ImageSource = new BitmapImage(new Uri("tej35.jpg", UriKind.Relative));
        }

        private void Milk28_Click(object sender, RoutedEventArgs e)
        {
            MilkBrush.ImageSource = new BitmapImage(new Uri("tej28.jpg", UriKind.Relative));
        }

        private void Milk15_Click(object sender, RoutedEventArgs e)
        {
            MilkBrush.ImageSource = new BitmapImage(new Uri("tej15.jpg", UriKind.Relative));
        }
    }
}