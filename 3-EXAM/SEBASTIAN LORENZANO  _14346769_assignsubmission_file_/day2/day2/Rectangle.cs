
namespace day2
{
    public class Rectangle : Shape
    {

        public double MinX, MinY, MaxX, MaxY;

        public override bool HasArea => true;

        public override double Area => Utils.GetArea(ToArray());
        public override double Perimeter => Utils.GetPerimeter(ToArray());

        public override Point2D Center => GetCenter();
        public override Rect2D Rect => ToRect2D();
        public Rectangle(double minX, double minY, double maxX, double maxY, string name, Color color) : base(name, color)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX; 
            MaxY = maxY;
        }
        
        public Point2D[] ToArray()
        {
            var points = new Point2D[2];
            points[0] = new Point2D() { X = MinX, Y = MinY };
            points[1] = new Point2D() { X = MaxX, Y = MaxY };
            return points;
        }
        public double GetArea() => Utils.GetArea(ToArray());

        public double GetPerimeter() => Utils.GetPerimeter(ToArray());

        private Point2D GetCenter()
        {
            return new Point2D()
            {
                X = (MinX + (MaxX - MinX) / 2),
                Y = (MinY + (MaxY - MinY) / 2)
            };
        }

        public Rect2D ToRect2D()
        {
            return new Rect2D() { MinX = MinX, MaxX = MaxX, MinY = MinY, MaxY = MaxY };
        }

        public Point2D? GetCornerWithIndex(int index)
        {
             if (index < 0)
                return null;
             if (index == 0)
                return new Point2D() { X = MinX, Y = MinY };
             if (index == 1)
                return new Point2D() { X = MinX, Y = MaxY };
             if (index == 2)
                return new Point2D() { X = MaxX, Y = MaxY };
             if (index == 3)
                return new Point2D() { X = MaxX, Y = MinY };
             return null;
        }


    }
}
