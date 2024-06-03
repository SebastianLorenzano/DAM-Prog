using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Model;

namespace ChessApp
{
    public partial class MainWindow : Window
    {
        private User? _userLogged; 
        private const string connectionString = "Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;";
        public static SqlDatabase db = SqlDatabase.Instance;
        private readonly Image[,] _images = new Image[8, 8];
        private Rectangle[,] _highlights = new Rectangle[8,8];

        private Game game;    // Instance for DB
        private Position _selectedPosition;
        private List<Position> _possibleMoves = new List<Position>();   // Possible moves for the selected piece
        private Board Board => game.board;

        internal static Game? SharedGame { get; set;}

        public MainWindow()
        {
            game = new Game() { codGame = -1, codUserBlacks = -1, codUserWhites = -1, board = new Board() { Turn = 0 } };
            SqlDatabase.CreateSimpleton(connectionString);
            InitializeComponent();
            InitializeBoard();
            DrawUI();
            game.board = new Board().Fill();
            DrawBoard();
        }

        public void DrawUI()
        {
            textTurnNum.Text = "Turn: " + game.board.Turn;
            textTurnName.Text = "Goes: " + Board.GetCurrentPlayer();
        }
        public void InitializeBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var image = new Image();        // Initializes image
                    _images[x, y] = image;
                    TilesGrid.Children.Add(image);

                    var highlight = new Rectangle();   // Initializes highlight
                    _highlights[y, x] = highlight;
                    HighlightsGrid.Children.Add(highlight);
                }
            }
        }

        public void DrawBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var piece = Board[x, y];
                    _images[y, x].Source = Images.GetImage(piece);
                }
            }
            DrawUI();
        }

        internal void SetGame(Game game)
        {
           this.game = game;
            DrawBoard();
        }
        private void SavePossibleMoves(List<Position> positions) // Sets _possibleMoves to the positions given, as long as they are valid
        {
            _possibleMoves.Clear();
            foreach (var p in positions)
            {
                if (p != null && p.IsInBoard())
                    _possibleMoves.Add(p);
            }
        }

        private void ShowHighlights()
        {
            Color color = Colors.LightGreen;
            foreach (var p in _possibleMoves)
                _highlights[p.X, p.Y].Fill = new SolidColorBrush(color);
        }

        private void HideHighlights()
        {
            foreach (var p in _possibleMoves)
                _highlights[p.X, p.Y].Fill = Brushes.Transparent;
        }

        private Position ToSquarePosition(Point point)
        {
            double tileWidth = BoardGrid.Width / 8;
            int x = (int)(point.X / tileWidth);       // Chess is 8 x 8 tiles, width = height
            int y = (int)(point.Y / tileWidth);
            return new Position(x, y);
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(BoardGrid);
            Position position = ToSquarePosition(point);
            if (_selectedPosition == null)
                SelectPieceInPosition(position);
            else
                MovePieceToPosition(position);

        }

        private void SelectPieceInPosition(Position position)
        {
            _possibleMoves.Clear();
            var piece = Board.GetPieceWithPosition(position);
            if (piece == null || piece.Color != Board.GetCurrentPlayer())
                return;
            var possibleMoves = piece.GetPosiblePositions(Board);
            var legalMoves = Board.GetLegalMovements(piece, possibleMoves);
            if (possibleMoves.Count > 0)
            {
                _selectedPosition = position;
                SavePossibleMoves(possibleMoves);
                ShowHighlights();
            }
        }

        private void MovePieceToPosition(Position position)
        {
            
            HideHighlights();
            foreach (var p in _possibleMoves)
            {
                if (p == position)
                {
                    HandleMove(_selectedPosition, position);
                    _selectedPosition = null;
                    return;
                }
            }
            _selectedPosition = null;
        }

        private void HandleMove(Position selectedPos, Position goToposition)
        {
            Board.MakeMove(selectedPos, goToposition);
            DrawBoard();
        }

        private void buttonNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddUsers addUsers = new AddUsers();
            addUsers.ShowDialog();
        }

        private void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (_userLogged == null || _userLogged.codUser <= 0)
            {
                MessageBox.Show("You must be logged in to create a game");
                return;
            }
            if (!Board.wasSaved)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the game?", "Save game", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                    SaveGameButton_Click(null, null);       // Uploads the game to the DB
                else if (result == MessageBoxResult.Cancel)
                    return;
            }
            AddGames addGamesWindow = new AddGames();
            addGamesWindow.Closed += LoadGameFromOtherWindow; // Subscribe to Closed event
            addGamesWindow.Show();
        }
        private void LoadGameFromOtherWindow(object sender, EventArgs e)
        {
            if (SharedGame != null)
            {
                game = SharedGame;
                DrawBoard();
                SharedGame = null;
                MessageBox.Show("Game was loaded successfully");
            }
            else
            {
                MessageBox.Show("No game was loaded.");
            } 
        }

        private void buttonLoadUser_Click(object sender, RoutedEventArgs e)
        {
            if (_userLogged == null)
                UserLogin();
            else
                UserLogout();

        }

        private void UserLogin()
        {
            string email = textEmail.Text;
            string password = textPassword.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("Incorrect data. Try again");
                return;
            }

            if (email == "Email" || password == "Password")
            {
                MessageBox.Show("Fill the boxes with your data.");
                return;
            }

            var user = db.GetUserWithEmailAndPassword(email, password);
            if (user == null)
            {
                MessageBox.Show("User not found");
                return;
            }
            _userLogged = new User() { codUser = user.codUser, userName = user.userName, email = user.email };
            MessageBox.Show("Login Successful!");
            DrawUserLogin();
        }

        private void UserLogout()
        {
            if (!Board.wasSaved)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the game before logging out?", "Save game", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                    SaveGameButton_Click(null, null);       // Uploads the game to the DB
                else if (result == MessageBoxResult.Cancel)
                    return;
            }
            DrawUserLogout();
        }

        private void DrawUserLogin()
        {
            textWelcome.Content = $"Welcome back {_userLogged.userName}!";
            textWelcome.Visibility = Visibility.Visible;
            textEmail.Text = "";
            textPassword.Text = "";
            textEmail.Visibility = Visibility.Hidden;
            textPassword.Visibility = Visibility.Hidden;
            buttonLoadUser.Content = "Logout";
        }

        private void DrawUserLogout()
        {
            _userLogged = null;
            textWelcome.Content = "";
            textWelcome.Visibility = Visibility.Hidden;
            textEmail.Text = "Email";
            textPassword.Text = "Password";
            textEmail.Visibility = Visibility.Visible;
            textPassword.Visibility = Visibility.Visible;
            buttonLoadUser.Content = "Login";
        }

        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (_userLogged == null || _userLogged.codUser <= 0)
            {
                MessageBox.Show("You must be logged in to save a game");
                return;
            }
            Board.BeforeJson();
            Board.wasSaved = true;
            if (game.codGame == -1)
                AddGameToDB();
            else
                UpdateGameToDB();
            
        }

        private void AddGameToDB()
        {
            game.codUserWhites = _userLogged.codUser;
            game.codUserBlacks = _userLogged.codUser;
            long result = db.AddGame(game);
            game.codGame = result;
            if (result > 0)
            {
                MessageBox.Show("Game saved successfully");
                return;
            }
            MessageBox.Show("Error saving game");
            Board.wasSaved = false;
            return;
        }

        private void UpdateGameToDB()
        {
            if (game.codUserWhites <= 0 || game.codUserBlacks <= 0)
            {
                MessageBox.Show("Error saving game");
                return;
            }
            bool result = db.UpdateGameJson(game.codGame, game);
            if (result)
            {
                MessageBox.Show("Game saved successfully");

                return;
            }
            else
            {
                MessageBox.Show("Error saving game");
                Board.wasSaved = false;
                return;
            }
        }

        private void buttonLoadGame_Click(object sender, RoutedEventArgs e)
        {
            if (_userLogged == null || _userLogged.codUser <= 0)
            {
                MessageBox.Show("You must be logged in to load a game");
                return;
            }
            if (!Board.wasSaved)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the game?", "Save game", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                    SaveGameButton_Click(null, null);       // Uploads the game to the DB
                else if (result == MessageBoxResult.Cancel)
                    return;
            }

            LoadGames loadGamesWindow = new LoadGames(_userLogged);
            loadGamesWindow.Closed += LoadGameFromOtherWindow; // Subscribe to Closed event
            loadGamesWindow.Show();
        }


    }



}

