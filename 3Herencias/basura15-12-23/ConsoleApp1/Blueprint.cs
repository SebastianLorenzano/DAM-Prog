

namespace ConsoleApp1
{
    public abstract class Blueprint : IBlueprint
    {
        public void AddShape(IShape shape)
        {
            throw new NotImplementedException();
        }

        public double GetArea()
        {
            throw new NotImplementedException();
        }

        public IShape? GetShapeAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetShapeCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveShapeAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
