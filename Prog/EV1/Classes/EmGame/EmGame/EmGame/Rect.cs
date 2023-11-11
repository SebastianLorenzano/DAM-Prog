using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmGame
{

    public class Rect
    {

        public int x, y, width, height;
        public double r, g, b;
        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public static int GetWidth(WarZone warzone)
        {
            return warzone.rect.height;
        }
    }
}
