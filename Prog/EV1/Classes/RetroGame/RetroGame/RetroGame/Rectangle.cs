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
        
        public Rectangle(RectType rectType)
        {
            SetRGBA(new rgba_f32(0.51f, 0.39f, 0.45f, 1));
            if (rectType == RectType.ENEMY)
            {
                coor.SetWidth(12);
                coor.SetHeight(5.6);
                
            }

            else if (rectType == RectType.PLAYER)
            {
                coor.SetWidth(20);
                coor.SetHeight(6);
            }
        }
    }
}
