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
            Character? p1 = world.GetCharacterAt(0);
            if (p1 != null)
                if (world.map.HitLeftWall(p1.rect) == false && keyboard.IsKeyDown(Keys.A))
                    p1.rect.x -= 0.05;
                if (world.map.HitRightWall(p1.rect) == false && keyboard.IsKeyDown(Keys.D))
                    p1.rect.x += 0.05;
                if (world.map.HitTopWall(p1.rect) == false && keyboard.IsKeyDown(Keys.W))
                    p1.rect.y += 0.05;
                if (world.map.HitBottomWall(p1.rect) == false && keyboard.IsKeyDown(Keys.S))
                    p1.rect.y -= 0.05;
        }
        
        public void OnAnimate(GameDelegateEvent gameEvent)
        {
            for (int i = 1; i < world.GetCharacterCount(); i++)
                world.MoveEnemies(i);
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

