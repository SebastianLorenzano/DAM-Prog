using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PintarMyGame;

internal class Utils
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

}