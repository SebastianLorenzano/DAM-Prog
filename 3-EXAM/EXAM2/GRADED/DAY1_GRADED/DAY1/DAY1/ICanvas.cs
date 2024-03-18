using System.Drawing;

namespace DAY1
{
    public interface ICanvas
    {
        int Width { get; }
        int Height { get; }
        Color CurrentColor { get; }
        void SetColor (Color color);
        void DrawRectangle(Rect2D rectangle);
        void DrawCircle(Rect2D circle);
        void DrawPolygon(Point2D[] points);


    }
}
