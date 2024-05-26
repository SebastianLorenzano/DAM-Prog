using System.Security.Cryptography.X509Certificates;
using static ndupcopy.ParamsReader;


namespace ndupcopy
{
    public class NDupCopy
    {
        private static NDupCopy _app;
        private FileInfo[] _files = Array.Empty<FileInfo>();                
        private List<FileInfo> _nonDuplicates = new();
        private List<FileInfo> _duplicates = new();
        public const string FOLDERNAME = "NDupCopy";
        public const string DEFAULT_PARAMS = "../../../params.json";

        public static NDupCopy Instance => _app;                //Didn't feel like deleting all the stuff I did after learning Singletons but wanting to try 
        public string OutputFolder => AppParams.Output_Folder;              // this out anyways so I adapted it to a Singleton but didn't really use it
        public AppParams AppParams { get; init; }

        private NDupCopy(AppParams appParams)
        {
            AppParams = appParams;
            appParams.Output_Folder = Path.Combine(appParams.Output_Folder, FOLDERNAME);
        }

        public static void CreateSimpleton(string[] appParams)       // instead of giving back an instance of NDupCopy, it equals the Simpleton to the new obj
        {
            if (appParams != null)
            {
                var obj = ReadParams(appParams);
                if (obj != null && obj.AreParamsValid())
                    _app = new NDupCopy(obj);
            }
        }

        internal static string? CreateOutputFolder(string destination)
        {
            try
            {
                string name = Path.Join(destination, "output" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                Directory.CreateDirectory(name);
                return name;
            }

            catch (Exception ex) 
            {
                Console.Error.Write(ex.ToString());
                return null;
            } 
            
        }

        public bool CreateLogs()
        {
            int result1 = Log.CreateLog("ndupcopy_duplicates.txt", OutputFolder, _nonDuplicates);
            int result2 = Log.CreateLog("ndupcopy_nunDuplicates.txt", OutputFolder, _duplicates);
            return result1 == 0 && result2 == 0;
        }

        public void Run()
        {
            _files = FileReader.ReadAllFilesToArray(AppParams.Input_Folders);
            if (_files == null)
                Environment.Exit(-2); 
            if (!FileReader.CompareAndClassify(_files, ref _duplicates, ref _nonDuplicates))
                Environment.Exit(-3);
            AppParams.Output_Folder = FileCopy.CopyFiles(_nonDuplicates, AppParams.Output_Folder);
            if (AppParams == null)
                Environment.Exit(-4); 
            if (!CreateLogs())
                Environment.Exit(-5);
        }

        public static void CreateAndRun(string[] appParams)
        {
            CreateSimpleton(appParams);
            var obj = Instance;
            if (obj != null)
                obj.Run();
        }




        

        


    }
}
