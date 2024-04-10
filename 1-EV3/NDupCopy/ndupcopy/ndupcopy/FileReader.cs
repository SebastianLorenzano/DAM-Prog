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

        /*
        public static bool CompareByteByByteInt64(FileInfo f1, FileInfo f2) 
        {
            const int BYTES_TO_READ = sizeof(Int64);
            int iterations = (int)Math.Ceiling((double)f1.Length / BYTES_TO_READ);

                using (FileStream fs1 = File.OpenRead(f1.Path))
                using (FileStream fs2 = File.OpenRead(f2.Path))
                {
                    byte[] one = new byte[BYTES_TO_READ];
                    byte[] two = new byte[BYTES_TO_READ];

                    for (int i = 0; i < iterations; i++)
                    {   
                        fs1.Read(one, 0, BYTES_TO_READ);                   // Ya que el Read toma en cuenta si llega al final de la linea y
                        fs2.Read(two, 0, BYTES_TO_READ);                   //  si lee menos cantidad, no es necesario estar atento de si devuelve mas o no

                        if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                            return false;
                    }
                }

                return true;
            }
        */


                                                                         
        internal static bool CompareByteByByte(FileInfo f1, FileInfo f2)
        {
            if (f1 == null || f2 == null)
                return false;
            using (FileStream fs1 = File.OpenRead(f1.Path))
            using (FileStream fs2 = File.OpenRead(f2.Path))
            {
                for (int i = 0; i < f1.Length; i++)
                {
                    if (fs1.ReadByte() != fs2.ReadByte())
                        return false;
                }
            }
            return true;
        }
        





    }
}
