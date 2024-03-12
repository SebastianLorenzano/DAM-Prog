namespace Domino
{


    public class PiecePart
    {
        public int value;
        public bool IsOcuppied = false;
    }

    public class Piece
    {
        private PiecePart[] _pieceParts = new PiecePart[2];

        public bool IsDouble => _pieceParts[0].value == _pieceParts[1].value;

        public Piece(int value1, int value2)
        {
            if (value1 > 0 && value1 <= 6)
                _pieceParts[0].value = value1;
            if (value2 > 0 && value2 <= 6)
                _pieceParts[1].value = value2;
        }
        
        public PiecePart[] GetPieceParts()
        {
            return new PiecePart[2] { _pieceParts[0], _pieceParts[1] };
                
        }



        public override string ToString()
        {
            return "(" + _pieceParts[0].value + ", " + _pieceParts[1].value + ")";
        }




    }
}