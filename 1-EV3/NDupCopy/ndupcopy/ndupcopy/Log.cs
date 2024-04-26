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
            FileStream fs;
            try
            {
                while (true)
                {
                    if (Directory.Exists(absOutputPath))
                        absOutputPath = Path.Join(absOutputPath, "NDupCopy");
                    else
                        break;
                }
                fs = new FileStream(absOutputPath, FileMode.CreateNew);     // Make it so it creates a log or leaves it blank
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
