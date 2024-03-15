namespace Domino
{
    public abstract class Player
    {
        protected DominoDeck _playerPieces = new();
        protected string _name;
        public string Name
        {
            get => _name;
            set => SetName(value);
        }
        public int PieceCount => _playerPieces.Count;



        public Player(string name)
        {
            if (name == null)
                name = "Uknown";
            Name = name;
        }


        public void SetName(string name)
        {
            if (name != null)
                _name = name;
        }

        public void AddPiece(Piece piece)
        {
            _playerPieces.Add(piece);
        }

        public void RemovePiece(Piece piece)
        {
            _playerPieces.Remove(piece);
        }

        public Piece? GetPieceAt(int index)
        {
            return _playerPieces.GetPieceAt(index);
        }

        public bool ContainsPiece(Piece piece)
        {
            return _playerPieces.Contains(piece);
        }

        public int IndexOfPiece(Piece piece)
        {
            return _playerPieces.IndexOf(piece);
        }


        public List<Piece> GetDoubles()
        {
            return _playerPieces.GetDoubles();
        }

        public static List<Piece> GetDoubles(List<Piece> list)
        {
            return DominoDeck.GetDoubles(list);
        }

        public List<Piece> GetPlayablePieces(Game game)
        {
            var result = new List<Piece>();
            
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                var piece = _playerPieces.GetPieceAt(i);
                var pieceParts = piece.GetPieceParts();
                if (game.ContainsValue(pieceParts[0].value) || game.ContainsValue(pieceParts[1].value))
                    result.Add(piece);
            }
            return result;
        }

        public abstract Piece? PickPieceToThrow(Game game);

        public virtual bool UsePiece(Game game)
        {
            var piece = PickPieceToThrow(game);
            RemovePiece(piece);
            return game.UsePiece(Name, piece);
        }

        public int GetPointsAndGetBackPieces(Game game)
        {
            int result = 0;
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                var piece = _playerPieces.GetPieceAt(i);
                if (piece == null)
                    return 0;
                if (piece.IsDouble)
                    result += piece.GetValue1() * 2;
                else
                    result += piece.GetValue1() + piece.GetValue2();
                game.AddPiece(piece);
                _playerPieces.RemoveAt(i);
                i--;

            }
            return result;
        }



    }
}
