using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Moneda
    {
        unknown,
        e500,
        e200,
        e100,
        e50,
        e20,
        e10,
        e5,
        e2,
        e1,
        e05,
        e02,
        e01,
        e005,
        e002,
        e001,
    }

    public class Coin
    {
        public static double ToNumber(Moneda value)
        {
            if (Moneda.e500 == value)
                return 50000;
            if (Moneda.e200 == value)
                return 20000;
            if (Moneda.e100 == value)
                return 10000;
            if (Moneda.e50 == value)
                return 5000;
            if (Moneda.e20 == value)
                return 2000;
            if (Moneda.e10 == value)
                return 1000;
            if (Moneda.e5 == value)
                return 500;
            if (Moneda.e2 == value)
                return 200;
            if (Moneda.e1 == value)
                return 100;
            if (Moneda.e05 == value)
                return 50;
            if (Moneda.e02 == value)
                return 20;
            if (Moneda.e01 == value)
                return 10;
            if (Moneda.e005 == value)
                return 5;
            if (Moneda.e002 == value)
                return 2;
            if (Moneda.e001 == value)
                return 1;
            return 0;
        }
        
        public static Moneda ToMoneda(int centimos)
        {
            if (50000 == centimos)
                return Moneda.e500;
            if (20000 == centimos)
                return Moneda.e200;
            if (10000 == centimos)
                return Moneda.e100;
            if (5000 == centimos)
                return Moneda.e50;
            if (2000 == centimos)
                return Moneda.e20;
            if (1000 == centimos)
                return Moneda.e10;
            if (500 == centimos)
                return Moneda.e5;
            if (200 == centimos)
                return Moneda.e2;
            if (100 == centimos)
                return Moneda.e1;
            if (50 == centimos)
                return Moneda.e05;
            if (20 == centimos)
                return Moneda.e02;
            if (10 == centimos)
                return Moneda.e01;
            if (5 == centimos)
                return Moneda.e005;
            if (2 == centimos)
                return Moneda.e002;
            if (1 == centimos)
                return Moneda.e001;
            return 0;
        }
    }
}
