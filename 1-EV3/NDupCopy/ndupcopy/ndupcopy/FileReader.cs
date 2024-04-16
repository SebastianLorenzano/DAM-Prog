using System;
using System.Collections.Generic;

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
            return result.ToArray();
        }

        public static FileInfo? GetFileInfo(string path)
        {
            if (path == null)
                return null;
            var hashS = HashCalculator.GetHash(path);
            return new FileInfo()
            {
                Path = path,
                Length = new System.IO.FileInfo(path).Length,
                HashS = hashS,
                HashL = hashS.GetHashCode(),
                IsDisabled = false
            };
        }

        public static bool CompareTwoFiles(FileInfo f1, FileInfo f2)
        {
            if (f1 == null || f2 == null)
                return false;
            return f1.HashL == f2.HashL && f1.Length == f2.Length && f1.HashS == f2.HashS && CompareByteByByte(f1, f2);
        }
                                              
        private static bool CompareByteByByte(FileInfo f1, FileInfo f2)
        {
            if (f1 == null || f2 == null || f1.Length != f2.Length)
                return false;
            using (FileStream fs1 = File.OpenRead(f1.Path))
            using (FileStream fs2 = File.OpenRead(f2.Path))
            {
                long n = fs1.Length;
                for (int i = 0; i < n; i++)
                {
                    if (fs1.ReadByte() != fs2.ReadByte())
                        return false;
                }
            }
            return true;
        }

        public static void MoveFile(string originFolder, string absolutePath, string destination)
        {
            if (absolutePath == null || destination == null)
                return;
            if (!Directory.Exists(destination))
                throw new Exception("Directory does not exist or file does not exist");
            if (!File.Exists(absolutePath))
                throw new Exception("File does not exist");
                
            var relativePath = absolutePath.Substring(originFolder.Length);
            destination = Path.Combine(destination, relativePath);

            if (!Directory.Exists(Path.GetDirectoryName(destination)))
                Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Move(absolutePath, destination);

        }



    }
}
