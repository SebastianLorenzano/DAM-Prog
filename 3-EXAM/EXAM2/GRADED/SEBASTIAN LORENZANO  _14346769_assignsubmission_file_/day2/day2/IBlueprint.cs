namespace day2
{
    public interface IBlueprint
    {
        delegate bool FilterDelegate(IShape shape);
        void AddShape(IShape shape);
        void RemoveShapeWithName(string name);
        IShape GetShapeWithName(string name);
        List<IShape> GetShapes(FilterDelegate del);
        void Draw(ICanvas canvas);

    }
}
