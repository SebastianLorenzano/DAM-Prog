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

         var pepe = Utils.GetRandomInt(1, 6);
            Console.WriteLine(pepe);
        }
    }
}