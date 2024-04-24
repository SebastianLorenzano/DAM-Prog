using System.Text.Json;
using System.Text.Json.Nodes;

namespace ndupcopy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int nDupCopy = NDupCopy.CreateAndRun(args);
        }

    }
}
