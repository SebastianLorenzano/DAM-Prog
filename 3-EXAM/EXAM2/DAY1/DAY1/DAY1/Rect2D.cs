using System.Reflection.Metadata.Ecma335;

namespace DAY1
{
    public class Rect2D
    {
        private Point2D[] _points = new Point2D[2];

        public Rect2D(Point2D point1, Point2D point2)
        {
            
            _points[0] = point1;
            _points[1] = point2;
        }

        public bool IsValid() => _points[0] != null && _points[1] != null;

        public override string ToString()
        {
            var p = _points;
            return "(" + p[0].x + ", " + p[0].y + ", " + p[1].x + ", " + p[1].y + ")";
        }
    }
}
