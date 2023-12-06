using System;
using System.Security.Cryptography;
using UDK;

namespace RetroGame
{
    public class RetroGame
    {
        Map map = new();
        public void OnLoad()
        {

        }

        public void OnKeyboard(IKeyboard keyboard, IMouse mouse)
        {
            if (keyboard.IsKeyDown(Keys.A))
                p1.x -= 0.05;
            if (keyboard.IsKeyDown(Keys.D))
                p1.x += 0.05;
        }


        public void OnAnimate()
        {

        }

        public void OnDraw(ICanvas canvas)
        {
            {
                canvas.Clear(0, 0, 0, 1);
                map.DrawAll(canvas);
            }

        }


        public void OnUnload()
        {

        }
    }
}
