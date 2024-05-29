
using System.Data.Entity.Core.Common.CommandTrees;

namespace Model
{
    public class Board
    {
        public const int WIDTH = 7;
        public const int HEIGHT = 7;
        private List<Piece> _pieces = new();

        public int Count => _pieces.Count;
        public int Turn {  get; set; }

        public Piece? GetPieceAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
                return _pieces[index]; 
            return null;
        }

        public void AddPiece(Piece piece)
        {
            if (piece != null && isPositionValid(new Position(piece.X, piece.Y)))
                _pieces.Add(piece);
        }

        public int IndexOf(Piece p)
        {
            if (p == null)
                return -1;
            for (int i = 0; i < _pieces.Count; i++) 
            {
                if (_pieces[i] == p) 
                    return i;
            }
            return -1;
        }

        private bool ContainsPiece(Piece piece)
        {
            return IndexOf(piece) >= 0;
        }

        public void RemovePiece(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _pieces.RemoveAt(index);

        }

        public bool isPositionValid(Position pos)
        {
            return pos.isValid();
        }
    }
}
