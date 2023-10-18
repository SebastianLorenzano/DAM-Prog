using System.Collections.Generic;

namespace basura11_11_2023
{
    internal class Program
    {
        public static List<int> Collatz(int n)
        {
            if (n == null || n == 0)
                return new List<int>();
            List<int> result = new List<int>();
            while (n != 1)
            {
                result.Add(n);
                if (n % 2 == 0)
                    n /= 2;
                else
                    n *= 3 + 1;
            }
            result.Add(n);
            return result;
        }
        public static List<int> OrdenarLista(List<int> lista)
        {
            int aux;
            for (int i = 0; i < lista.Count; i++)
                for (int j = i + 1; j < lista.Count - 1; j++)
                    if (lista[i] > lista[j])
                    {
                        aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            for (int k = 0; k < lista.Count; k++)
                Console.Write(lista[k]);
            return lista;
        }

        public static List<int> ListaPares(List<int> lista)
        {
            List<int> lista2 = new List<int>();
            for (int i = 0; i < lista.Count; i++)
            {
                int element = lista[i];
                if (element % 2 == 0)
                    lista2.Add(i);
            }
            return lista2;
        }

                public static void RemoveElement(List<int> l, int index)
        {
            if (l == null)
                return;
            l.RemoveAt(index);
        }

        public static void RemoveElement2(List<int> l, int value)
        {
            if (l == null)
                return ;
            for (int i = 0; i < l.Count; i++)
                if (l[i] == value)
                    l.RemoveAt(i--);
        }
        /*                                                      Resolver CountElements para poder hacer esto
        public static RemoveElement3(int []? l, int value)
        {
            if (l == null)
                return ;
            int n = CountElements(l, value);
            int[] result = new int[l.Length - n];
            int j =0;
            for (int i = 0; i < l.Length; i++)
                if (l[i] != value)
                    result[j++] = l[i];
        }
                */

        public static void RemoveValues(List<int> l, List<int> values)
        {
            //for (int)

        }

        public static void Main(string[] args)
        {
            int aux, a = 8;

            List<int> lista = new List<int>();
            lista.Add(0);
            lista.Add(7);
            lista.Add(8);
            lista.Add(8);
            lista.Add(4);
            lista.Add(8);
            for (int i = 0; i < lista.Count; i++)
                Console.Write(lista[i]);
            Console.WriteLine();
            RemoveElement2(lista, a);
            for (int i = 0; i < lista.Count; i++)
                Console.Write(lista[i]);
            
            }
    }       
}


        