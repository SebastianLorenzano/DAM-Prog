using System;

namespace day2
{
    public class Utils
    {
        public static double GetDistance(Point2D p1, Point2D p2)
        {
            if (p1 == null || p2 == null) 
                return -1;

            // Javi: Esta no es la fórmula
            return Math.Sqrt((p1.X - p2.X) * (p1.X + p2.X) + (p2.Y - p1.Y) * (p2.Y + p1.Y));
        }

        public static Rect2D GetBoundingBox(Point2D[] points)                                         //→ Devuelve un Rect2D que es el rectángulo mínimo que envuelve los puntos que se le pasan como parámetro.
        {
            if (points == null || points.Length == 0)
                return new Rect2D();
            if (points.Length == 1)
                return new Rect2D(){MinX = points[0].X, MinY = points[0].Y, MaxY = points[0].X, MaxX = points[0].X,};

            double MinX = 0, MinY = 0, MaxX = 0, MaxY = 0;

            foreach (Point2D p in points) 
            {
                if (p.X < MinX)
                    MinX = p.X;
                else if (p.X > MaxX)
                    MaxX = p.X;
                if (p.Y < MinY)
                    MinY = p.Y;
                else if (p.Y > MaxY)
                    MaxY = p.Y;
            }
            // Javi: Muy bien ;)
            return new Rect2D()
            {
                MinX = MinX,
                MinY = MinY,
                MaxX = MaxX,
                MaxY = MaxY
            };
        }

        public static double GetArea(Point2D[] points)
        {
            if (points == null || points.Length <= 1)
                return 0;
            double result = 0;
            Point2D p0;
            Point2D p1;
            for (int i = 1; i < points.Length; i++)
            {
                p0 = points[i - 1];
                p1 = points[i];
                result += (p0.Y + p1.Y) * (p0.X - p1.X);
            }
            p0 = points[points.Length - 1];
            p1 = points[0];
            result += (p0.Y + p1.Y) * (p0.X - p1.X);

            return result * 0.5;
        }

        public static double GetPerimeter(Point2D[] points) 
        {
            if (points == null || points.Length <= 1)
                return 0;
            double result = 0;

            for (int i = 1; i < points.Length; i++)
            {
                result += GetDistance(points[i - 1], points[i]);
            }
            result += GetDistance(points[points.Length - 1], points[0]);

            return result;
        }
    }
}
