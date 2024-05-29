
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using System;
using System.Diagnostics;

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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection opening was unsuccessful:  " + ex.Message);
            }
        }

        public long AddGame(GameDB game)
        {
            try
            {
                if (game == null || game.codUserWhites == null || game.codUserBlacks == null || game.gameJson == null)
                    return -1;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddGame", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUserWhites", game.codUserWhites);
                        command.Parameters.AddWithValue("@codUserBlacks", game.codUserBlacks);
                        command.Parameters.AddWithValue("@gameJson", game.gameJson);
                        SqlParameter outputParam = new SqlParameter("@codGame", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();
                        if (outputParam.Value == DBNull.Value)
                            game.codGame = -1;
                        else
                            game.codGame = Convert.ToInt64(outputParam.Value);
                        return game.codGame;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }

        public long AddUser(User user)
        {
            try
            {
                if (user == null || user.email == null || user.userName == null || user.password == null)
                    return -1;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@name", user.userName);
                        command.Parameters.AddWithValue("@email", user.email);
                        command.Parameters.AddWithValue("@password", user.password);
                        SqlParameter outputParam = new SqlParameter("@codUser", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
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
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }    
        public GameDB? GetGameWithId(long id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetGameWithId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codGame", id);
                        SqlParameter outputParam = new SqlParameter("@jsonGame", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return JsonSerializer.Deserialize<GameDB>(jsonString);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public User? GetUserWithId(long id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetUserWithId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUser", id);
                        SqlParameter outputParam = new SqlParameter("@jsonUser", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return JsonSerializer.Deserialize<User>(jsonString);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL exceptions (e.g., connection issues, command execution errors)
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }

        public void RemoveGame(long id)
        {
            if (id <= 0)
                return;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("RemoveGame", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codGame", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            Debug.WriteLine($"Se ha borrado el usuario {id} correctamente");
        }

        public void RemoveUser(long id)
        {
            if (id <= 0)
                return;
            try
            {
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
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            Debug.WriteLine($"Se ha borrado el usuario {id} correctamente");
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
