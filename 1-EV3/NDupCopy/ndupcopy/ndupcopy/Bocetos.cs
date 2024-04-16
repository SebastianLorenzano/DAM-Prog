using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    class Bocetos       
    {

        private static void CreateStructure(string originFolder, string absolutePath)   //        No esta chequeada, la deje de hacer ya que me di cuenta que
        {                                                                               //        Directory.CreateDirectory() ya crea la estructura de carpetas
            var folderPath = Path.GetDirectoryName(absolutePath);
            while (folderPath.Length > originFolder.Length)
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                folderPath = Path.GetDirectoryName(folderPath);
            }
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



    }
}
