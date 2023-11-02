using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{

    public class ChessFigure
    {
        public enum FigureType
        {
            PAWN,
            TOWER,
            KNIGHT,
            BISHOP,
            QUEEN,
            KING
        }

        public enum ColorType
        {
            WHITE,
            BLACK
        }

        private int _x, _y, _movementCount;
        private ColorType _color;
        public FigureType _figure;

        
        public bool IsValid()
        {
            return _x >= 1 && _x <= 8 && _y >= 1 && _y <= 8;
        }

        public int GetX()
            { return _x; }
        
        public int GetY()
        { return _y; }

        public FigureType GetFigureType()
        {
            return _figure;
        }

        public ColorType GetColorType()
        {
            return _color;
     
        }

        internal void MoveTo()
        {

        }

        public void Promote()
        {

        }

        public int GetMovementCount()
        {

        }

        public bool HasBeenMoved()
        {
            return
        }

    }


}
