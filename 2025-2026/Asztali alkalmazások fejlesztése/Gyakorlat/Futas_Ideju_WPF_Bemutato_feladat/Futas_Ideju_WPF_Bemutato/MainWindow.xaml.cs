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

namespace Futas_Ideju_WPF_Bemutato
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // AddButton(1, 1);
            // AddAllButtons();
        }

        /*
        void AddAllButtons()
        {
            area.Children.Clear();
            
            for (int i = 0; i < 9; i++)
            {
                AddButton(i / 3, i % 3);
            }
        }

        void AddButton(int i, int j)
        {
            var b = new Button();

            b.Content = "Test";

            area.Children.Add(b);
            Grid.SetColumn(b, j);
            Grid.SetRow(b, i);

            b.Click += B_Click;
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;

            if (b == null) return;

            int row = Grid.GetRow(b);
            int col = Grid.GetColumn(b);
            b.Content = $"Button: {row} {col}";

            (area.Children.Cast<UIElement>().First(x => Grid.GetRow(x) == 1 && Grid.GetColumn(x) == 1) as Button)!.Content = "Cica";
        }
        */

        void CreateDefinitions(int rows, int columns)
        {
            area.Children.Clear();
            area.RowDefinitions.Clear();

            for (int i = 0; i < rows; i++)
            {
                area.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < columns; i++)
            {
                area.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        void CreateLabel(int x, int y)
        {
            Label label = new Label()
            {
                Content = $"{x}, {y}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                MaxWidth = 100,
                Margin = new Thickness(3, 3, 3, 3)
            };

            if ((x + y)%2 == 0)
            {
                label.Background = Brushes.Black;
                label.Foreground = Brushes.White;
                label.BorderBrush = Brushes.White;
            }
            else
            {
                label.Background = Brushes.White;
                label.Foreground = Brushes.Black;
                label.BorderBrush = Brushes.Black;
            }

            label.BorderThickness = new Thickness(1);

            Grid.SetColumn(label, y);
            Grid.SetRow(label, x);
            area.Children.Add(label);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(rowCounts.Text);
            int columns = int.Parse(columnCounts.Text);

            area.Children.Clear();
            CreateDefinitions(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    CreateLabel(i, j);
                }
            }
        }
    }
}