using System;
using UDK;

namespace RetroGame
{

    public class Coordenates
    {
        public double middleX, middleY, widthDiv2, heightDiv2;

        public Coordenates()
        {

        }

        public Coordenates(double x, double y,double width, double height)
        {
            middleX = x + width/2;
            middleY = y + height/2;
            widthDiv2 = width / 2;
            heightDiv2 = height / 2;
        }

        public double GetX()
        {
            return middleX - widthDiv2;
        }

        public double GetY()
        {
            return middleY - heightDiv2;
        }

        public double GetWidth() 
        {
            return widthDiv2 * 2;
        }

        public double GetHeight()
        {
            return heightDiv2 * 2;
        }
    }
  

    public class Object
    {

        protected Coordenates coor;
        protected rgba_f32 _rgba = new rgba_f32();

        public Object() 
        {
            coor = new Coordenates();
        }

        public Object(double x, double y, double width,double height)
        {
            coor = new Coordenates(x,y,width,height);
        }

        public double GetX()
        {
            return coor.GetX();
        }

        public double GetY()
        {
            return coor.GetY();
        }

        public double GetWidth()
        {
            return coor.GetWidth();
        }

        public double GetHeight()
        {
            return coor.GetHeight();
        }

        public virtual void SetX(double x)
        {
            coor. = x;
        }

        public virtual void SetY(double y)
        {
            coor.y = y;
        }


        public virtual void SetWidth(double w)
        {
            _width = w;
        }

        public virtual void SetDouble(double h)
        {
            _height = h;
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
