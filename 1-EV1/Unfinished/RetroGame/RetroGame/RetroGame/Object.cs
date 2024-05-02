using System;
using UDK;

namespace RetroGame
{

    public class Coordenates                // Esta es la primera prueba de usar el punto en el centro de la figura como medida
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

        public void SetMiddleX(double x, double width = 0)   //Esto convierte x en MiddleX
        {
            if (width == 0)
                width = widthDiv2 * 2;
            middleX = x + width/2;
        }

        public void SetMiddleY(double y, double height = 0) 
        {
            if (height == 0)
                height = heightDiv2 * 2;
            middleY = y + height/2;
        }

        public void SetWidth(double width)
        {
            widthDiv2 = width / 2;
        }

        public void SetHeight(double height)
        {
            heightDiv2 = height / 2;
        }
        public Coordenates CloneCoor() 
        {
            return new Coordenates(middleX, middleY, widthDiv2 * 2, heightDiv2 * 2);
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
            coor.SetMiddleX(x);                 // Si esta dentro de los parametros permitidos
        }

        public virtual void SetY(double y)
        {
            coor.SetMiddleX(y);
        }

        public double GetMiddleX()
        {
            return coor.middleX;
        }

        public double GetMiddleY()
        {
            return coor.middleY;
        }


        public virtual void SetWidth(double w)
        {
            if (w < 0)
                coor.SetWidth(w);
        }

        public virtual void SetDouble(double h)
        {
            if (h < 0)
                coor.SetWidth(h);
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
