namespace day2
{
    public class Point : Shape
    {
        public int x, y;

        public override bool HasArea => false;

        public override double Area => 0;

        public override double Perimeter => 0;

        public override Point2D Center => ToPoint2D();

        public override Rect2D Rect => GetBoundingBox();

        public Point(int x, int y, string name, Color color) : base(name, color)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D ToPoint2D()
        {
            return new Point2D() { X = x, Y = y };
        }

        public Rect2D GetBoundingBox()
        {
            var points = new Point2D[1];
            points[0] = new Point2D() { X = x, Y = y };
            return Utils.GetBoundingBox(points);
        }

    }
}
