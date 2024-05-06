
namespace ndupcopy
{
    public class Logs
    {
        public static Logs Instance => _logs;           // First time I used Simpletons, I'm not really using the potential of them but I had to modify all the code 
        private static Logs _logs = new Logs();          // to implement it further, so I added it as long as I didn't have to modify the whole script.

        private List<Log> _list = new List<Log>();
        public int Count => _list.Count;

        private Logs()
        {

        }

        public void Info(string? message)                           // I know conceptually its wrong and it should be a static and there is no reason to do things like this, but I 
        {                                                             // wanted to try out the Simpleton thing, nothing else
            Console.WriteLine(message);
        }

        public void Warning(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Error(string? message) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

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
                        if (item.NewPath == null)
                        {
                            Logs.Instance.Warning(item.Path + " is duplicated.");
                            writer.WriteLine(item.Path + " is duplicated.");
                        }
                    else
                        {
                            Logs.Instance.Info(item.Path + "  ==>  " + item.NewPath);
                            writer.WriteLine(item.Path + "  ==>  " + item.NewPath);
                        }
                    
                            
                    
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
