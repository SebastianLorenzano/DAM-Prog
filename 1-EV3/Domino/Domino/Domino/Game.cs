using System.Numerics;

namespace Domino
{
    public class Game
    {
        private PlayersList _players = new();
        private DominoDeck _pieces = new();
        private List<int> _availableValues = new();
        private bool isRoundRunning = false;
        private int consecutivePasses = 0;

        public int PieceCount => _pieces.Count;
        public Piece? FirstPiece => _pieces.First;
        public Piece? LastPiece => _pieces.Last;
        private Player Winner { get; set; }

        public Game()
        {

        }

        public Game(PlayersList players, DominoDeck deck)
        {
            _players = players.Clone();
            _pieces = deck.Clone();
        }

        public void AddPlayer(Player player)
        {
            _players.AddPlayer(player);
        }

        public void RemovePlayerAt(int index)
        {
            _players.RemovePlayerAt(index);
        }

        public Player? GetPlayerAt(int index)
        {
            return _players.GetPlayerAt(index);
        }

        public bool ContainsPlayer(Player player)
        {
            return _players.ContainsPlayer(player);
        }

        private int IndexOfPlayer(Player player)
        {
            return _players.IndexOfPlayer(player);
        }

        public List<Player> PlayersToList()
        {
            return _players.ToList();

        }


        public void AddPiece(Piece piece)
        {
            _pieces.Add(piece);
        }

        public void RemovePieceAt(int index)
        {
            _pieces.RemoveAt(index);
        }

        public Piece? GetPieceAt(int index)
        {
            return _pieces.GetPieceAt(index);
        }

        public Piece? TakePieceAt(int index)
        {
            return _pieces.TakePieceAt(index);
        }

        public bool ContainsPiece(Piece piece)
        {
            return _pieces.Contains(piece);
        }

        private int IndexOfPiece(Piece piece)
        {
            return _pieces.IndexOf(piece);
        }

        public List<Piece> PiecesToList()
        {
            return _pieces.ToList();

        }

        public void AddAvailableValue(int value)
        {
            if (value >= 0 && value <= 6)
                _availableValues.Add(value);
        }

        public void AddAvailableValue(Piece piece)
        {
            if (piece == null)
                return;
            var pieceParts = piece.GetPieceParts();
            if (!pieceParts[0].isOcuppied)
                AddAvailableValue(pieceParts[0].value);
            if (!pieceParts[1].isOcuppied)
                AddAvailableValue(pieceParts[1].value);
        }


        public void RemoveAvailableValue(int value) 
        {
            var result = IndexOfValue(value);
            if (result >= 0)
                _availableValues.RemoveAt(result);
        }

        public int GetValueAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
                return _availableValues[index];
            return -1;
        }

        public bool ContainsValue(int value)
        {
            return IndexOfValue(value) >= 0;
        }

        private int IndexOfValue(int value)
        {
            if (value < 0 || value > 6)
                return -1;
            for (int i = 0; i < _availableValues.Count; i++)
            {
                if (_availableValues[i] == value)
                    return i;
            }
            return -1;
        }

        public string AvailableValuesToString()
        {
            string result = "( ";
            for (int i = 0; i < _availableValues.Count; i++)
            {
                if (i != _availableValues.Count - 1)
                    result += _availableValues[i].ToString() + ", ";
                else
                    result += _availableValues[i].ToString();
            }
            return result += " )";
        }


        public bool UsePiece(string name, Piece piece)
        {
            if (piece == null)
            {
                Console.WriteLine("El Jugador " + name + " no ha tirado ninguna ficha.");
                
                return false;
            }
            else
            {
                int value1 = piece.GetValue1();
                int value2 = piece.GetValue2();
                if (_availableValues.Count == 0)
                {
                    AddAvailableValue(value1);
                    AddAvailableValue(value2);
                }
                else if (piece.IsDouble)
                {
                    AddAvailableValue(value1);
                }
                else if (ContainsValue(value1))
                {
                    AddAvailableValue(value2);
                    RemoveAvailableValue(value1);
                }
                else
                {
                    AddAvailableValue(value1);
                    RemoveAvailableValue(value2);
                }


                AddPiece(piece);
                Console.WriteLine("El Jugador " + name + " ha tirado la ficha con valores " + piece.ToString());
                Console.WriteLine(AvailableValuesToString());
                return true;
            }
        }

        public void RemoveLosers()
        {
            List<Player> losers = new();
            int loserPoints = 0;
            for (int i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                int points = player.GetPointsAndGiveBackPieces(this);
                if (points == loserPoints)
                    losers.Add(player);
                else if (points > loserPoints)
                {
                    losers.Clear();
                    losers.Add(player);
                    loserPoints = points;
                }
            }
            foreach (Player player in losers) 
            {
                Console.WriteLine("El/La jugador/a " + player.Name + " ha perdido y ha sido removido/a de la partida.");
                int index = IndexOfPlayer(player);
                if (index >= 0)
                    RemovePlayerAt(index);
            }
        }


        public Player GetWinner()
        {
            return Winner;
        }

        public void SetWinner(Player player)
        {
            Winner = player;
        }

        public void AnnounceWinner()
        {
            if (Winner != null) 
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("La partida ha terminado.");
                Console.WriteLine("El/La Ganador/a es: " + Winner.Name + "!!");
            }
        }

        public void StartGame()
        {
            while (_players.Count > 1) 
                    StartRound();
            Winner = _players.First;
            AnnounceWinner();

        }

        public void GivePiecesToPlayers()
        {
            while (_pieces.Count >= 1)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    int randomPiece = Utils.GetRandom(0, _pieces.Count - 1);
                    var player = GetPlayerAt(i);
                    player.AddPiece(TakePieceAt(randomPiece));
                }
            }
        }

        public void PlayTurns()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Player player = _players[i];
                PlayPlayerTurn(ref player);
                if (player.PieceCount == 0 || consecutivePasses == _players.Count)
                {
                    isRoundRunning = false;
                    break;
                }
            }
        }

        public void PlayPlayerTurn(ref Player player)
        {
            bool played = player.UsePiece(this);
            if (played)
                consecutivePasses = 0;
            else
                consecutivePasses++;

        }

        public void StartRound()
        {
            GivePiecesToPlayers();
            isRoundRunning = true;
            while (isRoundRunning)
                PlayTurns();
            RemoveLosers();
            PrepareRoundRestart();
        }

        public void PrepareRoundRestart()
        {
            _availableValues.Clear();
            /* Console.Clear(); */

        }

    }

}

