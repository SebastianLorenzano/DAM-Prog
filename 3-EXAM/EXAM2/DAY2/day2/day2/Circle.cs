using System.Drawing;

namespace day2
{
    public class Circle : Shape
    {
        public double Radio {  get; set; }
        public override bool HasArea => true;
        public override double Area => Math.PI * (Radio * Radio);
        public override double Perimeter => 2 * Math.PI * Radio;

        public override Point2D Center { get; }

        public override Rect2D Rect => GetBoundingBox();

        public Circle(Point2D point, double radio, string name, Color color) : base(name, color)
        {
            if (point != null)
                Center = point;
            else
                Center = new Point2D();
            Radio = radio;
        }

        public Rect2D GetBoundingBox()
        {
            var points = new Point2D[2];
            points[0] = new Point2D() { X = Center.X - Radio, Y = Center.Y - Radio };
            points[1] = new Point2D() { X = Center.X + Radio, Y = Center.Y + Radio };
            return Utils.GetBoundingBox(points);
        }
    }
}
