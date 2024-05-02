namespace ndupcopy
{
    public class FileCopy
    {
        public static string? CopyFile(string originContainerPath, string absolutePath, string destination)
        {
            try
            {
                if (originContainerPath == null || absolutePath == null || destination == null)
                    throw new NullReferenceException();    // Even if this shouldn't really be inside the try, I put it inside
                                                           //  so I can use Console.Error.WriteLine so you can redirect the error
                                                           //  to a file
                if (!Directory.Exists(destination))                 
                    Directory.CreateDirectory(destination);         // This two lines are not needed for the original script
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
                Logs.Instance.Error(ex.ToString());
                return null;
            }

        }

        public static string? CopyFiles(List<FileInfo> files, string destination) // returns the complete output path
        {

            try
            { 
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
                destination = NDupCopy.CreateOutputFolder(destination);

                foreach (var f in files)
                {
                    f.NewPath = CopyFile(f.ContainerPath, f.Path, destination);
                }
                return destination;
            }
            catch (Exception ex) 
            {
                Logs.Instance.Error(ex.ToString());                 // If it fails, it will print the error and return false
                return null;
            }
        }
    }

}
