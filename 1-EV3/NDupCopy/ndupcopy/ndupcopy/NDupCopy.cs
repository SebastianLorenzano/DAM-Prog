using System.Security.Cryptography.X509Certificates;
using static ndupcopy.ParamsReader;

namespace ndupcopy
{
    public class NDupCopy
    {

        private FileInfo[] _files = Array.Empty<FileInfo>();
        private List<FileInfo> _nonDuplicates = new();
        private List<FileInfo> _duplicates = new();
        private List<string> _errorsPath = new();

        private string OutputFolder => AppParams.Output_Folder;
        public AppParams AppParams { get; init; }

        private NDupCopy(AppParams appParams)
        {
            AppParams = appParams;
        }

        public static NDupCopy? Create(string[] appParams)
        {
            if (appParams != null)
            {
                var obj = ReadParams(appParams);
                if (obj != null && obj.AreParamsValid())
                    return new NDupCopy(obj);
            }
            return null;
        }

        public bool CreateLogs()
        {
            int result1 = Log.CreateLog("nunDuplicates.txt", OutputFolder, _nonDuplicates);
            int result2 = Log.CreateLog("duplicates.txt", OutputFolder, _duplicates);
            return result1 == 0 && result2 == 0;
        }

        public int Run()
        {

            if (FileReader.ReadAllFiles(AppParams.Input_Folders) == null)
                return -2;
            if (!FileReader.CompareAndClassify(_files, ref _duplicates, ref _nonDuplicates))
                return -3;
            if (!FileCopy.CopyFiles(_nonDuplicates, AppParams.Output_Folder, ref _errorsPath))
                return -4;
            if (!CreateLogs())
                return -5;
            return 5;
        }

        public static int CreateAndRun(string[] appParams)
        {
            var obj = Create(appParams);
            if (obj == null)
                return -1;
            return obj.Run();
                


        }




        

        


    }
}
