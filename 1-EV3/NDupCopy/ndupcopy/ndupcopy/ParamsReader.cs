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

            public bool AreParamsValid() => Input_Folders != null && Output_Folder != null;
        }

        public static AppParams? ReadParams(string[] args)
        {
            string jsonContent;
            if (args == null)
                throw new ArgumentNullException("args");
            try
            {
                if (args.Length == 0)
                    jsonContent = File.ReadAllText(NDupCopy.DEFAULT_PARAMS);     // default params.json
                else
                    jsonContent = File.ReadAllText(args[0]);

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

