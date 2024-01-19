
namespace ConsoleApp1
{
    public abstract class Shape : IShape
    {
        protected Point2D _position = new Point2D();
        private string _name = "";

        public abstract double GetArea();

        public virtual string GetName()
        {
            return _name;
        }

        public virtual void SetName(string name)
        {
            if (name != null)
                _name = name;
        }

        public abstract Point2D GetPosition();

        public abstract Shape GetShapeType();

        public abstract bool HasArea();

        public abstract void SetName();

        public virtual void SetPosition(Point2D position)
        {
            _position = position;
        }
    }
}
