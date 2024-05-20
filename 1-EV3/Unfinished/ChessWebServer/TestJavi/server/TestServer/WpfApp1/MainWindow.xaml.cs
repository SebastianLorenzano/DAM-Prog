using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://localhost:5005/login";

            var login = new Login();
            login.username = "Ana";
            login.password = "123";

            string json = JsonSerializer.Serialize(login);

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var contenido = new StringContent(json, Encoding.UTF8, "application/json");
                    var respuesta = await httpClient.PostAsync(url, contenido);
                    string respuestaString = await respuesta.Content.ReadAsStringAsync();
                    var session = JsonSerializer.Deserialize<Session>(respuestaString);
                    MessageBox.Show(respuestaString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
