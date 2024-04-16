using System.Text.Json;
using System.Text.Json.Nodes;

namespace ndupcopy
{
    internal class Program
    {

        public class AppParams
        {
            public string[]? Input_Folders { get; set; }
            public string[]? Options { get; set; }
            public string[]? Output_Folders { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                string jsonContent = File.ReadAllText("C:\\Users\\seblor3\\Documents\\dam\\DAM-Prog");
                var obj = JsonSerializer.Deserialize<AppParams>(jsonContent);

            }

            catch (Exception ex) 
            {
                Console.WriteLine("Algo ha salido mal: " + ex.Message);
            }
        }
    }
}
