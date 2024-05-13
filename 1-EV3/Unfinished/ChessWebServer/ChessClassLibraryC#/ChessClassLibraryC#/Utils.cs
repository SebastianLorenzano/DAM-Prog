
namespace ChessClassLibraryC_
{

    public class Position
    {
        public int x;
        public int y;

        public bool isValid()
        {
            return x > 0 && x <= 7 && y > 0 && y <= 7;

        }
    }

    public class Utils
    {
    }
}
