using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basurapintar16_10_2023
{
    internal class Utils
    {

        private static Random r = new Random();

        public static double GetRandom(double min, double max)
        {

            return r.NextDouble();
        }
        public static double GetRandom2(double min, double max)
        {
            return r.NextDouble() * (max - min) + min;  
        }
            
    }
}
