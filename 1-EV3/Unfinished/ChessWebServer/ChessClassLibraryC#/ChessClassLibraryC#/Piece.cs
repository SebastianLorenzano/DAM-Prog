using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ChessClassLibraryC_
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
        protected Position _position;
        public virtual PieceType Type { get; }
        public ColorType Color { get; init; }
        public Position StartingPosition { get; init; }
        public Position Position { get => _position; set => SetPosition(value); }

        protected Piece(Position startingPosition, PieceType type, ColorType color)
        {
            Type = type;
            StartingPosition = startingPosition;
            Color = color;
        }

        public static bool CanCreatePiece(Position startingPosition)
        {
            return startingPosition != null && startingPosition.isValid();
        }


        public void SetPosition(Position position)
        {
            if (position != null && position.isValid())
                _position = position;
        }

        public abstract List<Position> GetPosiblePositions();    // It returns a list of all positions that are both within the board's width and height and 
                                                                   // 
    }
}
