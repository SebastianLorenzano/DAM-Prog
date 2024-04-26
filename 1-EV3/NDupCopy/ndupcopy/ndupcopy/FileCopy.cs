namespace ndupcopy
{
    public class FileCopy
    {
        public static string? CopyFile(string originContainerPath, string absolutePath, string destination)
        {
            try
            {
                if (originContainerPath == null || absolutePath == null || destination == null)
                    return null;                           // Even if this shouldn't really be inside the try, I put it inside
                                                           //  so I can use Console.Error.WriteLine so you can redirect the error
                                                           //  to a file
                if (!Directory.Exists(destination))                 
                    Directory.CreateDirectory(destination);         // This two lines are not needed for the original function
                if (!File.Exists(absolutePath))                     //  but they are if you want to use it outside of it
                    throw new Exception("File does not exist");

                var relativePath = absolutePath.Substring(originContainerPath.Length);
                var trueDestination = Path.Join(destination, relativePath);

                if (!Directory.Exists(Path.GetDirectoryName(trueDestination)))
                    Directory.CreateDirectory(Path.GetDirectoryName(trueDestination));
                File.Copy(absolutePath, trueDestination);
                return trueDestination;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return null;
            }

        }

        public static bool CopyFiles(List<FileInfo> files, string destination, ref List<string> _errorsPath)
        {

            try
            {
                destination = Path.Join(destination, NDupCopy.FOLDERNAME);
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
                destination = Path.Join(destination, NDupCopy.CreateOutputFolder(destination));

                foreach (var f in files)
                {
                    f.NewPath = CopyFile(f.ContainerPath, f.Path, destination);
                    if (f.NewPath == null)
                        _errorsPath.Add(f.Path);
                }
                return true;
            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine(ex.ToString());                 // If it fails, it will print the error and return false
                return false;
            }
        }
    }

}
