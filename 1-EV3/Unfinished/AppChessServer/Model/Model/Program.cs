using System.Data.SqlClient;
using System.Diagnostics;

namespace Model
{


    public class Program
    {
        static void Main(string[] args)
        {
            SqlDatabase.CreateSimpleton("Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;");
            TestConnection();

        }

        public static void TestConnection()
        {
            SqlDatabase.Instance.TestConnection();
        }
    }
}
