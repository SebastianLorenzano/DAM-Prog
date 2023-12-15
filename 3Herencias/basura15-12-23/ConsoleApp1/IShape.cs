

namespace ConsoleApp1
{
    public enum ShapeType
    {
        UKNOWN,
        RECT2D,
        CIRCLE2D,
        POLYLINE2D,
        POINTSHAPE2D,
        SEGMENT2D
    }

    public interface IShape
    {
        public Point2D GetPosition();

        public void SetPosition(Point2D position);

        public double GetArea();

        public bool HasArea();

        public ShapeType GetShapeType();

        public string GetName();

        public void SetName();
    }
}
