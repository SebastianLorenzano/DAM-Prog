using System.Runtime.CompilerServices;

namespace Domino
{
    public class Utils
    {
        private static Random r = new Random();
        public static void SortPiecesByFirstValue(ref List<Piece> pieces)
        {
            for (int i = 0; i < pieces.Count - 1; i++)
                for (int j = i + 1; j < pieces.Count; j++)
                {
                    if (pieces[i].GetValue1() < pieces[j].GetValue1())
                    {
                        var aux = pieces[i];
                        pieces[i] = pieces[j];
                        pieces[j] = aux;
                    }
                }
        }

        public static int GetRandom(int min, int max)
        {
            return r.Next(min, max + 1);
        }


        /* VER COMO FUNCIONA */

        /*
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var aux = list[i];
            list[i] = list[j];
            list[j] = aux;
        }
        */
    }
    
}
