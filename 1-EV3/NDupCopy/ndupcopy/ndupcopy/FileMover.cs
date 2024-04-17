namespace ndupcopy
{
    public class FileMover
    {
        public static void CopyFile(string originFolder, string absolutePath, string destination)
        {
            if (absolutePath == null || destination == null)
                return;
            if (!Directory.Exists(destination))
                throw new Exception("Directory does not exist or file does not exist");
            if (!File.Exists(absolutePath))
                throw new Exception("File does not exist");

            var relativePath = absolutePath.Substring(originFolder.Length);
            var trueDestination = Path.Combine(destination, relativePath);

            if (!Directory.Exists(Path.GetDirectoryName(trueDestination)))
                Directory.CreateDirectory(Path.GetDirectoryName(trueDestination));
            File.Copy(absolutePath, destination);
        }
    }
}
