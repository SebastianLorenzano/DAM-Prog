using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDK;

namespace PintarMyGame
{
    internal class MyGame : UDK.IGameDelegate
    {
        World world = new World();
        public void OnLoad(GameDelegateEvent gameEvent)
        {
            for (int i = 0; i < 1; i++)
                world.AddPlayer();
            for (int i = 0;i < 50;i++)
                world.AddEnemies();
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {
            Character p1 = world.characters[0];
            if (world.HitLeftWall(p1) != true)
                if (keyboard.IsKeyDown(Keys.A))
                    p1.x -= 0.05;
            if (world.HitRightWall(p1) != true)
                if (keyboard.IsKeyDown(Keys.D))
                    p1.x += 0.05;
            if (world.HitTopWall(p1) != true)
                if (keyboard.IsKeyDown(Keys.W))
                    p1.y += 0.05;
            if (world.HitBottomWall(p1) != true)
                if (keyboard.IsKeyDown(Keys.S))
                    p1.y -= 0.05;
        }

        public void OnAnimate(GameDelegateEvent gameEvent)
        {

        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            world.DrawAll(canvas);
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
}

