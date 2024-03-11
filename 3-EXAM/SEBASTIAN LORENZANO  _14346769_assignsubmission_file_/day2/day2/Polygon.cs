using System.Threading.Channels;

namespace day2
{
    public class Polygon : Shape
    {
        private Point2D[] points = Array.Empty<Point2D>();

        public bool IsClosed = false;
        public int PointCount => points.Length;
        public override bool HasArea => IsClosed;
        public override double Area => IsClosed ? Utils.GetArea(points) : 0;
        public override double Perimeter => Utils.GetPerimeter(points);
        public override Point2D Center => GetCenter();
        public override Rect2D Rect => Utils.GetBoundingBox(points);

        public Polygon(string name, Color color) : base(name, color)
        {

        }

        public Point2D GetCenter()
        {
            // Javi: PERO QUE HACES INSENSATO!!!?!!?!??!?!!?!?!?!?!?!?!?!?!?!?!?
            // ESTO YA LO TIENES HECHO!!!!!
            double MinX = 0, MinY = 0, MaxX = 0, MaxY = 0; 
            for (int i = 0; i < points.Length; i++)
            {
                var p = points[i];
                if (p.X < MinX)
                    MinX = p.X;
                else if (p.X > MaxX)
                    MaxX = p.X;
                if (p.Y < MinY)
                    MinY = p.Y;
                else if (p.Y > MaxY)
                    MaxY = p.Y;      
            }
            return new Point2D()
            {
                X = MinX + (MaxX - MinX) / 2,
                Y = MinY + (MaxY - MinY) / 2
            };
        }

        public void Clear()
        {
            points = new Point2D[0];
        }

        public void Open()
        {
            IsClosed = false;
        }
        public void Close()
        {
            IsClosed = true;
        }

        public void AddPoint(Point2D point)
        {
            if (point == null)
                return;
            var result = new Point2D[points.Length + 1];
            for (int i = 0; i < points.Length; ++i) 
            {
                result[i] = points[i];
            }
            result[points.Length] = point;
            points = result;
        }

        public Point2D? GetPointAt(int index)
        {
            if (index < 0 || index >= points.Length)
                return null;
            return points[index];
        }

    }
}
