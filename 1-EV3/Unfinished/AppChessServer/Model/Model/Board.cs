
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Model
{
    public class Board
    {
        public const int WIDTH = 7;
        public const int HEIGHT = 7;

        [JsonInclude]
        private Piece[,] _pieces = new Piece[8,8];
        public int Count => _pieces.Length;
        public int Turn { get; set; }

        public Piece? this[int x, int y]
        {
            get 
            {
                if (Position.isInBoard(x, y))
                    return _pieces[x, y];
                return null;
            }
            set
            {
                if (Position.isInBoard(x, y))
                {
                    _pieces[x, y] = value;
                }
            }
        }

        public void AddPiece(Piece p)
        {
            if (p != null)
                _pieces[p.X, p.Y] = p;
        }

        public Piece? GetPieceWithPosition(int x, int y)
        {
            if (Position.isInBoard(x, y))
                return _pieces[x, y];
            return null;
        }

        public Piece? GetPieceWithPosition(Position position)
        {
            return GetPieceWithPosition(position.X, position.Y);
        }

        public List<Position> GetPossibleMovesForPieceWithPosition(Position position)
        {
            var piece = GetPieceWithPosition(position);
            if (piece != null)
                return piece.GetPosiblePositions(this);
            return new List<Position>();
        }

        public void RemovePiece(Piece piece)
        {
            if (piece == _pieces[piece.X, piece.Y])
                _pieces[piece.X, piece.Y] = null;
        }

        public bool IsPositionEmpty(Position position)
        {
            return GetPieceWithPosition(position) == null;
        }

        public bool CanPieceMoveTo(Piece piece, Position destinePos)
        {
           if (destinePos.isInBoard() && piece.Position != destinePos)
            {
                Piece? other = GetPieceWithPosition(destinePos);
                return other == null || piece.Color != other.Color;
            }
            return false;
        }

        public ColorType GetCurrentPlayer()
        {
            if (Turn % 2 == 0)
                return ColorType.WHITE;
            return ColorType.BLACK;
        }
        public Piece? GetKing(ColorType color)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    var piece = GetPieceWithPosition(x, y);
                    if (piece != null && piece.Type == PieceType.KING && piece.Color == color)
                        return piece;
                }
            }
            return null;
        }

        public bool IsKingInCheck(ColorType color)
        {
            var king = GetKing(color);
            if (king != null)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    for (int y = 0; y < HEIGHT; y++)
                    {
                        var piece = GetPieceWithPosition(x, y);
                        if (piece != null && piece.Color != color && piece.CanAttackPosition(king.Position, this))
                            return true;
                    }
                }
            }
            return false;
        }

        public void MakeMove(Position? selectedPosition, Position position)
        {
            GetPieceWithPosition(selectedPosition)?.SetPosition(position);
        }




        public Board Fill()
        {
            #nullable disable
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
            return this;
            #nullable restore
        }


    }
}
