using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
    }


    public partial class Pepe
    {
        public string DNI { get; set; }

        public Pepe(string dni)
        {
            if (dni != null)
                DNI = dni;
        }
    }


    public partial class Pepe
    {
        public void PrintDNI()
        {
            Console.WriteLine(DNI);
        }
    }

}
