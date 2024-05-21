
using System;

namespace ChessClassLibraryC_
{

    public class Position
    {
        public int x;
        public int y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public bool isValid()
        {
            return x > 0 && x <= Board.WIDTH && y > 0 && y <= Board.HEIGHT;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }
    }


    public class Utils
    {

    }
}


