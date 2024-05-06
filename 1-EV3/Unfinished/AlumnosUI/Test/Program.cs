using System.Data.SqlClient;

namespace Test
{
    internal class Program
    {
        public const string connectionString = "Server=190.168.56.101,1433;Database=STUDENTS;User Id=sa;Password=SqlServer123;";
        static void Main(string[] args)
        {


        }

        public static void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open ();
                }
                catch (Exception ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                }

            }
            


        }

        
    }
}

