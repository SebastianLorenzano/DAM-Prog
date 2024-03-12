namespace Domino
{
    public class Utils
    {

        public static void SortPieces(ref List<Piece> pieces)
        {
            for (int i = 0; i < pieces.Length - 1; i++)
                for (int j = i + 1; j < pieces.Length; j++)
                {
                    if (pieces[i].GetValue1() < pieces[j].GetValue1())
                    {
                        var aux = pieces[i];
                        pieces[i] = pieces[j];
                        pieces[j] = aux;
                    }
                }
        }
    }
}
