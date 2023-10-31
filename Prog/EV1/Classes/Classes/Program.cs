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

            Card card = new Card(1, CardType.Corazon);
            Card card1 = new Card(3, CardType.Diamante);
            card1.GetColorType();
            card1.IsFigure();
            card1.GetFigureType();

            Card card2 = new Card(11, CardType.Trebol);
            card2.IsFigure();
            card2.GetFigureType();
            Card card3 = new Card(14, CardType.Trebol);
            card3.IsFigure();
            card3.GetFigureType();
            Card card4 = new Card(15, CardType.Joker);
            card4.IsFigure();
            card4.GetFigureType();

        }
    }
}