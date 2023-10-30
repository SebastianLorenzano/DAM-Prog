using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Utils
    {
        Random random = new Random();
        public static int GetRandom(int min, int max)
        {
            int dif = max - min;
            
            return min + random.Next() % dif;
        }

    }
}
