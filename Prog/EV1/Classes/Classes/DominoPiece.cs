using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /* 
    - DominoPiece(int, int)                         2
    + CreatePiece(int1, int2)                       2
    + GetValue1()                                   2
    + GetValue2()                                   2
    + GetTotalValue()                               2
    + IsDouble()                                    2
    + IsValid() esta dentro de los valores (1-6)    2
    + IsEqualTo()                                   2

 */
    public class DominoPiece
    {

        private int value1, value2;

        private DominoPiece(int v1, int v2)
        {
            value1 = v1;
            value2 = v2;
        }

        public static DominoPiece? CreatePiece(int v1, int v2)
        {
            if (DominoPiece.IsValid(v1) == false || DominoPiece.IsValid(v2) == false)
                return null;
            return new DominoPiece(v1, v2);

        }

        // Javi: No me pongas esto así ;)
        public int GetValue1()
        { return value1; }

        public int GetValue2()
        { return value2; }

        public int GetTotalValue()
        { return value1 + value2; }

        public bool IsDouble()
        {
            // Javi: return de una linea
            if (value1 == value2)
                return true;
            return false;
        }

        public static bool IsValid(int value)
        {
            // Javi: return de una linea
            if (value < 0 || value > 6) return false;
            return true;
        }

        public bool IsEqualTo(DominoPiece piece)
        {
            // Javi: return de una linea
            if ((value1 == piece.value1 && value2 == piece.value2) || (value1 == piece.value2 && value2 == piece.value1))
                return true;
            return false;
        }
    }
}

