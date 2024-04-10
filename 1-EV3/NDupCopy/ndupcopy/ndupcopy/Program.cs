using System.Text.Json;
using System.Text.Json.Nodes;

namespace ndupcopy
{
    internal class Program
    {

        public class AppParams
        {
            public string[]? input_folders { get; set; }
            public string[]? options { get; set; }
            public string[]? output_folders { get; set; }
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
