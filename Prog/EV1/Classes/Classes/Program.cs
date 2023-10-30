namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Cuantos centavos tienes?");
            //List<Moneda> lista = Coin.GetCoins(Convert.ToInt32(Console.ReadLine()));
            //for (int i = 0; i < lista.Count; i++)
            //    Console.Write(Coin.ToNumber(lista[i]) + " ");

            DominoDeck dominoDeck = new DominoDeck();
            dominoDeck.AddPiece(DominoPiece.CreatePiece(1, 1));
            dominoDeck.AddPiece(DominoPiece.CreatePiece(2, 2));
            dominoDeck.AddPiece(DominoPiece.CreatePiece(3, 3));
            dominoDeck.AddPiece(DominoPiece.CreatePiece(4, 4));
            dominoDeck.AddPiece(DominoPiece.CreatePiece(5, 5));
            dominoDeck.AddPiece(DominoPiece.CreatePiece(6, 6));
            dominoDeck.Shuffle();

        }
    }
}