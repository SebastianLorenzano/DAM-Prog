using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Model
{

    public enum PieceType
    {
        PAWN = 0,
        ROOK = 1,
        KNIGHT = 2,
        BISHOP = 3,
        QUEEN = 4,
        KING = 5
    }

    public enum ColorType
    {
        WHITE = -1,
        BLACK = 1
    }

    public abstract class Piece
    {
        private Position _position;
        public Position Position { get => _position; set => SetPosition(value); }
        [JsonIgnore]public int X => _position.X;
        [JsonIgnore] public int Y => _position.Y;

        public virtual PieceType Type { get; }
        public ColorType Color { get; init; }

        protected Piece(Position position, ColorType color)
        {
            _position = position;
            Color = color;
        }

        public static bool CanCreatePiece(Position startingPosition)
        {
            return startingPosition != null && startingPosition.isInBoard();
        }

        public void SetPosition(Position position)
        {
            if (position != null && position.isInBoard())
                _position = position;
        }

        public abstract List<Position> GetPosiblePositions(Board board);    // It returns a list of all positions that are both within the board's width and height and 

        public bool CanAttackPosition(Position objetivePosition, Board board)
        {
            if (objetivePosition == null || board == null)
                return false;
            var posiblePositions = GetPosiblePositions(board);
            foreach (var p in posiblePositions)
            {
                if (p == objetivePosition)
                    return true;
            }
            return false;
        }

        public static Position[] GetKnightMoves()
        {
            return new Position[]
            {
                new Position(2, 1),
                new Position(1, 2),
                new Position(-1, 2),
                new Position(-2, 1),
                new Position(-2, -1),
                new Position(-1, -2),
                new Position(1, -2),
                new Position(2, -1)
            };
        }

        public static Position[] GetBishopMoves()
        {
            return new Position[]
            {
                new Position(1, 1),
                new Position(-1, 1),
                new Position(1, -1),
                new Position(-1, -1),
            };
        }
    }
}
