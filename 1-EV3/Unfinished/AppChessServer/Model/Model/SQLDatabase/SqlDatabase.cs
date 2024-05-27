
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace Model
{
    public class SqlDatabase : IDatabase
    {
        private string connectionString;
        private static SqlDatabase _database;
        public static SqlDatabase Instance => _database;

        private SqlDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static void CreateSimpleton(string connectionString) 
        {
            if (_database == null && connectionString != null) 
            {
                _database = new SqlDatabase(connectionString);
            }
        }

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection opening was unsuccessful:  " + ex.Message);
                }
                    
            }
        }

        public long AddGame(GameDB game)
        {
            if (game != null && game.Board != null)
                throw new NotImplementedException();
            return -1;
        }

        public long AddUser(User user)
        {
            if (user == null || user.Email == null || user.Name == null || user.Password == null)
                return -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    SqlParameter outputParam = new SqlParameter("@codUser", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outputParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    if (outputParam.Value == DBNull.Value)
                        user.codUser = -1;
                    else
                        user.codUser = Convert.ToInt64(outputParam.Value);
                    return user.codUser;
                }
            }

        }    
        public GameDB? GetGame(long id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserWithId(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT dbo.GetUserWithId(@codUser)", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@codUser", id);

                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return null;
                    string jsonString = result.ToString();
                    return JsonSerializer.Deserialize<User>(jsonString);
                }
            }
        }

        public void RemoveGame(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(long id)
        {
            if (id <= 0)
                return;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("RemoveUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codUser", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateGame(long id, GameDB game)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(long id, User user)
        {
            throw new NotImplementedException();
        }

    }
}
