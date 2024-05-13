using System.Security.Cryptography.X509Certificates;

namespace ChessClassLibraryC_
{

    public enum PieceType
    {
        PAWN,
        ROOK,
        KNIGHT,
        BISHOP,
        QUEEN,
        KING
    }

    public enum ColorType
    {
        WHITE,
        BLACK
    }


    public class Piece
    {
        private Position _position; 
        public PieceType Type { get; init; }
        public ColorType Color { get; init; }
        public Position StartingPosition { get; init; }
        public Position Position { get => _position; set => SetPosition(value); }

        private Piece(PieceType type, Position startingPosition, ColorType color)
        {
            Type = type;
            StartingPosition = startingPosition;
            Color = color;
        }

        public static Piece? CreatePiece(PieceType type, Position startingPosition, ColorType color)
        {
            if (startingPosition != null && startingPosition.isValid())
                return new Piece(type, startingPosition, color);
            return null;
        }


        public void SetPosition(Position position)
        {
            if (position != null && position.isValid())
                _position = position;
        }


    }
}
