namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string[] array = Array.Empty<string>();

            foreach (var item in array)                     // FOREACH 
                list.Add(int.Parse(item));








            Console.WriteLine("Hello, World!");         // DO WHILE   Es un poco inutil
            int a = -1;
            do
            {
                Console.WriteLine("Hola");
                a++;
            }while (a != 0);



            switch (a)                                 // SWITCH            //El caso 2 hace que se ejecute el caso 0 (hasta el proximo break)
            {                                                                   
                case 2:
                case 0:
                    {
                        Console.WriteLine("Hola");
                        break;
                    }
            }

            try
            {
                int b = a / 0;
            }
                                                                              // Tipos de Exception:
            catch (Exception ex)                                                // Comunes:     OutOfBounds, nullException, StackOverflow JAMAS ESCRIBIR UN TRY CATCH PARA ESO
            {
                Console.WriteLine(ex.Message);                                //Exceptions para los que se usa un Try Catch:
                                                                                //      abrir archivo, acceder a un servidor, parsear strings, abrir sockets        
            }       

            finally
            {

            }
        }
    }
}