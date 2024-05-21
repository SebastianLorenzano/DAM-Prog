
using System;

namespace Model
{

    public class Position
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public bool isValid()
        {
            return X > 0 && X <= Board.WIDTH && Y > 0 && Y <= Board.HEIGHT;
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


