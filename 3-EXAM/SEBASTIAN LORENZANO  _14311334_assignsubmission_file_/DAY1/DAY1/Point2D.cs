// Javi:Y este using!?!?!?
using System.Reflection.Metadata.Ecma335;

namespace DAY1
{
    public class Point2D
    {
        public double x, y;
        public Point2D(double x, double y)
        {      
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {

            return "(" + x + ", " + y + ")";

        }
    }
}
