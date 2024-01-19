using System;
using System.Security.Cryptography;
using UDK;

namespace RetroGame
{
    public class RetroGame : UDK.IGameDelegate
    {
        Map map = new(0, 0, 108, 108);          // Width, Height, x, y
        public void OnLoad(GameDelegateEvent gameEvent)
        {
            map.CreatePlayerRectangle();
            map.CreateRectangles(64);
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            //if (keyboard.IsKeyDown(Keys.A))
            //    p1.x -= 0.05;
            //if (keyboard.IsKeyDown(Keys.D))
            //    p1.x += 0.05;
        }


        public void OnAnimate(GameDelegateEvent gameEvent)
        {

        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            {
                canvas.Clear(1, 1, 1, 1);
                map.DrawAll(canvas);
            }

        }


        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
}
