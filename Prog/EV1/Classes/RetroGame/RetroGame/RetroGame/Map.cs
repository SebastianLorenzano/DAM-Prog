using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static UDK.IFont;
using UDK;

namespace RetroGame
{
    public class Map : Object
    {
        public bool is_running = true;
        private List<Object> _objects = new List<Object>();
        public Map()
        {
            _width = 50;
            _height = 100;
        }

        public int GetObjectCount()
        {
            return _objects.Count;
        }
        
        public Object GetObjectAt(int index)
        {
            return _objects[index];
        }


        public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawObjects(canvas);
        }
        public void DrawMap(ICanvas canvas)
        {
            canvas.FillShader.SetColor(GetR(), GetG(), GetB(), GetA());
            canvas.Camera.SetRectangle(coor.x, coor.y, _width, _height);
            canvas.DrawRectangle(coor.x, coor.y, _width, _height);
        }

        public void DrawObjects(ICanvas canvas)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                Object ob = _objects[i];
                canvas.FillShader.SetColor(ob.GetR(), ob.GetG(), ob.GetB(), ob.GetA());
                canvas.DrawRectangle(ob.GetX(), ob.GetY(), 2, 2);
            }
        }


    }
}

