using DAMLib;

namespace DAMLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ItemSet<string> pepe = new();
            pepe.Add("Ana");
            pepe.Add("Juan");
            pepe.Add("Luis");
            pepe.Add("Jose");
            pepe.Add("Pepe");
            pepe.Add("Angel");
            pepe.Add("Lucia");
            pepe.Remove("Jose");
            pepe.Add("Jose");
            */

            double a = 1, b = 5, c = 3, x1 = 0, x2 = 0;

            var pepe = Utils.CuadraticFormulaWithTuple(a, b, c);
            var pepe1 = Utils.CuadraticFormula(a, b, c, out x1, out x2);
            Console.WriteLine("TUPLE:  " + pepe.exists + " , " +  pepe.x1 + " , " + pepe.x2);

            Console.WriteLine("OTHER:  " + pepe1 +  " , " + x1 + " , " + x2);
        }
    }
}