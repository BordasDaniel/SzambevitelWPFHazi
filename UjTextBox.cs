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


namespace SzambevitelWPF
{
    public class UjTextBox : TextBox
    {
        public UjTextBox()
        {
            TextChanged += UjTextBox_TextChanged;
        }

        void UjTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            // Számokon kívül minden mást tilt.
            Regex minta = new(@"\D");

            // Referencia
            UjTextBox tbx = (sender as UjTextBox);

            // Kurzor pozíció elmentése
            int eredetiKurzorPozicio = tbx.SelectionStart;

            tbx.Text = minta.Replace(tbx.Text, "");

            // Kurzor pozíció visszaállítása
            tbx.SelectionStart = eredetiKurzorPozicio;
        }
    }
}
