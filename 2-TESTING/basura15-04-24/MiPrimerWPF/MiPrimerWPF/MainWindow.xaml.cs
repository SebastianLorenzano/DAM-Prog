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

namespace MiPrimerWPF
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

        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            bool state = CheckBoxMain.IsChecked.Value;
            CheckBoxMain.IsChecked = !state;
            ButtonMain.Content += "0";
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AlternateCheck(object sender, RoutedEventArgs e)
        {

        }
    }
}