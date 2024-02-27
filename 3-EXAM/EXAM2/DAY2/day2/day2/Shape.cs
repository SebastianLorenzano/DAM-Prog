namespace day2
{
    public abstract class Shape : IShape
    {
        protected string _name = "";
        private Color _color;


        public string Name 
        { 
            get => _name;
            set 
            {
                if (value != null)
                    _name = value;
            } 
        }
        public Color Color 
        { 
            get => _color;
            set 
            {
                if (value != null)
                    _color = value;
            } 
        }

        public abstract bool HasArea { get; }

        public abstract double Area { get; }

        public abstract double Perimeter { get; } 

        public abstract Point2D Center { get; }

        public abstract Rect2D Rect { get; }

        public Shape(Color color)
        {
            if (color == null)
                _color = new Color();
            else
                _color = color;

        }
        public Shape(string name, Color color) : this(color) 
        {
            if (name != null)
                _name = name;
        }


        public virtual void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);
        }
    }
}
