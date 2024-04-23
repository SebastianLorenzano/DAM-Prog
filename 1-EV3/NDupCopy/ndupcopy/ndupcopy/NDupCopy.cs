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
        public AppParams AppParams { get; init; }

        private NDupCopy(AppParams appParams)
        {
            AppParams = appParams;
        }

        public static NDupCopy? Create(AppParams appParams)
        {
            if (appParams == null || appParams.Input_Folders == null || appParams.Output_Folder == null)
                return null;
            return new NDupCopy(appParams);
            
        }

        public void CreateLogs()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            _files = FileReader.ReadAllFiles(AppParams.Input_Folders);
            FileReader.CompareAndClassify(_files, ref _duplicates, ref _nonDuplicates);
            FileCopy.CopyFiles(_nonDuplicates, AppParams.Output_Folder, ref _errorsPath);
            CreateLogs();

        }




        

        


    }
}
