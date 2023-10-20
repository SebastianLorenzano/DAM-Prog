using OpenTK.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDK;

namespace PintarMyGame
{
    public class Character
    {
        public double x, y, width, height, r, g, b, a;
    }

    public class Map
    {
        public double x = 2.5,
                      y = 2.5,
                      width = 45,
                      height = 45,
                      r = 1,
                      g = 1, 
                      b = 1;
    }
    public class World
    {
        public List<Character> characters = new List<Character>();
        Map map = new Map();

        public void AddPlayer()
        {
            Character player = new Character();
            player.x = 4.5;
            player.y = 4.5;
            player.r = 0;
            player.g = 0;
            player.b = 1;
            player.a = 1;
            characters.Add(player);
        }
        public void AddEnemies()
        {
            Character enemy = new Character();
            enemy.x = Utils.GetRandom2(6, 44);
            enemy.y = Utils.GetRandom2(6, 44);
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
                if (HitRightWall(ch) != true)
                    ch.x += Utils.GetRandom2(0, 0.05);
            }
            else 
            {
                if (HitLeftWall(ch) != true)
                    ch.x -= Utils.GetRandom2(0, 0.05);
            }
            if (j > 0.5)
            {
                if (HitTopWall(ch) != true)
                    ch.y += Utils.GetRandom2(0, 0.05);
            }
            else
            {
                if (HitBottomWall(ch) != true)
                    ch.y -= Utils.GetRandom2(0, 0.05);
            }
                    
 
        }

        public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawCharacters(canvas);
        }
        public void DrawMap(ICanvas canvas)                 
        {
            canvas.Clear(0.0, 0.0, 0.0, 1);
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
                canvas.DrawRectangle(ch.x, ch.y, 2, 2);
            }
        }

        public bool HitLeftWall(Character ch)
        {
            if (ch.x < map.x)
                return true;
            return false;
        }
        public bool HitRightWall(Character ch)
        {
            if (ch.x > map.x + map.width - 2)
                return true;
            return false;
        }
        public bool HitTopWall(Character ch)
        {
            if (ch.y > map.y + map.height - 2)
                    return true;
            return false;
        }
        public bool HitBottomWall(Character ch)
        {
            if (ch.y < map.y)                    
                return true;
            return false;
        }
        
    }
}



