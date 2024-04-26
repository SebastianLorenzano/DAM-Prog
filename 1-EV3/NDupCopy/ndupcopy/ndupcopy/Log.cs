
namespace ndupcopy
{

    public class Logs
    {
        public static Logs Instance => _log;
        private static Logs _log = new Logs();

        private List<Log> _logs = new List<Log>();
        public int Count => _logs.Count;

        private Logs()
        {

        }

        public Log? GetLogAt(int index) => (index >= 0 && index<_logs.Count)  ? _logs[index] : null;


        public void Test()
        {
            int code = 0;
            Info($"Este es mi error {code}");
        }

        public void Info(string? message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Warning(string? message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Error(string? message) 
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
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
