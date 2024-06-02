
using System.Drawing;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Model
{
    public class Board
    {
        public const int WIDTH = 7;
        public const int HEIGHT = 7;
        public bool wasSaved = false;
        public List<Piece> PiecesList { get; private set; } = new List<Piece>();
        private Piece[,] _pieces {  get; set; } = new Piece[8, 8];
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

        public ColorType GetCurrentPlayer()
        {
            if (Turn % 2 == 0)
                return ColorType.WHITE;
            return ColorType.BLACK;
        }

        public List<Position> GetPossiblePositionsForPlayer(ColorType color)
        {
            var result = new List<Position>();
            GetPiecePositions().ForEach(pos =>
            {
                var piece = GetPieceWithPosition(pos);
                if (piece != null && piece.Color == color)
                    result.AddRange(piece.GetPosiblePositions(this));
            });
            return result;
        }

        public List<Position> GetPiecePositions()
        {
            var result = new List<Position>();
            for (int x = 0; x <= WIDTH; x++)
            {
                for (int y = 0; y <= HEIGHT; y++)
                {
                    var piece = GetPieceWithPosition(x, y);
                    if (piece != null)
                        result.Add(new Position(x, y));
                }
            }
            return result;
        }

        public Piece? GetKing(ColorType color)
        {
            var piecesPos = GetPiecePositions();
            foreach (var pos in piecesPos)
            {
                var piece = GetPieceWithPosition(pos);
                if (piece != null && piece.Type == PieceType.KING && piece.Color == color)
                    return piece;
            }
            return null;
        }

        public bool CanPieceMoveTo(Piece piece, Position destinePos)
        {
            if (destinePos.IsInBoard() && piece.Position != destinePos)
            {
                Piece? other = GetPieceWithPosition(destinePos);
                return (other == null || piece.Color != other.Color);
            }
            return false;
        }

        public List<Position> GetLegalMovements(Piece piece, List<Position> destinePositions)
        {
            var result = new List<Position>();
            if (piece == null || destinePositions == null)
                return result;
            
            foreach (var pos in destinePositions)
            {
                if (IsMovementLegal(piece, pos))
                    result.Add(pos);
            }
            return result;
        }
        private bool IsMovementLegal(Piece piece, Position destinePos)  
        {
            var boardClone = Clone();
            boardClone.MakeMove(piece.Position, destinePos);
            return !boardClone.IsKingInCheck(piece.Color);
        }

        public bool IsKingInCheck(ColorType color)
        {
            var king = GetKing(color);
            if (king == null)
                return false;
            var possibleEnemyMoves = GetPossiblePositionsForPlayer(Utils.GetOpponent(color));
            foreach (var pos in possibleEnemyMoves)
            {
                if (pos.X == king.X && pos.Y == king.Y)
                    return true;
            }
            return false;

        }

        public void MakeMove(Position initialPos, Position destinePos)
        {
            if (initialPos == null || destinePos == null || !initialPos.IsInBoard() || !destinePos.IsInBoard())
                return;
            var p = GetPieceWithPosition(initialPos);
            if (p != null)
            {
                _pieces[p.X, p.Y] = null;
                p.SetPosition(destinePos);
                _pieces[p.X, p.Y] = p;
                Turn++;
                wasSaved = false;
            }

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

        public Board Clone()
        {
            var result = new Board();
            foreach (var pos in GetPiecePositions())
            {
                var piece = GetPieceWithPosition(pos);
                if (piece != null)
                    result.AddPiece(piece.Clone());
            }
            return result;
        }

        public string ToJson()
        {
            foreach (var piece in _pieces)
            {
                   if (piece != null)
                    PiecesList.Add(piece);
            }
            return JsonSerializer.Serialize(this);
        }

        public void Deserialize()
        {
            foreach (var piece in PiecesList)
               _pieces[piece.X, piece.Y] = piece;
            PiecesList.Clear();
        }
    }
}
