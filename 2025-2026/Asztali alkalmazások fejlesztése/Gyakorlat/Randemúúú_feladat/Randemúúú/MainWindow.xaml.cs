using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Randemúúú
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            // Szöveges mezők ellenőrzése
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(TelephoneNumberTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || AgeInput.Value == null)
            {
                MessageBox.Show
                (
                    "Kérlek tölts ki minden mezőt!",
                    "Hiányzó adatok hibaüzenet",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return;
            }

            // Nem kiválasztás ellenőrzése
            if (MaleRadio.IsChecked != true && FemaleRadio.IsChecked != true)
            {
                MessageBox.Show
                (
                    "Kérlek válaszd ki a nemed!",
                    "Nem hibaüzenet",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }

            // Email formátum ellenőrzése
            if (!IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show
                (
                    "Érvénytelen email cím!",
                    "Email hibaüzenet",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return;
            }

            // Sikeres regisztráció
            MessageBox.Show
            (
                "Sikeres regisztráció! 💖",
                "Sikeres regisztráció üzenet",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            Application.Current.Shutdown();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}