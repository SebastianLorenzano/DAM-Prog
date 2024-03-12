using System.ComponentModel.DataAnnotations;

namespace Domino
{
    public abstract class Player
    {
        protected List<Piece> _playerPieces = new();
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { SetName(value); }
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
            if (piece != null)
                _playerPieces.Add(piece);
        }

        public Piece? GetPieceAt(int index)
        {
            if (index < 0 || index >= _playerPieces.Count)
                return _playerPieces[index];
            return null;
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

        public bool Contains(Piece piece)
        {
            return IndexOf(piece) >= 0;
        }

        public void RemovePiece(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _playerPieces.RemoveAt(index);
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

        public List<Piece> GetDoublesSorted()
        {
            var result = GetDoubles();
            Utils.SortPieces(ref result);
            return result;
        }

        public List<Piece> GetDoublesSorted(List<Piece> list)
        {
            var result = GetDoubles(list);
            Utils.SortPieces(ref result);
            return result;
        }

        public List<Piece> GetPlayablePieces(Juego juego)
        {
            List<Piece> result = new();
            for (int i = 0; i < _playerPieces.Count;i++)
            {
                var p = _playerPieces[i].GetPieceParts();
                if (!p[0].IsOcuppied || !p[1].IsOcuppied)
                    result.Add(_playerPieces[i]);
            }
            return result;
        }


        public abstract Piece? PickPieceToThrow(Juego juego);

        public virtual void UsePiece(Juego juego)
        {
            var piece = PickPieceToThrow(juego);
            RemovePiece(piece);
            juego.UsePiece(Name, piece);
        }
    }
}