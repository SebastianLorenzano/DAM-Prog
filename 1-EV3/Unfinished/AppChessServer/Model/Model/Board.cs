
using System.Data.Entity.Core.Common.CommandTrees;
using System.Text.Json.Serialization;

namespace Model
{
    public class Board
    {
        public const int WIDTH = 7;
        public const int HEIGHT = 7;

        [JsonInclude]
        private List<Piece> _pieces = new List<Piece>();
        public int Width => WIDTH;
        public int Height => HEIGHT;
        public int Count => _pieces.Count;
        public int Turn { get; set; }

        public void AddPiece(Piece piece)
        {
            if (piece != null && piece.Position.isInBoard())
                _pieces.Add(piece);
        }

        public Piece? GetPieceWithIndex(int index)
        {
            if (index >= 0 && index < _pieces.Count)
                return _pieces[index];
            return null;
        }

        public Piece? GetPieceWithPosition(Position position)
        {
            if (position != null)
                foreach (var p in _pieces)
                {
                    if (p.Position == position) 
                        return p;
                }
            return null;
        }

        private bool ContainsPiece(Piece piece)
        {
            return IndexOf(piece) >= 0;
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
        public void RemovePiece(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _pieces.RemoveAt(index);

        }

        public bool CanPieceMoveTo(Piece piece, Position destinePos)
        {
           if (piece.Position.isInBoard() || piece.Position != destinePos)
            {
                Piece? other = GetPieceWithPosition(destinePos);
                return other == null || piece.Color != other.Color;
            }
            return false;
        }
    }
}
