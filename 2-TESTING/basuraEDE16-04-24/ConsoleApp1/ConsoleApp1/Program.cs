namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, count = 0;
            bool isNumber;
            Console.WriteLine("Escribe un número.");
            string answer = Console.ReadLine();
            isNumber = int.TryParse(answer, out num);
            if (!isNumber)
            {
                Console.WriteLine("Tienes que escribir un número.");
                Main(Array.Empty<string>());
                return;
            }

            for (int i = 1; i < num; i++)
                if (num % i == 0)
                {
                    count++;
                    if (count > 2)
                        break;
                }
                    
            if (count <= 2)
                Console.WriteLine("El número " + num + " es primo.");
            else
                Console.WriteLine("El número " + num + " no es primo.");

        }
    }
}


