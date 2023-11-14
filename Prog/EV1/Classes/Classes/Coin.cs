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

        public static int ToNumber(Moneda value)
        {
            return (int)value;

            /* se puede hacer lo mismo en la funcion anterior */
        }

            /* Otra manera */

        /* private static int[] _monedasValue = {10000, 1000, 100, 10, 1}
         * 
         * public static int ToNumber(Moneda moneda)
         * {
         *  return _monedasValue[(int)moneda];
         *  }
         */

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

        public static Moneda ToMoneda2(int centimos)  /* Devuelve no solamente si es igual sino si tambien es menor EJ: if (centimos >= 50000) return Moneda.e500; */
        {
            if (50000 <= centimos)
                return Moneda.e500;
            if (20000 <= centimos)
                return Moneda.e200;
            if (10000 <= centimos)
                return Moneda.e100;
            if (5000 <= centimos)
                return Moneda.e50;
            if (2000 <= centimos)
                return Moneda.e20;
            if (1000 <= centimos)
                return Moneda.e10;
            if (500 <= centimos)
                return Moneda.e5;
            if (200 <= centimos)
                return Moneda.e2;
            if (100 <= centimos)
                return Moneda.e1;
            if (50 <= centimos)
                return Moneda.e05;
            if (20 <= centimos)
                return Moneda.e02;
            if (10 <= centimos)
                return Moneda.e01;
            if (5 <= centimos)
                return Moneda.e005;
            if (2 <= centimos)
                return Moneda.e002;
            if (1 <= centimos)
                return Moneda.e001;
            return 0;
        }
        public static List<Moneda> GetCoins(int centimos)
        {
            List<Moneda> monedas = new List<Moneda>();

            while (centimos > 0)
            {
                Moneda valor = Coin.ToMoneda2(centimos);
                if (valor != 0)
                {
                    monedas.Add(valor);
                    centimos -= Coin.ToNumber(valor);
                }
            }
            return monedas;
        }
    }
}
