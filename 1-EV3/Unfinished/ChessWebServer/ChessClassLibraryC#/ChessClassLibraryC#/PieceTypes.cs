using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibraryC_
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
            var result = new List<Position>();
            for (int x = -1; x <= 1; x++)
            {
                var position = new Position(x, Position.x * (int)Color);
                if (position.isValid())
                    result.Add(position);
            }
            return result;
        }
    }

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
            return GetPosiblePositions(Position);
        }

        public static List<Position> GetPosiblePositions(Position position)
        {
            var result = new List<Position>();
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
