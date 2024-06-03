
using System;

namespace Model
{

    public class Position
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Position p1, Position p2)
        {
            if (p1 is null || p2 is null)
            {
                if (p1 is null && p2 is null)
                    return true;
                return false;
            }
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public bool IsInBoard()
        {
            return isInBoard(X, Y);
        }

        public static bool isInBoard(int x, int y)
        {
            return x >= 0 && x <= Board.WIDTH && y >= 0 && y <= Board.HEIGHT;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }
    }


    public class Utils
    {
        public static ColorType GetOpponent(ColorType color)
        {
            return ColorType.WHITE == color ? ColorType.BLACK : ColorType.WHITE;
        }
    }
}


