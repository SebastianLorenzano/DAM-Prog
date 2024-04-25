namespace ndupcopy
{
    public class FileCopy
    {
        public static string? CopyFile(string originContainerPath, string absolutePath, string destination)
        {
            if (originContainerPath == null || absolutePath == null || destination == null)
                return null;
            if (!Directory.Exists(destination))                 // This two lines are not needed for the original function 
                Directory.CreateDirectory(destination);         //  but they are if you want to use it outside of it
            if (!File.Exists(absolutePath))
                throw new Exception("File does not exist");

            var relativePath = absolutePath.Substring(originContainerPath.Length);
            var trueDestination = Path.Join(destination, relativePath);

            if (!Directory.Exists(Path.GetDirectoryName(trueDestination)))
                Directory.CreateDirectory(Path.GetDirectoryName(trueDestination));
            File.Copy(absolutePath, trueDestination);
            return trueDestination;
        }

        public static bool CopyFiles(List<FileInfo> files, string destination, ref List<string> _errorsPath)
        {
            while (true)
            {
                if (Directory.Exists(destination))
                    destination = Path.Join(destination, "NDupOutput");
                else
                    break;
            }

            foreach (var f in files)
            {
                f.NewPath = CopyFile(f.ContainerPath, f.Path, destination);
                if (f.NewPath == null)
                    _errorsPath.Add(f.Path);
            }
            return true;
        }
    }

}
