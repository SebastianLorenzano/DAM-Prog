using System.Drawing;

namespace DAY1
{
    public class Program
    {
        // Javi: NOTA 9
        static void Main(string[] args)
        {
            ICanvas pepe = new CanvasConsole();
            Rect2D rectangle = new Rect2D(new Point2D(1, 1), new Point2D(1, 1));
            Point2D[] points = new Point2D[5];
            points[0] = new Point2D(1, 1);
            points[1] = new Point2D(1, 1);
            points[2] = new Point2D(1, 1);
            points[3] = new Point2D(1, 1);
            points[4] = new Point2D(1, 1);

            pepe.DrawPolygon(points);
            pepe.DrawRectangle(rectangle);
            pepe.DrawCircle(rectangle);
        }
    }
}
