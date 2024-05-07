namespace UD6._2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Quitar el comentario al metodo que se quiera ejecutar
            MetodoUno();
            //MetodoDos();
        }

        private static void MetodoUno()
        {
            int num1, num2;
            Console.WriteLine("Introduzca el primer numero");
            num1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduzca el segundo numero");
            num2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("---------------------------");

            if (num1 >= num2)
            {
                while (num2 <= num1)
                {
                    Console.WriteLine(num2);
                    num2++;
                }
            }
            else
            {
                while (num1 <= num2)
                {
                    Console.WriteLine(num1);
                    num1++;
                }
            }

            Console.Read();
        }

        private static void MetodoDos()
        {
            int numMayus = 0, numMinus = 0, numNumeros = 0;
            int seguridad = 0;
            string password = "";

            Console.WriteLine("Introduzca la contraseña");
            password = Console.ReadLine();

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'a' && password[i] <= 'z')
                    numMinus++;

                if (password[i] >= 'A' && password[i] <= 'Z')
                    numMayus++;

                if (password[i] >= '0' && password[i] <= '9')
                    numNumeros++;
            }

            if (numMayus > 0)
                seguridad++;
            if (numMinus > 0)
                seguridad++;
            if (numNumeros > 0)
                seguridad++;

            if (password.Length > 7)
            {
                seguridad++;
            }
            else
            {
                if (password.Length > 0)
                {
                    Console.WriteLine("Contraseña demasiado corta");
                    seguridad = 1;
                }
                else
                {
                    Console.WriteLine("La contraseña está vacía");
                    seguridad = 0;
                }
            }


            switch (seguridad)
            {
                case 0:
                    Console.WriteLine("SEGURIDAD NULA");
                    break;
                case 1:
                    Console.WriteLine("SEGURIDAD BAJA");
                    break;
                case 2:
                    Console.WriteLine("SEGURIDAD MEDIA");
                    break;
                case 3:
                    Console.WriteLine("SEGURIDAD ALTA");
                    break;
                case 4:
                    Console.WriteLine("SEGURIDAD MUY ALTA");
                    break;
            }

            Console.Read();
        }

    }
}
