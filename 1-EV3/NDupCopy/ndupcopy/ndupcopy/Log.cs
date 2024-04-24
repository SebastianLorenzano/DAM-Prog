using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ndupcopy.ParamsReader;

namespace ndupcopy
{

    public enum LogType
    {
        NONDUPLICATE,
        DUPLICATE
    }

    public class Log
    {

        internal static int CreateLog(string fileName, string outputFolder, List<FileInfo> list)
        {
            if (fileName == null || outputFolder == null)
                return - 1;
            var absOutputPath = Path.Combine(outputFolder, fileName);

            var fs = new FileStream(absOutputPath, FileMode.CreateNew);
            try
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    foreach (var item in list)
                        writer.WriteLine(item.Path + "  ==>  " + item.NewPath);
                }
                return 0;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return -2;
            }

        }

    }
}
