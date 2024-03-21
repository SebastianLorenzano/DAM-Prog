namespace basura21_03_24
{
    internal class Program
    {
        public class Prueba : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose");
            }

            public void SayHello()
            {
                Console.WriteLine("Hello");
            }
        }

        public static Prueba CrearPrueba()
        {
            return null;
        }

        static void Main(string[] args)
        {
            using (Prueba p = CrearPrueba())
            {
                //p.SayHello();
            };

        }
    }
}
