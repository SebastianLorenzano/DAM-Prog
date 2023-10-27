using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DominoPiece
    {
        private int value1;
        private int value2;

        public DominoPiece(int v1, int v2)
        {
            value1 = v1;
            value2 = v2;
        }
        public int GetValue1()
        {
            return value1;
        }

        public int GetValue2()
        {
            return value2;
        }

        public int GetTotalValue()
        {
            return value1 + value2;
        }

        public bool IsDouble()
        {
            return value1 == value2;
        }
    }
}
