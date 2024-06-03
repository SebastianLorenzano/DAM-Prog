using Model;
using System.ComponentModel;
using System.Windows;

namespace ChessApp
{
    /// <summary>
    /// Lógica de interacción para AddGames.xaml
    /// </summary>
    public partial class AddGames : Window
    {
        private SqlDatabase db => SqlDatabase.Instance;
        public AddGames()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (textEmail1.Text == "" || textEmail2.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            string email1 = textEmail1.Text;
            long codUser1 = db.GetCodUserWithEmail(textEmail1.Text);
            string email2 = textEmail2.Text;
            long codUser2 = db.GetCodUserWithEmail(textEmail2.Text);


            Game game = new Game()
            {
                codUserWhites = codUser1,
                codUserBlacks = codUser2,
                board = new Board().Fill(),
            };
            long result = db.AddGame(game);
            game.codGame = result;
            if (result > 0)
            {
                MessageBox.Show("Game created successfully... Initializating Game...");
                MainWindow.SharedGame = game;
                Close();
            }
            else
            {
                MessageBox.Show("Error adding Game");
            }
            
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddGames_Closing(object sender, CancelEventArgs e)
        {     
        }
    }
}
