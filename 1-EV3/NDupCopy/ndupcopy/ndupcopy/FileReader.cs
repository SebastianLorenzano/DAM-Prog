namespace ndupcopy
{
    public class FileReader
    {
        public static FileInfo[] ReadAllFiles(string[] paths)
        {
            var result = new List<FileInfo>();
            if (paths == null || paths.Length == 0)
                return result.ToArray();
            for (int i = 0; i < paths.Length; i++) 
            {
                var filePaths = Directory.GetFiles(paths[i]);
                foreach (var filePath in filePaths)
                    result.Add(GetFileInfo(filePath));
            }
        }

        public static FileInfo GetFileInfo(string path)
        {

        }

    }
}
