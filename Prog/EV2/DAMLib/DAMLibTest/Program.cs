using DAMLib;

namespace DAMLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}