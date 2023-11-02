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

            Card card = new Card(1, CardType.CORAZON);
            Card card1 = new Card(3, CardType.DIAMANTE);
            card1.GetColorType();
            card1.IsFigure();
            card1.GetFigureType();

            Card card2 = new Card(11, CardType.TREBOL);
            card2.IsFigure();
            card2.GetFigureType();
            Card card3 = new Card(14, CardType.TREBOL);
            card3.IsFigure();
            card3.GetFigureType();
            Card card4 = new Card(15, CardType.JOKER);
            card4.IsFigure();
            card4.GetFigureType();

        }
    }
}