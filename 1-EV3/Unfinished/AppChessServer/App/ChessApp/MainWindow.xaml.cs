using System.Configuration;
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
using Model;

namespace ChessApp
{
    public partial class MainWindow : Window
    {
        private const string connectionString = "Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;";
        public SqlDatabase db = SqlDatabase.Instance;
        private readonly Image[,] _images = new Image[8, 8];
        private Ellipse[,] _highlights = new Ellipse[8, 8];

        private GameDB game;    // Instance for DB
        private Position _selectedPosition;
        private List<Position> _possibleMoves = new List<Position>();   // Possible moves for the selected piece
        private Board Board => game.Board;


        public MainWindow()
        {
            game = new GameDB() { codGame = -1, codUserBlacks = -1, codUserWhites = -1, Board = new Board() { Turn = 0 } };
            SqlDatabase.CreateSimpleton(connectionString);
            InitializeComponent();
            InitializeBoard();
            game.Board = new Board().Fill();
            DrawBoard();
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

                    var highlight = new Ellipse()   // Initializes highlight
                    {
                        Width = 30,
                        Height = 30,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Fill = Brushes.Gray,
                        Visibility = Visibility.Hidden
                    };

                    _highlights[x, y] = highlight;
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
        }

        private void SavePossibleMoves(List<Position> positions) // Sets _possibleMoves to the positions given, as long as they are valid
        {
            _possibleMoves.Clear();
            foreach (var p in positions)
            {
                if (p != null && p.isInBoard())
                    _possibleMoves.Add(p);
            }
        }

        private void ShowHighlights()
        {
            foreach (var p in _possibleMoves)
                _highlights[p.X, p.Y].Visibility = Visibility.Visible;
        }

        private void HideHighlights()
        {
            foreach (var p in _possibleMoves)
                _highlights[p.X, p.Y].Visibility = Visibility.Hidden;
        }

        private Position ToSquarePosition(Point point)
        {
            double tileWidth = BoardGrid.ActualWidth / 8;
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
            var possibleMoves = game.Board.GetPossibleMovesForPieceWithPosition(position);
            if (possibleMoves.Any())
            {
                _selectedPosition = position;
                SavePossibleMoves(possibleMoves);
                ShowHighlights();
            }
        }

        private void MovePieceToPosition(Position position)
        {
            _selectedPosition = null;
            HideHighlights();
            if (_possibleMoves.Contains(position))
            {
                HandleMove(_selectedPosition, position);
                DrawBoard();
            }
        }

        private void HandleMove(Position selectedPos, Position goToposition)
        {
            Board.MakeMove(selectedPos, goToposition);
            DrawBoard();
        }

    }



}

