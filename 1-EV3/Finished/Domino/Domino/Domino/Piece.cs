using System.Diagnostics.Tracing;

namespace Domino
{
    public class PiecePart
    {
        public int value;
        public bool isOcuppied = false;

        public PiecePart(int value)
        {
            if (value > 0 && value <= 6)
                this.value = value;

        }
    }

    public class Piece
    {
        private PiecePart[] _pieceParts = new PiecePart[2];

        public bool IsDouble => _pieceParts[0].value == _pieceParts[1].value;
        public bool IsOcuppied => _pieceParts[0].isOcuppied && _pieceParts[1].isOcuppied;

        private Piece(int value1, int value2)
        {
                _pieceParts[0] = new PiecePart(value1);
                _pieceParts[1] = new PiecePart(value2);
        }
        
        public int ContainsValue(int value)
        {
            if (!_pieceParts[0].isOcuppied && _pieceParts[0].value == value)
                return 0;
            if (!_pieceParts[1].isOcuppied && _pieceParts[1].value == value)
                return 1;
            return -1;
        }

        public int GetValue1()
        {
            return _pieceParts[0].value;
        }

        public int GetValue2()
        {
            return _pieceParts[1].value;
        }

        public PiecePart[] GetPieceParts()
        {
            return new PiecePart[2] { _pieceParts[0], _pieceParts[1] };
                
        }

        public static Piece? Create(int value1, int value2)
        {
            if (0 > value1 || value1 > 6) 
                return null;
            if (0 > value2 || value2 > 6)
                return null;
            return new Piece(value1, value2);

        }

        public override string ToString()
        {
            return "(" + _pieceParts[0].value + ", " + _pieceParts[1].value + ")";
        }




    }
}