

namespace ConsoleApp1
{
    public abstract class ShapeWithoutArea : Shape
    {
        public override bool HasArea()
        {
            return false;
        }

        public override double GetArea()
        {
            return 0;
        }


    }
} 
