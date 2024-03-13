namespace Domino
{
    public class Game
    {
        private List<Player1> _players = new();
        private List<Piece> _pieces = new();
        private List<int> _availableValues = new();
        private bool isRoundRunning = false;
        public int PieceCount => _pieces.Count;
        public Piece? FirstPiece => PieceCount > 0 ? _pieces[0] : null;
        public Piece? LastPiece => PieceCount > 0 ? _pieces[PieceCount - 1] : null;
        private Player Winner { get; set; }

        public Game()
        {

        }

        public Game(List<Player1> players, List<Piece> pieces)
        {
            _players = players;
            _pieces = pieces;
        }

        public void AddPlayer(Player1 player)
        {
            if (player != null)
                _players.Add(player);
        }

        public void RemovePlayerAt(int index)
        {
            if (index < 0 || index >= _players.Count)
                return;
            _players.RemoveAt(index);
        }

        public Player1? GetPlayerAt(int index)
        {
            if (index >= 0 && index < _players.Count)
                return _players[index];
            return null;
        }

        public bool ContainsPlayer(Player1 player)
        {
            return IndexOfPlayer(player) >= 0;
        }

        private int IndexOfPlayer(Player1 player)
        {
            if (player == null)
                return -1;
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i] == player)
                    return i;
            }
            return -1;
        }


        public void AddPiece(Piece piece)
        {
            if (piece == null)
                return;
            _pieces.Add(piece);
            AddAvailableValue(piece);
        }

        public void RemovePieceAt(int index)
        {
            if (index < 0 || index >= _pieces.Count)
                return;
            _pieces.RemoveAt(index);
        }

        public Piece? GetPieceAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
                return _pieces[index];
            return null;
        }

        public Piece? TakePieceAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
            {
                Piece result = _pieces[index];
                _pieces.RemoveAt(index);
                return result;
            }
            return null;
        }

        public bool ContainsPiece(Piece piece)
        {
            return IndexOfPiece(piece) >= 0;
        }

        private int IndexOfPiece(Piece piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < _pieces.Count; i++)
            {
                if (_pieces[i] == piece)
                    return i;
            }
            return -1;
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
            for (int i = 0; i < _pieces.Count; i++)
            {
                if (_availableValues[i] == value)
                    return i;
            }
            return -1;
        }


        public void UsePiece(string name, Piece piece)
        {

            if (piece != null)
            {
                Console.WriteLine("El Jugador " + name + " no ha tirado ninguna ficha.");
            }
            else
            {
                int value1 = piece.GetValue1();
                int value2 = piece.GetValue2();
                if (ContainsValue(value1))
                {
                    RemoveAvailableValue(value1);
                    AddAvailableValue(value2);
                }
                else
                {
                    RemoveAvailableValue(value2);
                    AddAvailableValue(value1);
                }
                    

                AddPiece(piece);
                Console.WriteLine("El Jugador " + name + " ha tirado la ficha con valores " + piece.ToString());
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

        public void StartGame()
        {
            int fps = 0;
            while (_players.Count > 1) 
            {
                if (fps < 1000)
                    fps++;
                else
                    StartRound();
            }
        }

        public void StartRound()
        {

            while (_pieces.Count >= 1)
            {
                for (int i = 0; i < _players.Count; i++)
                _players[i].AddPiece(TakePieceAt(i));
            }
            isRoundRunning = true;
            while (isRoundRunning)
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].PickPieceToThrow(this);
                    if (_players[i].PieceCount == 0)
                        isRoundRunning = false;
                }
        }

    }
}
