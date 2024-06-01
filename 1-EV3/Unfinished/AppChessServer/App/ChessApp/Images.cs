using Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessApp
{
    public static class Images
    {

        private static Dictionary<PieceType, ImageSource> whitePaths = new()
        {
            {PieceType.PAWN, LoadImage("Assets/PawnW.png") },
            {PieceType.ROOK, LoadImage("Assets/RookW.png") },
            {PieceType.KNIGHT, LoadImage("Assets/KnightW.png") },
            {PieceType.BISHOP, LoadImage("Assets/BishopW.png") },
            {PieceType.QUEEN, LoadImage("Assets/QueenW.png") },
            {PieceType.KING, LoadImage("Assets/KingW.png") } ,
            };

        private static Dictionary<PieceType, ImageSource> blackPaths = new()
        {
            {PieceType.PAWN, LoadImage("Assets/PawnB.png") },
            {PieceType.ROOK, LoadImage("Assets/RookB.png") },
            {PieceType.KNIGHT, LoadImage("Assets/KnightB.png") },
            {PieceType.BISHOP, LoadImage("Assets/BishopB.png") },
            {PieceType.QUEEN, LoadImage("Assets/QueenB.png") },
            {PieceType.KING, LoadImage("Assets/KingB.png") }
            };

        private static ImageSource? LoadImage(string filePath)
        {
            if (filePath != null)
                return new BitmapImage(new Uri(filePath, UriKind.Relative));
            return null;
        }

        public static ImageSource GetImage(PieceType type, ColorType color)
        {
            if (color == ColorType.WHITE)
                return whitePaths[type];
            return blackPaths[type];
        }

        public static ImageSource? GetImage(Piece piece)
        {
            if (piece == null)
                return null;
            return GetImage(piece.Type, piece.Color);
        }
    }
}
