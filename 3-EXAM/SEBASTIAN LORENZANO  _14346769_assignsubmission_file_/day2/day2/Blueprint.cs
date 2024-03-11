
namespace day2
{
    public class Blueprint : IBlueprint
    {
        private List<IShape> _shapes = new();

        public void AddShape(IShape shape)
        {
            if (shape != null)
                _shapes.Add(shape);
        }

        public List<IShape> GetShapes(IBlueprint.FilterDelegate del)
        {
            // Javi: Mejor esto
            //var result = new List<IShape>();
            //if (del == null)
            //    return result;

            if (del == null)
                return new List<IShape>();
            var result = new List<IShape>();
            for (int i = 0; i < _shapes.Count; i++) 
            {
                var shape = _shapes[i];
                if (del(shape))
                    result.Add(shape);
            }
            return result;
        }

        public IShape? GetShapeWithName(string name)
        {
            if (name  == null)
                return null;
            for (int i = 0; i < _shapes.Count; ++i) 
            {
                var shape = _shapes[i];
                if (shape.Name == name) 
                    return shape;
            }
            return null;

        }

        public void RemoveShapeWithName(string name)
        {
            if (name != null)
            {
                // Javi: Salvado por la campana
                int index = GetIndexOfWithName(name);
                if (index >= 0)
                    _shapes.RemoveAt(index);
            }
        }

        private int GetIndexOfWithName(string name)
        {
            for (int i = 0; i < _shapes.Count; ++i)
            {
                var shape = _shapes[i];
                if (shape.Name == name)
                    return i;
            }
            return -1;
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in _shapes)
                shape.Draw(canvas);
        }
    }
}
