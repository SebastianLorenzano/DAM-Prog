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


        public void Run()
        {
            var appParams = ParamsReader.ReadParams(Environment.GetCommandLineArgs());
            if (appParams == null)
                return;

            var inputFolders = appParams.Input_Folders;
            var outputFolders = appParams.Output_Folders;
            var options = appParams.Options;

            if (inputFolders == null || outputFolders == null)
                return;

            var files = FileReader.ReadAllFiles(inputFolders);
            if (files.Length == 0)
                return;

            _files.AddRange(files);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].IsDisabled)
                    continue;
                for (int j = i + 1; j < files.Length; j++)
                {
                    if (files[j].IsDisabled)
                        continue;
                    if (FileReader.CompareTwoFiles(files[i], files[j]))
                    {
                        files[j].IsDisabled = true;
                        _duplicates.Add(files[j]);
                    }
                }
                _notDuplicates.Add(files[i]);
            }

            if (options != null)
            {
                if (options.Contains("copy"))
                {
                    foreach (var file in _notDuplicates)
                    {
                        foreach (var outputFolder in outputFolders)
                        {
                            FileCopy.CopyFile(inputFolders[0], file.Path, outputFolder);
                        }
                    }
                }
            }
        }




        public void GetPosicionesADistancia((int x, int y) coordenadas, int distancia)
        {
            int x0 = coordenadas.x - distancia;
            int y0 = coordenadas.y - distancia;
            int x1 = coordenadas.x + distancia;
            int y1 = coordenadas.y - distancia;
            int x2 = coordenadas.x - distancia;
            int y2 = coordenadas.y + distancia;
            int x3 = coordenadas.x + distancia;
            int y3 = coordenadas.y + distancia;
            for (int i = 0; i < distancia * 2; i++, )
            {

            }
        }






    }
}
