
namespace ChessClassLibraryC_
{

    public class Position
    {
        private int _x;
        private int _y;

        public int x => _x;
        public int y => _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public bool isValid()
        {
            return _x > 0 && _x <= Board.WIDTH && _y > 0 && _y <= Board.HEIGHT;

        }
    }

    public class Utils
    {
    }
}
