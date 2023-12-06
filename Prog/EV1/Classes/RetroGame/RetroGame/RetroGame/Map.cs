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
        private List<Rectangle> _rects = new();
        public Map()
        {
            coor.SetWidth(100);
            coor.SetHeight(100);
            SetRGBA(new rgba_f32(0,0,0,1));
        }

        public int GetObjectCount()
        {
            return _rects.Count;
        }
        
        public Object GetObjectAt(int index)
        {
            return _rects[index];
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

            for (int i = 0; i < _rects.Count; i++)
            {
                Object ob = _rects[i];
                canvas.FillShader.SetColor(ob.GetR(), ob.GetG(), ob.GetB(), ob.GetA());
                canvas.DrawRectangle(ob.GetX(), ob.GetY(), 2, 2);
            }
        }

        private void DrawBalls(ICanvas canvas)
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                Object ob = _rects[i];
                canvas.FillShader.SetColor(ob.GetR(), ob.GetG(), ob.GetB(), ob.GetA()); //Queria hacer un circulo para las pelotas pero no encontre ninguna funcion que lo permita
                canvas.DrawRectangle(ob.GetX(), ob.GetY(), 2, 2);
            }
        }



    }
}

