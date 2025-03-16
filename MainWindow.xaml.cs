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
using static System.Net.Mime.MediaTypeNames;

namespace SzambevitelWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UjTextBox txtSzam;

        public MainWindow()
        {
            InitializeComponent();

            txtSzam = new()
            {
                Name = "txtSzam",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 23,
                Width = 120,
                Margin = new Thickness(10, 20, 0, 0),
                Text = "0"
            };
            Grid.SetRow(txtSzam, 0);
            foGrid.Children.Add(txtSzam);
        }

        void HozzaAd(int db)
        {
            bool jelolt = rdbtJelolt.IsChecked == true;

            for (int i = 0; i < db; i++)
            {
                CheckBox cb = new()
                {
                    Content = i + 1,
                    Name = $"cb_{i}",
                    Margin = new Thickness(3, 2.5, 0, 2.5),
                    IsChecked = jelolt
                };
                stckpnlKontener.Children.Add(cb);
            }
        }

        private void Generalas(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSzam.Text))
            {
                MessageBox.Show("Nem adtál meg számot!");
                return;
            }

            if (txtSzam.Text == "0")
            {
                MessageBox.Show("A szám nem lehet nulla!");
                return;
            }
            
            if (int.TryParse(txtSzam.Text, out int db))
            {
                stckpnlKontener.Children.Clear();
                HozzaAd(db);
            }
            else
            {
                MessageBox.Show("Nem megfelelő formátumban adtad meg!");
            }
        }
    }
}