using System.Threading.Channels;

namespace day2
{
    public class Polygon : Shape
    {
        private Point2D[] _points = Array.Empty<Point2D>();

        public bool IsClosed = false;
        public int PointCount => _points.Length;
        public override bool HasArea => IsClosed;
        public override double Area => IsClosed ? Utils.GetArea(_points) : 0;
        public override double Perimeter => Utils.GetPerimeter(_points);
        public override Point2D Center => GetCenter();
        public override Rect2D Rect => Utils.GetBoundingBox(_points);

        public Polygon(string name, Color color) : base(name, color)
        {

        }

        public Point2D GetCenter()
        {
            double MinX = 0, MinY = 0, MaxX = 0, MaxY = 0; 
            for (int i = 0; i < _points.Length; i++)
            {
                var p = _points[i];
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
            _points = new Point2D[0];
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
            var result = new Point2D[_points.Length + 1];
            for (int i = 0; i < _points.Length; ++i) 
            {
                result[i] = _points[i];
            }
            result[_points.Length] = point;
            _points = result;
        }

        public Point2D? GetPointAt(int index)
        {
            if (index < 0 || index >= _points.Length)
                return null;
            return _points[index];
        }

    }
}
