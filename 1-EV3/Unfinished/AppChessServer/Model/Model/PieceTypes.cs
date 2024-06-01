
namespace Model
{

    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.PAWN;
        private Pawn(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Pawn? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Pawn(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece p, Board board)
        {
            var result = new List<Position>();
            for (int x = -1; x <= 1; x++)
            {
                var position = new Position(x, p.X * (int)p.Color);
                if (board.CanPieceMoveTo(p, position))
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
        private Rook(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Rook? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Rook(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece piece, Board board)
        {
            var p = piece.Position;
            var result = new List<Position>();

            for (int x = p.X + 1; x < 8; x++)           // Gets positions up
            {
                var position = new Position(x, p.Y);    
                if (board.CanPieceMoveTo(piece, position))
                    result.Add(position);
                else
                    break;
            }
            for (int x = p.X - 1; x >= 0; x--)          // Gets positions down
            {
                var position = new Position(x, p.Y);
                if (board.CanPieceMoveTo(piece, position))
                    result.Add(position);
                else
                    break;
            }
            for (int y = p.Y + 1; y < 8; y++)           // Gets positions right
            {
                var position = new Position(p.X, y);
                if (board.CanPieceMoveTo(piece, position))
                    result.Add(position);
                else
                    break;
            }
            for (int y = p.Y - 1; y >= 0; y--)          // Gets positions left
            {
                var position = new Position(p.X, y);
                if (board.CanPieceMoveTo(piece, position))
                    result.Add(position);
                else
                    break;
            }
            return result;
        }
    }

    public class Knight : Piece
    {
        public override PieceType Type => PieceType.KNIGHT;
        private Knight(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Knight? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Knight(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece p, Board board)
        {
            var result = new List<Position>();
            var knightMoves = GetKnightMoves();         // is stored in Piece for organization purposes
            foreach (var move in knightMoves)
            {
                move.X += p.X;
                move.Y += p.Y;

                if (move.isInBoard())
                    result.Add(new Position(move.X, move.Y));
            }
            return result;
        }
    }

    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.BISHOP;
        private Bishop(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Bishop? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Bishop(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece p, Board board)
        {
            var result = new List<Position>();
            var bishopDirections = GetBishopMoves();         // is stored in Piece for organization purposes
            foreach (var d in bishopDirections)
            {
                int dx = d.X;
                int dy = d.Y;

                d.X += p.X;
                d.Y += p.Y;
                while (board.CanPieceMoveTo(p, d))
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
        private Queen(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Queen? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Queen(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece p, Board board)
        {
            var result = Rook.GetPosiblePositions(p, board);
            result.AddRange(Bishop.GetPosiblePositions(p, board));
            return result;
        }
    }

    public class King : Piece
    {
        public override PieceType Type => PieceType.KING;

        private King(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static King? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new King(startingPosition, color);
            return null;
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece piece, Board board)
        {
            var result = new List<Position>();
            var pos = piece.Position;
            for (int x = pos.X - 1; x < pos.X + 1; x++)
                for (int y = pos.Y - 1; y < pos.Y + 1; y++)
                {
                    var newPos = new Position(x, y);
                    if (board.CanPieceMoveTo(piece, newPos))
                        result.Add(newPos);
                }
            return result;
        }

        public bool IsInCheck(Board board)
        {
            if (board == null)
                return false;
            for (int i = 0; i < board.Count; i++)
            {
                var piece = board.GetPieceWithIndex(i);
                if (piece != this && piece.CanAttackPosition(Position, board))
                    return true;

            }
            return false;
        }
    }
}
