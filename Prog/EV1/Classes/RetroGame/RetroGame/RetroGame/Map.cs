using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static UDK.IFont;
using UDK;
using System.Reflection.PortableExecutable;

namespace RetroGame
{
    public class Map : Object
    {
        public bool is_running = true;
        private List<Ball> _balls = new();
        private List<Rectangle> _enemyRects = new();
        private List<Rectangle> _playerRects = new();
        private double
            RectX = 8,
            RectY = 65 + 5.6;
        private bool RectSpawnMaxxed;
            
        public Map(double x, double y, double width, double height)
        {
            coor.SetWidth(width);
            coor.SetHeight(height);
            coor.SetMiddleX(x);
            coor.SetMiddleY(y);
            SetRGBA(new rgba_f32(0,0,0,1));
        }

        public int GetEnemyRectsCount()
        {
            return _enemyRects.Count;
        }
        
        public Rectangle? GetEnemyRectAt(int index)
        {
            if (index > 0 && index < _enemyRects.Count)
                return _enemyRects[index];
            return null;
        }

        public int GetPlayerRectsCount()
        {
            return _playerRects.Count;
        }

        public Rectangle? GetPlayerRectAt(int index)
        {
            if (index > 0 && index < _playerRects.Count)
                return _playerRects[index];
            return null;
        }

        public int GetBallsCount()
        {
            return _balls.Count;
        }

        public Ball? GetBallsAt(int index)
        {
            if (index > 0 &&  index < _balls.Count) 
                return _balls[index];
            return null;
        }

        public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawRects(canvas);
            DrawBalls(canvas);
        }


        private void DrawMap(ICanvas canvas)
        {
            canvas.FillShader.SetColor(GetR(), GetG(), GetB(), GetA());
            canvas.Camera.SetRectangle(coor.GetX(), coor.GetY(), coor.GetWidth(), coor.GetHeight());
            canvas.DrawRectangle(coor.GetX(), coor.GetY(), coor.GetWidth(), coor.GetHeight());
        }

        private void DrawRects(ICanvas canvas)
        {
            for (int i = 0; i < _playerRects.Count; i++)
            {
                Rectangle rect = _playerRects[i];
                canvas.FillShader.SetColor(rect.GetR(), rect.GetG(), rect.GetB(), rect.GetA());
                canvas.DrawRectangle(rect.GetX(), rect.GetY(), 2, 2);
            }


            for (int i = 0; i < _enemyRects.Count; i++)
            {
                Object ob = _enemyRects[i];
                canvas.FillShader.SetColor(ob.GetR(), ob.GetG(), ob.GetB(), ob.GetA());
                canvas.DrawRectangle(ob.GetX(), ob.GetY(), 2, 2);
            }
        }

        private void DrawBalls(ICanvas canvas)
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                Object ob = _enemyRects[i];
                canvas.FillShader.SetColor(ob.GetR(), ob.GetG(), ob.GetB(), ob.GetA()); //Queria hacer un circulo para las pelotas pero no encontre ninguna funcion que lo permita
                canvas.DrawRectangle(ob.GetX(), ob.GetY(), 2, 2);
            }
        }

        public void SetSpawnPosition(Rectangle rect)
        {
            rect.SetX(RectX);
            rect.SetY(RectY);
            RectX += 8;
            DecideNextRectSpawnPostion();
        }

        private void DecideNextRectSpawnPostion()
        {
            if (RectX > GetWidth() - 8)
            {
                RectX = 8;
                RectY += 5.6;
                if (Utils.GetDistance(0, RectY, 0, coor.GetHeight())! > 15)
                    RectSpawnMaxxed = true;
            }
        }
            public void CreatePlayerRectangle()
        {
            if (_playerRects.Count == 0)
            {
                Rectangle player = new(RectType.PLAYER, 104.0, 20);
                _playerRects.Add(player);
            }
            /*else
                Rectangle player = new(RectType.PLAYER, _playerRects[_playerRects.Count - 1].GetMiddleX() + playerWidth) */

        }

        internal void CreateRectangles(int count)
        {
            for (int i = 0; i < count; i++) 
            {
                if (!RectSpawnMaxxed)
                    CreateRectangle(RectType.ENEMY);

            }
        }

        public void CreateRectangle(RectType type)
        {

            
            if (type == RectType.ENEMY)
            {
                Rectangle rect = new(type);
                SetSpawnPosition(rect);
                DecideNextRectSpawnPostion();
                _enemyRects.Add(rect);
            }
        }


    }
}

