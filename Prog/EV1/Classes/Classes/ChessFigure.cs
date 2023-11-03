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

        public ChessFigure(int x, int y, ColorType color, FigureType figure)
        {
            _x = x;
            _y = y;
            _color = color;
            _figure = figure;
            _movementCount = 0;
        }

        public bool IsValid()
        {
            return _x >= 1 && _x <= 8 && _y >= 1 && _y <= 8;
        }

        public int GetX()
        { 
            if (IsValid())
                return _x;
            return -1;
        }
        
        public int GetY()
        { 
            if (IsValid())
                return _y; 
            return -1;
        }
        public FigureType GetFigureType()
        {
            return _figure;
        }

        public ColorType GetColorType()
        {
            return _color;
     
        }

        internal void MoveTo(int TargetX, int TargetY)
        {
            if (IsValid(TargetX, TargetY))
            {
                _x = TargetX;
                _y= TargetY;
                _movementCount++;
            }    
        }

        public void Promote()
        {
            Console.Write("ESCRIBIR NOMBRE DE PIEZA A PROMOCIONAR EN MAYUSC: ");
            var value = Console.ReadLine();
            var bool1 = true;
            while (bool1 == true)
            {
                if (value == "TORRE")
                {
                    _figure = FigureType.TOWER;
                    return;
                }
                if (value == "CABALLERO")
                {
                    _figure = FigureType.KNIGHT;
                    return;
                }
                if (value == "ALFIL")
                {
                    _figure = FigureType.BISHOP;
                    return;
                }
                if (value == "REINA")
                {
                    _figure = FigureType.QUEEN;
                    return;
                }
                Console.WriteLine("VALOR NO RECONOCIDO. INTENTALO DE VUELTA.");
                }
            }
        

        public int GetMovementCount()
        { return _movementCount; }

        public bool HasBeenMoved()
        { return _movementCount > 0; }
}
}



