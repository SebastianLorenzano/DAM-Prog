using System.Text.Json;


namespace ndupcopy
{
    public class ParamsReader
    {
        public class AppParams
        {
            public string[]? Input_Folders { get; set; }
            public string[]? Options { get; set; }
            public string[]? Output_Folders { get; set; }
        }

        public static void ReadParams(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");

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

