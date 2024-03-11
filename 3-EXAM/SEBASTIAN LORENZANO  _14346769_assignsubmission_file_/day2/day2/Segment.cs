
namespace day2
{
    public class Segment : Shape
    {
        public Point2D point1, point2;
        private Point2D[] Points => new Point2D[2] { point1, point2 };
        public override bool HasArea => false;

        public override double Area => 0;

        public override double Perimeter => Utils.GetPerimeter(Points);

        public override Point2D Center => GetCenter();

        public override Rect2D Rect => Utils.GetBoundingBox(Points);

        public Segment(Point2D point1,  Point2D point2, string name, Color color) : base(name, color)
        {
            if (point1 == null)
                this.point1 = new Point2D();
                
            else
                this.point1 = point1;

            if (point2 == null)
                this.point2 = new Point2D();
            else
                this.point2 = point2;
        }

        private Point2D GetCenter()
        {
            var points = Points;
            return new Point2D()
            {
                X = points[0].X + (points[1].X - points[0].X) / 2,
                Y = points[0].Y + (points[1].Y - points[0].Y) / 2,
            };
        }
    }
}
