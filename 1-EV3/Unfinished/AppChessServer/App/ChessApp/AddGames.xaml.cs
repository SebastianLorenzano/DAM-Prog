using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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


            GameDB game = new GameDB()
            {
                codUserWhites = codUser1,
                codUserBlacks = codUser2,
                Board = new Board().Fill(),
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

        private void SecondaryWindow_Closing(object sender, CancelEventArgs e)
        {     
        }
    }
}
