
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
        public int Count => _pieces.Count;
        public int Turn { get; set; }

        public void AddPiece(Piece piece)
        {
            if (piece != null && piece.Position.isInBoard() && IsPositionEmpty(piece.Position))
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

        public bool IsPositionEmpty(Position position)
        {
            return GetPieceWithPosition(position) == null;
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

        public void Fill()
        {
            AddPiece(Rook.Create(new Position(0, 0), ColorType.BLACK));
            AddPiece(Knight.Create(new Position(1, 0), ColorType.BLACK));
            AddPiece(Bishop.Create(new Position(2, 0), ColorType.BLACK));
            AddPiece(Queen.Create(new Position(3, 0), ColorType.BLACK));
            AddPiece(King.Create(new Position(4, 0), ColorType.BLACK));
            AddPiece(Bishop.Create(new Position(5, 0), ColorType.BLACK));
            AddPiece(Knight.Create(new Position(6, 0), ColorType.BLACK));
            AddPiece(Rook.Create(new Position(7, 0), ColorType.BLACK));
            for (int i = 0; i <= WIDTH; i++)
                AddPiece(Pawn.Create(new Position(i, 1), ColorType.BLACK));
            for (int i = 0; i <= WIDTH; i++)
                AddPiece(Pawn.Create(new Position(i, 6), ColorType.WHITE));
            AddPiece(Rook.Create(new Position(0, 7), ColorType.WHITE));
            AddPiece(Knight.Create(new Position(1, 7), ColorType.WHITE));
            AddPiece(Bishop.Create(new Position(2, 7), ColorType.WHITE));
            AddPiece(Queen.Create(new Position(3, 7), ColorType.WHITE));
            AddPiece(King.Create(new Position(4, 7), ColorType.WHITE));
            AddPiece(Bishop.Create(new Position(5, 7), ColorType.WHITE));
            AddPiece(Knight.Create(new Position(6, 7), ColorType.WHITE));
            AddPiece(Rook.Create(new Position(7, 7), ColorType.WHITE));
        }
    }
}
