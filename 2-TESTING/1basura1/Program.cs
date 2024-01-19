namespace basura1
{
    internal class Program
    {

        /* Example */
        static void Main(string[] args)
        {
            int[] numero = new int[5];
            int suma;
            numero[0] = 200;
            numero[1] = 150;
            numero[2] = 100;
            numero[3] = -50;
            numero[4] = 300;
            suma = numero[0] + numero[1] + numero[2] +
                numero[3] + numero[4];
            Console.WriteLine(suma);
        }
    }
}