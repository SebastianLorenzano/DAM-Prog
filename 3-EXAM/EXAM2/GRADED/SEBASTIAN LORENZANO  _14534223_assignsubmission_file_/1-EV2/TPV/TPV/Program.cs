using TPVLib;
using TPVLib.implementations;

namespace TPV
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var tpv = ITPV.CreateNewTPV(new RAMDatabase());
        }
    }
}