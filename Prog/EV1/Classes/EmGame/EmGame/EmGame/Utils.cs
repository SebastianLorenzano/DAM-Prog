using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmGame
{
    public class Utils
    {

        private static Random r = new Random();

        public static double GetRandom()
        {

            return r.NextDouble();
        }
        public static double GetRandom2(double min, double max)
        {
            return r.NextDouble() * (max - min) + min;
        }

        public static int GetRandomInt(int min, int max) 
        {

            return r.Next(0, 5);
        }
    }

}