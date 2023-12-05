using System;
using UDK;

namespace RetroGame
{
    public class Object
    {
        double _x;
        double _y;
        rgba_f32 _rgba = new rgba_f32();
        public double GetX()
        {
            return _x;
        }

        public double GetY()
        {
            return _y;
        }

        public virtual void SetX(double x)
        {
            _x = x;
        }

        public virtual void SetY(double y)
        {
            _y = y;
        }

        public double GetR()
        {
            return _rgba.r;
        }

        public double GetG()
        {
            return _rgba.g;
        }

        public double GetB()
        {
            return _rgba.b;
        }

        public double GetA()
        {
            return _rgba.a;
        }

        public void SetRGBA(rgba_f32 rgba)
        {
            _rgba.r = rgba.r;
            _rgba.g = rgba.g;
            _rgba.b = rgba.b;
            _rgba.a = rgba.a;
        }
    }
}
