using System.Text.Json;


namespace ndupcopy
{
    public class ParamsReader
    {
        public class AppParams
        {
            public string[]? Input_Folders { get; set; }
            public string[]? Options { get; set; }
            public string? Output_Folder { get; set; }

            public bool AreParamsValid()
            {
                return Input_Folders != null && Output_Folder != null;
            }
        }

        public static AppParams? ReadParams(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");

            try
            {
                string jsonContent = File.ReadAllText("../../../params.json");
                return JsonSerializer.Deserialize<AppParams>(jsonContent);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Algo ha salido mal: " + ex.Message);
                return null;
            }
                
        }
    }
}

