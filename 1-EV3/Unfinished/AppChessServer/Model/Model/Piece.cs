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
        public Position Position { get; set; }
        [JsonIgnore] public int X => Position.X;
        [JsonIgnore] public int Y => Position.Y;

        public virtual PieceType Type { get; }
        public virtual ColorType Color { get; set; }

        [JsonConstructor]
        public Piece()
        {

        }
        public Piece(Position position, ColorType color)
        {
            Position = position;
            Color = color;
        }

        public static bool CanCreatePiece(Position startingPosition)
        {
            return startingPosition != null && startingPosition.IsInBoard();
        }

        public void SetPosition(Position position)
        {
            if (position != null)
                Position = position;
        }

        public abstract List<Position> GetPosiblePositions(Board board);
        public abstract Piece Clone();
        public virtual bool CanAttackOpponentKing(Board board)
        {
            var moves = GetPosiblePositions(board);
            foreach (var move in moves)
            {
                var piece = board.GetPieceWithPosition(move);
                if (piece != null && piece.Type == PieceType.KING)
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

        public static Position[] GetRookMoves()
        {
            return new Position[]
            {
                new Position(1, 0),
                new Position(-1, 0),
                new Position(0, 1),
                new Position(0, -1),
            };
        }

        public static Position[] GetKingMoves()
        {
            return new Position[]
                {
                new Position(1, 0),     //South
                new Position(-1, 0),    //North
                new Position(0, 1),     //East
                new Position(0, -1),    //West
                new Position(1, 1),     //South-East
                new Position(-1, 1),    //North-East
                new Position(1, -1),    //South-West
                new Position(-1, -1),   //North-West
            };
        }

        public PieceDB ToPieceDB()
        {
            return new PieceDB()
            {
                X = X,
                Y = Y,
                Color = Color,
                Type = Type
            };

        }
    }
    public class PieceDB
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ColorType Color { get; set; }
        public PieceType Type { get; set; }


        public Piece? ToPiece()
        {

            return Type switch
            {
                PieceType.PAWN => new Pawn(new Position(X, Y), Color),
                PieceType.ROOK => new Rook(new Position(X, Y), Color),
                PieceType.KNIGHT => new Knight(new Position(X, Y), Color),
                PieceType.BISHOP => new Bishop(new Position(X, Y), Color),
                PieceType.QUEEN => new Queen(new Position(X, Y), Color),
                PieceType.KING => new King(new Position(X, Y), Color),
                _ => null
            };
        }
    }
}
