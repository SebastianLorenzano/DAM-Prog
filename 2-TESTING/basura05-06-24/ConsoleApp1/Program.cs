namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public class Casilla_Castigo : Casilla
    {

    }


    public class Casilla
    {
        public int Numero { get; init; }

        private Casilla(int numero)
        {
            Numero = numero;
        }

        public Casilla? Create()
        {

        }
    }
}
