using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDK;

namespace RetroGame
{
    public enum RectType
    {
        PLAYER,
        ENEMY
    }

    public enum StateType
    {
        NEW,
        DAMAGED,
        ONEHIT,
        DESTROYED
    }

    /*
    DIFERENT RGB FOR DIFFERENT STATES
    IsHit()


    
    

    */
    public class Rectangle : Object
    {
        RectType type;

        public Rectangle(RectType rectType, double x, double y)
        {
            if (rectType == RectType.ENEMY)
            {
                coor.SetWidth(12);
                coor.SetHeight(5.6);
                SetRGBA(new rgba_f32(0.51f, 0.39f, 0.45f, 1));

            }

            else if (rectType == RectType.PLAYER)
            {
                coor.SetWidth(20);
                coor.SetHeight(6);
                SetRGBA(new rgba_f32(0.51f, 0.39f, 0.45f, 1));
                SetX(x);
                SetY(y);
            }
        }
        public Rectangle(RectType rectType)
        {
            
            if (rectType == RectType.ENEMY)
            {
                coor.SetWidth(12);
                coor.SetHeight(5.6);
                SetRGBA(new rgba_f32(0.51f, 0.39f, 0.45f, 1));


            }

            else if (rectType == RectType.PLAYER)
            {
                coor.SetWidth(20);
                coor.SetHeight(6);
                SetRGBA(new rgba_f32(0.51f, 0.39f, 0.45f, 1));
            }
        }

       
        public void SetX(double x, double mapX, double mapWidth)
        {
            if (x + GetMiddleX() > mapX && x + GetMiddleX() < mapWidth)
                coor.SetMiddleX(x);
        }

        public void SetY(double y, double mapY, double mapHeight)
        {
            if (y + GetMiddleY() > mapY && y + GetMiddleY() < mapHeight)
                coor.SetMiddleY(y);
        }
    }
}
