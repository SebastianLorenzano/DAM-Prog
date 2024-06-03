
using System.Security.Policy;

namespace Model
{

    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.PAWN;
        public bool FirstMove { get; set; } = true;
        public Pawn()
        {

        }
        public Pawn(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Pawn? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Pawn(startingPosition, color);
            return null;
        }

        public override Piece Clone()
        {
            return new Pawn(Position, Color);
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
                var position = new Position(p.X + x, p.Y + (1 * (int)p.Color));
                if (x == 0)
                {
                    if (board.IsPositionEmpty(position))
                        result.Add(position);
                    continue;
                }
                var other = board.GetPieceWithPosition(position);
                if (position.IsInBoard() && other != null && other.Color != p.Color)
                    result.Add(position);
            }
            if (p is Pawn pawn)
            {
                if (pawn.FirstMove)
                {
                    result.Add(new Position(p.X, p.Y + (2 * (int)p.Color)));
                }
            }
            return result;
        }

        public override bool CanAttackOpponentKing(Board board)
        {
            var moves = GetPosiblePositions(board);
            foreach (var move in moves)
            {
                var piece = board.GetPieceWithPosition(move);
                if (piece != null && piece.Type == PieceType.KING && piece.Color != Color && X != move.X)
                    return true;
            }
            return false;
        }
    }

    // TODO: I Have to give every "GetPosiblePositions" a board, and check whenever they want to add new positions if that position is occupied, if it is regardless
    //      of its color, it cannot go further into that direction, so we can use this function to make the function for the king "IsInCheck" and if it is, and "GetPossiblePositions" count is 0,
    //      is game over.
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.ROOK;
        public Rook()
        {

        }
        public Rook(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Rook? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Rook(startingPosition, color);
            return null;
        }

        public override Piece Clone()
        {
            return new Rook(Position, Color);
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece piece, Board board)
        {
            var p = piece.Position;
            var result = new List<Position>();
            var directions = GetRookMoves();

            foreach (var d in directions)
                result.AddRange(GetPositionsInDirection(board, piece, d));
            return result;
        }

        private static List<Position> GetPositionsInDirection(Board board, Piece piece, Position direction)
        {
            var result = new List<Position>();
            int x = piece.Position.X;
            int y = piece.Position.Y;

            while (true)
            {
                x += direction.X;
                y += direction.Y;
                var newPos = new Position(x, y);
                if (!newPos.IsInBoard())
                    break;
                if (board.GetPieceWithPosition(newPos) == null)
                    result.Add(newPos);
                else
                {
                    if (board.CanPieceMoveTo(piece, newPos))
                        result.Add(newPos);
                    break;
                }
            }
            return result;
        }
    }

    public class Knight : Piece
    {
        public override PieceType Type => PieceType.KNIGHT;
        public Knight()
        {

        }
        public Knight(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Knight? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Knight(startingPosition, color);
            return null;
        }
        public override Piece Clone()
        {
            return new Knight(Position, Color);
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
                var pos = new Position(move.X + p.X, move.Y + p.Y);

                if (board.CanPieceMoveTo(p, pos))
                    result.Add(pos);
            }
            return result;
        }
    }

    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.BISHOP;
        public Bishop()
        {

        }
        public Bishop(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Bishop? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Bishop(startingPosition, color);
            return null;
        }

        public override Piece Clone()
        {
            return new Bishop(Position, Color);
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece p, Board board)
        {
            var result = new List<Position>();
            var bishopDirections = GetBishopMoves();
            foreach (var d in bishopDirections)
                result.AddRange(GetPositionsInDirection(board, p, d));
            return result;
        }

        private static List<Position> GetPositionsInDirection(Board board, Piece piece, Position direction)
        {
            var result = new List<Position>();
            int x = piece.Position.X;
            int y = piece.Position.Y;

            while (true)
            {
                x += direction.X;
                y += direction.Y;
                var newPos = new Position(x, y);
                if (!newPos.IsInBoard())
                    break;
                if (board.GetPieceWithPosition(newPos) == null)
                    result.Add(newPos);
                else
                {
                    if (board.CanPieceMoveTo(piece, newPos))
                        result.Add(newPos);
                    break;
                }
            }
            return result;
        }
    }

    public class Queen : Piece
    {
        public override PieceType Type => PieceType.QUEEN;
        public Queen()
        {

        }
        public Queen(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static Queen? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new Queen(startingPosition, color);
            return null;
        }

        public override Piece Clone()
        {
            return new Queen(Position, Color);
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

        public King() : base() { }
        public King(Position startingPosition, ColorType color) : base(startingPosition, color)
        {
        }

        public static King? Create(Position startingPosition, ColorType color)
        {
            if (CanCreatePiece(startingPosition))
                return new King(startingPosition, color);
            return null;
        }

        public override Piece Clone()
        {
            return new King(Position, Color);
        }

        public override List<Position> GetPosiblePositions(Board board)
        {
            return GetPosiblePositions(this, board);
        }

        public static List<Position> GetPosiblePositions(Piece piece, Board board)
        {
            var result = new List<Position>();
            var directions = GetKingMoves();
            foreach (var direction in directions)
            {
                var newPos = new Position(piece.Position.X + direction.X, piece.Position.Y + direction.Y);
                if (board.CanPieceMoveTo(piece, newPos))
                    result.Add(newPos);
            }
            return result;
        }
    }
}
