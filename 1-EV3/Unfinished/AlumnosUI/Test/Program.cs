using System.Data.SqlClient;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    internal class Program
    {
        public const string ConnectionString = "Server=192.168.56.101,1433;Database=STUDENTS;User Id=sa;Password=SqlServer123;";
        static void Main(string[] args)
        {


        }

        public static void TestConnection()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                    Debug.Assert(false);
                }
            }
            Debug.Assert(true);
            
        }

        public static long ExecuteInsert(string name, int age)
        {
            string query = "INSERT INTO students(nombre, edad) VALUES (@Nombre, @Edad)";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", name);
                    command.Parameters.AddWithValue("@Age", age);
                    long idGenerado = Convert.ToInt64(command.ExecuteScalar());
                    return idGenerado;
                }
            }
        }



        public static void TestInsertStudent()
        {
            ExecuteInsert("Pepe", 16);
        }

        public static void ExecuteSelect()
        {

        }

        public static void TestSelect()
        {
            string name = "Ana";
            int age = 21;
            long id = ExecuteInsert(name, age);
            string query = "SELECT id, name, age FROM students WHERE id = @studentId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", id);
                    using (var cursor = command.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            var idStudent = Convert.ToInt64(cursor.GetValue(0));
                            var nameStudent = cursor.GetString(1);
                            var ageStudent = Convert.ToInt32(cursor.GetValue(2));
                            Debug.Assert(nameStudent == name && age == ageStudent);
                            
                        }
                    }

                }
            }
        }

    }
}

