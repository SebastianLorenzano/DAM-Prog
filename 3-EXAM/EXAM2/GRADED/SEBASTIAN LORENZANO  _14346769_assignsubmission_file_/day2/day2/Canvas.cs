namespace day2
{
    public class Point2D
    {
        public double X, Y;
    }

    public class Rect2D
    {

        public double MinX, MinY, MaxX, MaxY;

        public double Area => GetArea();

        public Point2D Center => GetCenter();


        protected double GetArea()
        {
            return (MaxX - MinX) * (MaxY - MinY);       //Chequear matematica despues si hay tiempo
        }

        protected Point2D GetCenter()
        {

            return new Point2D()
            {
                // Javi: No, es directamente (max + min) / 2, ..., ..., ... mmmmm
                // Pero como tu lo haces también es correcto, ..., pero con más cálculo
                X = MinX + (MaxX - MinX) / 2,   //Chequear matematica despues si hay tiempo
                Y = MinY + (MaxY - MinY) / 2
            };
        }
    }


    public class Color
    {
        public double R, G, B, A;
    }

    public interface ICanvas
    {
        int Width { get; }
        int Height { get; }
        Color CurrentColor { get; }

        void SetColor(Color color);
        void DrawRectangle(Rect2D rectangle);
        void DrawCircle(Rect2D rectangle);
        void DrawPolygon(Point2D[] points);
    }

    public class Canvas : ICanvas
    {
        private Color _color = new Color();

        public int Width => 1920;

        public int Height => 1080;

        public Color CurrentColor => throw new NotImplementedException();

        public void DrawCircle(Rect2D rectangle)
        {
            Console.WriteLine($"Dibujando el círculo {GetRectString(rectangle)} con el color {GetColorString()}");
        }

        private static string GetRectString(Rect2D rectangle)
        {
            return $"({rectangle.MinX}, {rectangle.MinY}, {rectangle.MaxX}, {rectangle.MaxY})";
        }

        private static string GetPolygonString(Point2D[] points)
        {
            string ret = "";
            foreach (var point in points)
                ret += "(" + point.X + "," + point.Y + ")";
            return ret;
        }

        private string GetColorString()
        {
            return $"({_color.R}, {_color.G}, {_color.B}, {_color.A})";
        }

        public void DrawPolygon(Point2D[] points)
        {
            Console.WriteLine($"Dibujando el polígono {GetPolygonString(points)} con el color {GetColorString()}");
        }

        public void DrawRectangle(Rect2D rectangle)
        {
            Console.WriteLine($"Dibujando el rectángulo {GetRectString(rectangle)} con el color {GetColorString()}");
        }

        public void SetColor(Color color)
        {
            if (color != null)
            {
                _color = color;
            }
        }
    }
}
