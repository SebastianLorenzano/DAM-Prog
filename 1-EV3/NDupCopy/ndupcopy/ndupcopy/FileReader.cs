using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml.Schema;

namespace ndupcopy
{
    public class FileReader
    {

        public static FileInfo[] ReadAllFilesToArray(string[] paths, string pattern)
        {
            return ReadAllFiles(paths, pattern).ToArray();

        }

        public static List<FileInfo> ReadAllFiles(string[] paths, string pattern = "*.*")
        {
            var result = new List<FileInfo>();
            if (paths == null)
                return result;
            foreach (var p in paths)
                result.AddRange(ReadFiles(p, p, pattern));
            return result;
        }

        public static List<FileInfo> ReadFiles(string path, string containerPath, string pattern = "*.*")
        {
            List<FileInfo> result = new();
            if (path == null || path.Length == 0)
                return result;
            var files = new List<string>();
            var directories = Array.Empty<string>();
            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                directories = Directory.GetDirectories(path);
                foreach (var f in files)
                    result.Add(GetFile(f, containerPath));
            }
            catch (Exception ex) 
            {
                Logs.Instance.Error(ex.ToString());
            }
            foreach (var directory in directories)
                try
                {
                    result.AddRange(ReadFiles(directory, containerPath, pattern));
                }
                catch (Exception ex) 
                {
                    Logs.Instance.Error(ex.ToString());
                }
            return result;
        }

        private static FileInfo? GetFile(string path, string containerPath)
        {
            try
            {
                return GetFileInfo(path, containerPath);
            }
            catch (Exception ex)
            {
                Logs.Instance.Error(ex.ToString());
                return null;
            }
        }


        public static FileInfo? GetFileInfo(string path, string containerPath)
        {
            if (path == null)
                return null;
            var hashS = HashCalculator.GetHash(path);
            return new FileInfo()
            {
                Path = path,
                ContainerPath = containerPath,
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
            if (f1 == null || f2 == null || f1.Length != f2.Length)     // It's checked already on CompareTwoFiles(), but because it's not gonna be almost used in most cases, it 
                return false;                                            // doesn't hurt to add it as a precaution in case CompareTwoFiles() gets changed and it doesn't make a difference
            using (FileStream fs1 = File.OpenRead(f1.Path))                 // in performance
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


        public static bool CompareAndClassify(FileInfo[] array, ref List<FileInfo> duplicates, ref List<FileInfo> nonDuplicates)        // Compares the whole list and divides between duplicates and nonDuplicates,
        {                                                                                                                                 // doesn't modify the original list.
            if (array == null || duplicates == null || nonDuplicates == null)
                return false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                var f1 = array[i];
                if (f1.IsDisabled)
                    continue;
                for (int j = i + 1; j < array.Length; j++)
                {
                    var f2 = array[j];
                    if (f2.IsDisabled || !CompareTwoFiles(f1, f2))          // If is disabled or if they are not equals
                        continue;
                    f2.IsDisabled = true;
                }
            }
            foreach (var f in array)
            {
                if (f.IsDisabled)
                    duplicates.Add(f);
                else
                    nonDuplicates.Add(f);
            }
            return true;
        }

    }
}
