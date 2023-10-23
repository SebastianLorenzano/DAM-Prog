using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PintarMyGame
{
    public class Rectangle
    {
        public double x, y, width, height;

        public double GetLeft()
        { 
            return x;
        }
        public double GetRight()
        {
            return x + width;
        }
        public double GetTop()
        {
            return y + height;
        }
        public double GetBottom()
        {
            return y;
        }
        public bool IsIntercepting(Rectangle rect1)
        {
            if (GetLeft() <= rect1.GetRight())
                if (GetTop() <= rect1.GetBottom())
                    return true;
            if (GetRight() <= rect1.GetLeft())
                if (GetBottom() <= rect1.GetTop())
                    return true;
            return false;
        }
    }
    public class Character
    {
        public Rectangle rect = new Rectangle();
        public double r, g, b, a;
    }
}
