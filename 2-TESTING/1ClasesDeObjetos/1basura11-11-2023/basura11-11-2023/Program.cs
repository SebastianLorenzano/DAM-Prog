using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basura11_11_2023
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            int aux, a = 8;

            List<int> lista = new List<int>();
            lista.Add(0);
            lista.Add(1);
            lista.Add(7);
            lista.Add(7);
            lista.Add(3);
            lista.Add(-1);
            lista.Add(0);
            List<int> values = new List<int>();
            values.Add(5);
            values.Add(7);
            values.Add(7);
            values.Add(0);
            for (int i = 0; i < lista.Count; i++)
                Console.Write(lista[i]);
            Console.WriteLine();
            Utils.RemoveValues(lista, values);
            for (int i = 0; i < lista.Count; i++)
                Console.Write(lista[i]);

        }
    }
}
