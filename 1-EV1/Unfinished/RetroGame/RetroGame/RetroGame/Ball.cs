using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroGame
{
    public class Ball : Object
    {
        private double _speed = 0.1;
        public Ball(double middleX, double middleY, double width, double height)
        {
            coor.SetWidth(width);
            coor.SetHeight(height);
            coor.SetMiddleX(middleX);
            coor.SetMiddleY(middleY);

        }
        public double GetSpeed() 
        { 
            return _speed;
        }

        public void SetSpeed(double speed)
        {
            if (speed >= 0 && speed < 20) 
                _speed = speed;
        }

    }
}
