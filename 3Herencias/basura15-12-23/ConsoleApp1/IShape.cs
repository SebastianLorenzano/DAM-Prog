

namespace ConsoleApp1
{

    public interface IShape
    {
        public Point2D GetPosition();

        public void SetPosition(Point2D position);

        public double GetArea();

        public bool HasArea();

        public string GetName();

        public void SetName();
    }
}
