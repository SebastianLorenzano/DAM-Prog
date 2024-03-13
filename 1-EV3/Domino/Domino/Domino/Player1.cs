namespace Domino
{
    public abstract class Player1
    {
        protected List<Piece> _playerPieces = new();
        protected string _name;
        public string Name
        {
            get => _name;
            set => SetName(value);
        }
        public int PieceCount => _playerPieces.Count;



        public Player1(string name)
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
            if (piece != null)
                _playerPieces.Add(piece);
        }

        public void RemovePiece(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _playerPieces.RemoveAt(index);
        }

        public Piece? GetPieceAt(int index)
        {
            if (index < 0 || index >= _playerPieces.Count)
                return _playerPieces[index];
            return null;
        }

        public bool Contains(Piece piece)
        {
            return IndexOf(piece) >= 0;
        }

        public int IndexOf(Piece piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                if (_playerPieces[i] == piece)
                    return i;
            }
            return -1;
        }


        public List<Piece> GetDoubles()
        {
            return GetDoubles(_playerPieces);
        }

        public static List<Piece> GetDoubles(List<Piece> list)
        {
            var result = new List<Piece>();
            var p = list;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].IsDouble)
                    result.Add(p[i]);
            }
            return result;
        }

        public List<Piece> GetPlayablePieces(Game game)
        {
            var result = new List<Piece>();
            
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                var pieceParts = _playerPieces[i].GetPieceParts();
                if (game.ContainsValue(pieceParts[0].value) || game.ContainsValue(pieceParts[1].value))
                    result.Add(_playerPieces[i]);
            }
            return result;
        }

        public abstract Piece? PickPieceToThrow(Game game);

        public virtual void UsePiece(Game game)
        {
            var piece = PickPieceToThrow(game);
            RemovePiece(piece);
            game.UsePiece(Name, piece);
        }



    }
}
