using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ChessApp
{
    /// <summary>
    /// Lógica de interacción para LoadGames.xaml
    /// </summary>
    public partial class LoadGames : Window
    {
        private User UserLogged { get; set; }
        private int Offset { get; set; } = 0;
        private int Limit { get; set; } = 15;
        private static SqlDatabase db => MainWindow.db;
        public ObservableCollection<GameSerialized> GameView { get; set; }
        private LoadGames()
        {
            InitializeComponent();

            // Ejemplo de datos
            GameView = new ObservableCollection<GameSerialized>();
            
        }

        public LoadGames(User userLogged) : this()
        {
            UserLogged = userLogged;
            FetchMoreGames();
        }

        private void FetchMoreGames()
        {
            var games = db.GetGamesWithUserId(UserLogged.codUser, Offset, Limit);
            var gamesSerialized = GameSerialized.Serialize(games);
            if (games != null)
            {
                GameView.Clear();
                Offset += gamesSerialized.Count;
                foreach (var game in gamesSerialized)
                {
                    GameView.Add(game);
                }
            }
            DataContext = this;
            int pageCount = Offset / Limit;
            labelCount.Content = $"{pageCount}";
        }

        private void ButtonRightArrow_Clicked(object sender, RoutedEventArgs e)
        {
            FetchMoreGames();
        }

        private void ButtonLeftArrow_Clicked(object sender, RoutedEventArgs e)
        {
            Offset -= 2 * Limit;
            if (Offset < 0)
                Offset = 0;
            FetchMoreGames();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(GameListView.ItemsSource);

            if (dataView != null)
            {
                dataView.Filter = item =>
                {
                    if (item is GameSerialized game)
                    {
                        return game.codGame.ToString().Contains(FilterTextBox.Text);
                    }
                    return false;
                };
                dataView.Refresh();
            }
        }

        private void GameListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GameListView.SelectedItem is GameSerialized game)
            {
                MessageBoxResult result = MessageBox.Show($"Game Code: {game.codGame}\nWhite Player Code: {game.codUserWhites}\nBlack Player Code: {game.codUserBlacks}\n " +
                    $"Do you want to load this game?", "Load Game", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var gameDeserialized = game.Deserialize();
                    MainWindow.SharedGame = gameDeserialized;
                    Close();
                }
                else if (result == MessageBoxResult.Cancel)
                    return;

            }
        }

        private void LoadGames_Closing(object sender, CancelEventArgs e)
        {
        }
    }
}
