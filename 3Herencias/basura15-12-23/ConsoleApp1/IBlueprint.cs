
namespace ConsoleApp1
    
{
    public interface IBlueprint
    {
        public void AddShape(IShape shape);

        public int GetShapeCount();

        public IShape? GetShapeAt(int index);

        public void RemoveShapeAt(int index);

        public double GetArea();

    }
}
