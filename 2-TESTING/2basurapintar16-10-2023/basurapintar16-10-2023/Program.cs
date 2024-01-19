using System.Security.Cryptography.X509Certificates;
using UDK;

namespace basurapintar16_10_2023
{
    internal class Program
    {
        public class Character
        {
            public double x, y, red, green, blue, alpha;
        }
        public class MyGame : UDK.IGameDelegate
        {
            List<Character> characters;
            //double x1 = 5, y1 = 5, xdirection = 1, ydirection = 1;

            public void OnLoad(GameDelegateEvent gameEvent)
            {
                characters = new List<Character>();
                for (int i = 0; i < 3; i++)
                {
                    Character player;
                    player = new Character();
                    if (i == 0)
                    {
                        player.red = 1.0;
                        player.green = 0.0;
                        player.blue = 0.0;
                        player.x = 0.0;
                        player.y = 0.0;
                    }
                    else
                    {
                        player.red = Utils.GetRandom(0.0, 1.0);
                        player.green = Utils.GetRandom(0.0, 1.0);
                        player.blue = Utils.GetRandom(0.0, 1.0);
                        player.x = Utils.GetRandom2(10.0, 40.0);
                        player.y = Utils.GetRandom2(10.0, 40.0);
                    }
                    player.alpha = 1.0;
                    characters.Add(player);
                }
            }
            public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
            {
                if (keyboard.IsKeyDown(Keys.A))
                {
                    //if (player1.x > -8.30)
                    characters[0].x -= 0.01;
                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    //if (player1.x < 48)
                    characters[0].x += 0.01;
                }
                if (keyboard.IsKeyDown(Keys.W))
                {
                    //if (player1.y < 48)
                    characters[0].y += 0.01;
                }
                if (keyboard.IsKeyDown(Keys.S))
                {
                    //if (player1.y > 0.0)
                    characters[0].y -= 0.01;
                }
            }
            public void OnAnimate(GameDelegateEvent gameEvent)
            {
                /*
                if (x1 > 48.0 || x1 < 2.0)
                    xdirection *= -1;
                if (y1 > 48.0 || y1 < 2.0)
                    ydirection *= -1;
                x1 += 0.001 * xdirection;
                y1 += 0.002 * ydirection;
                */

                characters[2].x += Utils.GetRandom(-0.000000001, 0.00000000000001);
            }
            public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
            {
                canvas.Clear(0.0, 0.0, 0.0, 1.0);
                canvas.Camera.SetRectangle(0.0, 0.0, 50.0, 50.0);

                //canvas.FillShader.SetColor(0.5, 1, 1, 1);
                //canvas.DrawRectangle(x1, y1, 2, 2);
                for (int i = 0; i < characters.Count; i++)
                {   if (i != 0)
                        
                    canvas.FillShader.SetColor(characters[i].red, characters[i].green, characters[i].blue, characters[i].alpha);
                    canvas.DrawRectangle(characters[i].x, characters[i].y, 2, 2);
                }
            }
            public void OnUnload(GameDelegateEvent gameEvent)
            {
            }
        }

        static void Main(string[] args)
        {
            MyGame game = new MyGame();
            UDK.Game.Launch(game);

        }
    }
}