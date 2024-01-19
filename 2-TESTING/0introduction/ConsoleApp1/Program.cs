using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks.Dataflow;

    internal class Program
    {
        /* (2.1.2.1) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2, pepe, pepe1;/* PEPE */

        //            Console.Write("Introduce un numero entero: ");
        //            num1 = Convert.ToInt32(
        //                Console.ReadLine());
        //            if (num1 % 10 == 0)
        //                Console.Write("Introduce un segundo numero: ");
        //            num2 = Convert.ToInt32(
        //                Console.ReadLine());
        //            if (num2 % 10 == 0)
        //                Console.WriteLine("Tanto " + num1 + " como " + num2 + " son multiplos de 10");

        //        }
        //    }
        //}
        /* (2.1.4.1) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2;

        //            Console.Write("Introduce un numero entero: ");
        //            num1 = Convert.ToInt32(
        //                Console.ReadLine());
        //            if (num1 == 0)
        //                Console.Write("El producto de 0 por cualquier número es 0");
        //            else
        //                Console.Write("Introduce un segundo numero entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //                Console.WriteLine(num1 * num2);

        //        }
        //    }
        //}
        /* (2.1.4.2) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2;

        //            Console.Write("Introduce un numero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un segundo numero entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            if (num2== 0)
        //                Console.Write("Error: No se puede dividir entre cero.");
        //            else
        //                Console.WriteLine(num1 / num2);

        //        }
        //    }
        //}
        /* (2.1.5.1) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2;

        //            Console.Write("Introduce un numero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            if (num1 % 2 == 0 || num1 % 2 == 0)
        //                if (num1 % 2 == 0)
        //                    Console.WriteLine("Si");
        //            if (num1 % 3 == 0)
        //                Console.WriteLine("Si");
        //        }
        //    }
        //}

        /* (2.1.5.2) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2;
        //            Console.Write("Introduce un numero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un numero entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            if (num1 > 0 || num2 > 0)
        //                if (num1 > 0 && num2 > 0)
        //                    Console.WriteLine("Los dos numeros son positivos");
        //                else Console.WriteLine("Uno de los dos numeros son positivos");
        //            else Console.WriteLine("Ninguno de los ejercicios son positivos");
        //        }
        //    }
        //}

        //        /* (2.1.5.3) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2, num3;
        //            Console.Write("Introduce un primero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un segundo entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un tercer entero: ");
        //            num3 = Convert.ToInt32(Console.ReadLine());
        //            if (num1 > num2 && num1 > num3) Console.WriteLine(num1 + " es mayor a " + num2 + " y " + num3);
        //            if (num2 > num1 && num2 > num3) Console.WriteLine(num2 + " es mayor a " + num1 + " y " + num3);
        //            if (num3 > num1 && num3 > num2) Console.WriteLine(num3 + " es mayor a " + num1 + " y " + num2);
        //        }
        //    }
        //}
        /* (2.1.5.4) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2, num3;
        //            Console.Write("Introduce un primero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un segundo entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            if (num1 != num2)
        //                if (num1 > num2)
        //                    Console.Write(num1 + "es mayor a " + num2);
        //                else
        //                    Console.Write(num2 + "es mayor a " + num1);
        //            else
        //                Console.Write(num1 + " y " + num2 + " son iguales.");
        //        }   
        //    }
        //}
        /* (2.1.8.1)*/
        //        static void Main(string[] args)
        //        {
        //            int num1;
        //            Console.Write("Introduce un primero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            num1 = (num1 >= 0) ? num1 : num1 * -1;
        //            Console.WriteLine(num1);
        //}
        //}
        //}
        /* (2.1.8.2) */
        //        static void Main(string[] args)
        //        {
        //            int num1, num2, mayor;
        //            Console.Write("Introduce un primero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.Write("Introduce un segundo entero: ");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            mayor = (num1 < num2) ? num1 : num2;
        //            Console.WriteLine(mayor);
        //        }
        //    }
        //}
        //        /* (2.2.1.1) */
        //        public static void Main()
        //        {
        //            int num1 = 0, contraseña = 1111;
        //            while (num1 != contraseña)
        //            { 
        //                Console.Write("Introduzca su contraseña para proseguir: ");
        //                num1 = Convert.ToInt32(Console.ReadLine());
        //            }
        //        }
        //    }
        //}

        //        /* (2.2.1.2) */
        //        public static void Main()
        //        {
        //            int num1 = 1;
        //            while (num1 != 11)
        //            {
        //                Console.WriteLine(num1);
        //                num1++;
        //            }
        //        }
        //    }
        //}

        //        /* (2.2.1.3) */
        //        public static void Main()
        //        {
        //            int num1 = 26;
        //            while (num1 != 8)
        //            {
        //                Console.WriteLine(num1);
        //                num1 = num1 - 2;
        //            }
        //        }
        //    }
        //}

        //        /* (2.2.1.4) */
        //        public static void Main()
        //        {
        //            int num1, cifras = 0;
        //            Console.Write("Escriba un numero entero: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            while (num1 > 0)
        //            {
        //                num1 = num1 / 10;
        //                cifras++;
        //            }
        //            Console.WriteLine("El numero de cifras es " + cifras);
        //        }
        //    }
        //}
        /* (2.2.1.5) */
        //        public static void main()
        //        {
        //            int num1, num2 = 9, numvidas = 3;
        //            bool won = false;
        //            while (numvidas > 0 && won == false)
        //            {
        //                Console.Write("Tienes 3 oportunidades para adivinar el numero: ");
        //                num1 = Convert.ToInt32(Console.ReadLine());
        //                if (num1 == num2) won = true;
        //                numvidas--;
        //            }
        //            if (won == true)
        //                Console.Write("Enhorabuena, el numero era " + num2);
        //            else
        //                Console.Write("Has perdido, el numero era " + num2);
        //        }
        //    }
        //}
        /* (2.2.3.1) */
        //public static void Main()
        //{
        //            int i;
        //            for (i = 15; i >= 5; i--)Console.WriteLine(i);

        //}
        //}
        //}
        //        /* (2.2.3.2) */
        //        public static void Main()
        //        {
        //            int i;
        //            for (i = 2; i <= 16; i = i + 2) Console.WriteLine("{0}", i);
        //        }
        //    }
        //}

        //        /* (2.2.3.3) */
        //        public static void Main()
        //        {
        //            char letra;
        //            for (letra='Z'; letra>='A'; letra--) Console.WriteLine("{0}", letra);
        //        }
        //    }
        //}

        //        /* (2.2.3.4) */
        //        public static void Main()
        //        {
        //            int num1, num2 = 1;
        //            for (num1 = 5; num2 <= 10; num2++) Console.WriteLine("{0}", num1 * num2);
        //        }
        //    }
        //}

        //        /* (2.2.3.5) */
        //        public static void Main()
        //        {
        //            int num1;
        //            for (num1 = 1; num1 <= 50; num1++) if (num1 % 3 == 0) Console.WriteLine("{0}", num1);
        //        }
        //    }
        //}

        /* (2.8.1) */
        //        public static void Main()
        //        {
        //            int num1, num2 = 69, hp = 6;
        //            bool won = false;
        //            while (hp > 0 && won == false)
        //            {
        //                Console.Write("Adivine un numero de 1 al 100: ");
        //                num1 = Convert.ToInt32(Console.ReadLine());
        //                if (num1 == num2) won = true;
        //                else
        //                    if (num1 > num2)
        //                        Console.WriteLine("El numero que estas buscando es menor.");
        //                    else
        //                        Console.WriteLine("El numero que estas buscando es mayor.");
        //                hp--;
        //            }
        //            if (won == true)
        //                Console.Write("Enhorabuena, el numero era " + num2);
        //            else
        //                Console.Write("Has perdido, el numero era " + num2);
        //        }
        //    }
        //}

        /* (2.8.2) */
        //        public static void Main()
        //        {
        //            int num1;
        //            string numbers = "";

        //            {

        //            }
        //            Console.Write("Write a number to be decomposed: ");
        //            num1 = Convert.ToInt32(Console.ReadLine());

        //            for (int num2 = 2; num2 <= num1; num2++)
        //            {
        //                for (; num1 % num2 == 0;)
        //                {
        //                    num1 = num1 / num2;
        //                    if (numbers == "")
        //                        numbers = Convert.ToString(num2);
        //                    else
        //                        numbers = numbers + " * " + Convert.ToString(num2);
        //                }
        //            }
        //        }
        //    }
        //}
        //        /* (2.8.3) */
        //        public static void Main()
        //        {
        //            int num1, num2, num3 = 1;     /* num3 = Numero Final */
        //            Console.WriteLine("Introduzca un numero aqui");
        //            num1 = Convert.ToInt32(Console.ReadLine());
        //            Console.WriteLine("Introduzca un numero aqui");
        //            num2 = Convert.ToInt32(Console.ReadLine());
        //            for (int i = 0; i < num2; i++)
        //            {
        //                num3 = num3 * num1;
        //                Console.WriteLine(num3);
        //            }
        //        }
        //}
        //}

        /* (2.8.4) */
        //    public static void Main()
        //    {
        //        int height, width;
        //        Console.Write("Introduzca el ancho del rectangulo: ");
        //        height = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("Introduzca el largo del rectangulo: ");
        //        width = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("");
        //        for (int i = 0; i < height; i++)
        //        {
        //            for (int j = 0; j < width; j++)
        //            {
        //                Console.Write('*');
        //            }
        //            Console.WriteLine("");
        //        }
        //    }
        //    }
        //}

        //    /* (2.8.5) */
        //    public static void Main()
        //    {
        //        int height;
        //        Console.Write("Introduzca el ancho del rectangulo: ");
        //        height = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("");
        //        for (int j = 0; j < height; height--)
        //        { 
        //            for (int i = 0; i < height; i++)
        //            {
        //                Console.Write('*');
        //            }
        //            Console.WriteLine("");
        //        }
        //    }
        //    }
        //}

        ///* (2.8.6) */

        //public static void Main()
        //{
        //    int height, width;
        //    Console.Write("Introduzca el ancho del rectangulo: ");
        //    height = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Introduzca el largo del rectangulo: ");
        //    width = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("");
        //    for (int i = 0; i < height; i++)
        //    {
        //        for (int j = 0; j < width; j++)
        //        {
        //            if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
        //                Console.Write("*");
        //            else Console.Write(" ");
        //        }
        //        Console.WriteLine("");
        //    }
        //}
        //    }
        //}

        //        /* (2.8.7) */
        //        public static void Main()
        //        {
        //            int height;
        //            Console.Write("Pick a number: ");
        //            height = Convert.ToInt32(Console.ReadLine());
        //            for (int i = 0; i < height; i++)
        //            {
        //                for (int k = height - 1 - i; k > 0; k--)
        //                    Console.Write(" ");
        //                for (int j = 0; j < i + 1; j++)
        //                    Console.Write("*");

        //                Console.WriteLine("");

        //            }
        //        }
        //    }
        //}


        //    public static void Main()
        //    {
        //        int precio, pagado, cambio;
        //        string billetes = "";
        //        Console.Write("Precio: ");
        //        precio = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("Pago: ");
        //        pagado = Convert.ToInt32(Console.ReadLine());
        //        cambio = pagado - precio;

        //        if (cambio > 0)
        //        {
        //            while (cambio > 0)
        //            {
        //                if (cambio - 100 >= 0)
        //                {
        //                    cambio -= 100;
        //                    billetes = (billetes + " 100 ");
        //                }
        //                else if (cambio - 50 >= 0)
        //                {
        //                    cambio -= 50;
        //                    billetes = (billetes + " 50 ");
        //                }
        //                else if (cambio - 20 >= 0)
        //                {
        //                    cambio -= 20;
        //                    billetes = (billetes + " 20 ");
        //                }
        //                else if (cambio - 10 >= 0)
        //                {
        //                    cambio -= 10;
        //                    billetes = (billetes + " 10 ");
        //                }
        //                else if (cambio - 5 >= 0)
        //                {
        //                    cambio -= 5;
        //                    billetes = (billetes + " 5 ");
        //                }
        //                else if (cambio - 2 >= 0)
        //                {
        //                    cambio -= 2;
        //                    billetes = (billetes + " 2 ");
        //                }
        //                else if (cambio - 1 >= 0)
        //                {
        //                    cambio -= 1;
        //                    billetes = (billetes + " 1 ");
        //                }        
        //            }
        //            Console.WriteLine("Precio: {0}", precio);
        //            Console.WriteLine("Pagado: {0}", pagado);
        //            Console.WriteLine("Su cambio es de: {0}", billetes);
        //        }
        //        }
        //    }
        //}

        /* (2.9.1) */
//        public static void Main()
//        {
//            int edad, fecha_nacimiento;

//            try
//            { 
//                Console.Write("Introduzca su edad: ");
//                edad = Convert.ToInt32(Console.ReadLine());

//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("No es un numero valido.");
//            }
//            Console.Write("Introduzca su fecha de nacimiento: ");
//            fecha_nacimiento = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine(fecha_nacimiento);
//        }
//    }
//}









