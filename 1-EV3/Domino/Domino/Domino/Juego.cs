namespace Domino
{
    public class Juego
    {
        private List<Player> _players = new();
        private List<Piece> _pieces = new();

        public int PieceCount => _pieces.Count;
        public Piece? FirstPiece => PieceCount > 0 ? _pieces[0] : null;
        public Piece? LastPiece => PieceCount > 0 ? _pieces[PieceCount - 1] : null;
        private Player Winner {  get; set; }
        public void AddPlayer(Player player)
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

        private int IndexOfPlayer(Player player)
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

        public bool ContainsPlayer(Player player)
        {
            return IndexOfPlayer(player) >= 0;
        }

        public void AddPiece(Piece piece)
        {
            if (piece != null)
                _pieces.Add(piece);
        }

        public void RemovePieceAt(int index)
        {
            if (index < 0 || index >= _pieces.Count)
                return;
            _pieces.RemoveAt(index);
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

        public bool ContainsPiece(Piece piece)
        {
            return IndexOfPiece(piece) >= 0;
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
            throw new NotImplementedException();
        }

        public void StartRound()
        {
           throw new NotImplementedException();
        }


        public void UsePiece(string name, Piece? piece)
        {
            if (piece != null)
            {
                Console.WriteLine("El Jugador " +  name + " no ha tirado ninguna ficha.");
            }
            else
            {
                Console.WriteLine("El Jugador " + name + " ha tirado la ficha con valores " + piece.ToString);
            }
        }
    }
}
