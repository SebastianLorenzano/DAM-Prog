using OpenTK.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UDK;

namespace PintarMyGame
{

    public class Map
    {
        public Rectangle rect = new Rectangle();
        public double x = 2.5,
                      y = 2.5,
                      width = 45,
                      height = 45;
        public double   r = 1,
                        g = 1, 
                        b = 1;

        public bool HitLeftWall(Rectangle other)
        {
            return other.x <= rect.x;
        }
        public bool HitRightWall(Rectangle other)
        {
            return rect.GetRight() + 2 > other.GetRight();
        }
        public bool HitTopWall(Rectangle other)
        {
            return rect.GetTop()  + 2> other.GetTop();
        }
        public bool HitBottomWall(Rectangle other)
        {
            return rect.GetBottom() > other.GetBottom();
        }
    }
    public class World
    {
        private List<Character> characters = new List<Character>();
        public Map map = new Map();

        public int GetCharacterCount()
        {
            return characters.Count;
        }

        public Character GetCharacterAt(int index)
        {
            if (index < 0 || index >= characters.Count)
                return null;
            return characters[index];
        }

        public void AddPlayer()
        {
            Character player = new Character();
            player.rect.x = 4.5;
            player.rect.y = 4.5;
            player.r = 0;
            player.g = 0;
            player.b = 1;
            player.a = 1;
            characters.Add(player);
        }
        public void AddEnemies()
        {
            Character enemy = new Character();
            enemy.rect.x = Utils.GetRandom2(6, 44);
            enemy.rect.y = Utils.GetRandom2(6, 44);
            enemy.r = Utils.GetRandom2(0.2, 0.8);
            enemy.g = Utils.GetRandom2(0.2, 0.8);
            enemy.b = Utils.GetRandom2(0.2, 0.8);
            enemy.a = 1;
            characters.Add(enemy);
        }

        public void MoveEnemies(int i)
        {
            Character ch = characters[i];
            double k = Utils.GetRandom();
            double j = Utils.GetRandom();
            if (k > 0.5)
            { 
                if (map.HitRightWall(ch.rect) != true)
                    ch.rect.x += Utils.GetRandom2(0, 0.05);
            }
            else 
            {
                if (map.HitLeftWall(ch.rect) != true)
                    ch.rect.x -= Utils.GetRandom2(0, 0.05);
            }
            if (j > 0.5)
            {
                if (map.HitTopWall(ch.rect) != true)
                    ch.rect.y += Utils.GetRandom2(0, 0.05);
            }
            else
            {
                if (map.HitBottomWall(ch.rect) != true)
                    ch.rect.y -= Utils.GetRandom2(0, 0.05);
            }
        }

        public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawCharacters(canvas);
        }
        public void DrawMap(ICanvas canvas)                 
        {
            canvas.FillShader.SetColor(map.r, map.g, map.b, 1);         
            canvas.Camera.SetRectangle(0, 0, 50, 50);
            canvas.DrawRectangle(map.x, map.y, map.width, map.height);
        }

        public void DrawCharacters(ICanvas canvas)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                Character ch = characters[i];
                canvas.FillShader.SetColor(ch.r, ch.g, ch.b, ch.a);
                canvas.DrawRectangle(ch.rect.x, ch.rect.y, 2, 2);
            }
        }
    }
}



