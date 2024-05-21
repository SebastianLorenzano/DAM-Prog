
namespace Model
{

    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.PAWN;
        private Pawn(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static Pawn? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Pawn(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece p)
        {
            var result = new List<Position>();
            for (int x = -1; x <= 1; x++)
            {
                var position = new Position(x, p.X * (int)p.Color);
                if (position.isValid())
                    result.Add(position);
            }
            return result;
        }
    }

    // TODO: I Have to give every "GetPosiblePositions" a board, and check whenever they want to add new positions if that position is occupied, if it is regardless
    //      of its color, it cannot go further into that direction, so we can use this function to make the function for the king "IsInCheck" and if it is, and "GetPossiblePositions" count is 0,
    //      is game over.
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.ROOK;
        private Rook(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static Rook? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Rook(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece piece)
        {
            var p = piece.Position;
            var result = new List<Position>();

            for (int x = p.X + 1; x < 8; x++)       // Gets positions up
                result.Add(new Position(x, p.Y));            
            for (int x = p.X - 1; x >= 0; x--)      // Gets positions down
                result.Add(new Position(x, p.Y)); 
            for (int y = p.Y + 1; y < 8; y++)       // Gets positions right
                result.Add(new Position(p.X, y));
            for (int y = p.Y - 1; y >= 0; y--)      // Gets positions left
                result.Add(new Position(p.X, y));
            return result;
        }
    }

    public class Knight : Piece
    {
        public override PieceType Type => PieceType.KNIGHT;
        private Knight(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static Knight? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Knight(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece p)
        {
            var result = new List<Position>();
            var knightMoves = GetKnightMoves();         // is stored in Piece for organization purposes
            foreach (var move in knightMoves)
            {
                move.X += p.X;
                move.Y += p.Y;

                if (move.isValid())
                    result.Add(new Position(move.X, move.Y));
            }
            return result;
        }
    }

    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.BISHOP;
        private Bishop(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static Bishop? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Bishop(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece p)
        {
            var result = new List<Position>();
            var bishopDirections = GetBishopMoves();         // is stored in Piece for organization purposes
            foreach (var d in bishopDirections)
            {
                int dx = d.x;
                int dy = d.y;

                d.X += p.X;
                d.Y += p.Y;
                while (d.isValid())
                {
                    result.Add(new Position(d.X, d.Y));
                    d.X += dx;
                    d.Y += dy;
                }
            }
            return result;
        }
    }

    public class Queen : Piece
    {
        public override PieceType Type => PieceType.QUEEN;
        private Queen(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static Queen? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Queen(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece p)
        {
            var result = Rook.GetPosiblePositions(p);
            result.AddRange(Bishop.GetPosiblePositions(p));
            return result;
        }
    }

    public class King : Piece
    {
        public override PieceType Type => PieceType.KING;

        private King(Position startingPosition, PieceType type, ColorType color) : base(startingPosition, type, color)
        {
        }

        public static King? Create(Position startingPosition, PieceType type, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new King(startingPosition, type, color);
            return null;
        }

        public override List<Position> GetPosiblePositions()
        {
            return GetPosiblePositions(this);
        }

        public static List<Position> GetPosiblePositions(Piece piece)
        {
            var result = new List<Position>();
            var p = piece.Position;
            for (int x = p.X - 1; x < p.x + 1; x++)
                for (int y = p.Y - 1; y < p.y + 1; y++)
                {
                    var newPos = new Position(x, y);
                    if (newPos.isValid() || newPos != p)
                        result.Add(newPos);
                }
            return result;
        }

        public bool IsInCheck()
        {
            throw new NotImplementedException();
        }
    }
}
