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

        protected int _x, _y, _width, _height;
        protected double r, g, b;
        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public double GetR()
        {
            return r;
        }

        public double GetG()
        {
            return g;
        }

        public double GetB()
        {
            return b;
        }

        public void SetX(int x)
        {
            _x = x;
        }

        public void SetY(int y)
        {
            _y = y;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }
    }
}
