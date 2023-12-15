
namespace ConsoleApp1
{
    public abstract class Shape : IShape
    {
        protected Point2D _position;
        private string? _name;

        public abstract double GetArea();

        public string GetName()
        { 
        }

        public abstract Point2D GetPosition();

        public abstract ShapeType GetShapeType();

        public abstract bool HasArea();

        public abstract void SetName();

        public virtual void SetPosition(Point2D position)
        {
            _position = position;
        }
    }
}
