﻿using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
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

        public long AddUser(User user)
        {
            if (user == null || user.email == null || user.userName == null || user.password == null)
                return -1;
            try
            {
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
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
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

        public bool UpdateUserName(long id, User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@codUser", id);
                        command.Parameters.AddWithValue("@userName", user.userName);

                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        connection.Open();
                        command.ExecuteNonQuery();
                        if ((int)returnValue.Value == 0)
                            Debug.WriteLine($"Se ha updateado el usuario {id} correctamente");
                        return (int)returnValue.Value == 0; // 0 = Everything went right
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return false;
            }
        }

        public User? GetUserWithId(long id)
        {
            if (id <= 0)
                return null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetUserWithId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUser", id);
                        var outputParam = new SqlParameter("@jsonUser", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return JsonConvert.DeserializeObject<User>(jsonString);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }

        public User? GetUserWithEmailAndPassword(string email, string password)
        {
            if (email == null || password == null)
                return null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetUserWithEmailAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        var outputParam = new SqlParameter("@jsonUser", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return JsonConvert.DeserializeObject<User>(jsonString);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public long GetCodUserWithEmail(string email)
        {
            if (email == null)
                return -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetCodUserWithEmail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);
                        var outputParam = new SqlParameter("@codUser", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return -2;
                        return Convert.ToInt64(outputParam.Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return -3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -4;
            }

        }

        public long AddGame(Game game)
        {
            if (game == null || game.codUserWhites == null || game.codUserBlacks == null || game.board == null)
                return -1;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddGame", connection))
                    {
                        var jsonBoard = game.board.JsonSerialize();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUserWhites", game.codUserWhites);
                        command.Parameters.AddWithValue("@codUserBlacks", game.codUserBlacks);
                        command.Parameters.AddWithValue("@board", jsonBoard);
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
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
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

        public bool UpdateGameJson(long id, Game game)
        {
            if (id <= 0 || game == null || game.board == null)
                return false;
            try
            {
                var jsonBoard = JsonConvert.SerializeObject(game.board);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateGameJson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@codGame", id);
                        command.Parameters.AddWithValue("@board", jsonBoard);

                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        connection.Open();
                        command.ExecuteNonQuery();
                        if ((int)returnValue.Value == 0)
                            Debug.WriteLine($"Se ha updateado el game {id} correctamente");
                        return (int)returnValue.Value == 0; // 0 = Everything went right
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return false;
            }

        }

        public Game? GetGameWithId(long id)
        {
            if (id <= 0)
                return null;
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
                        return Game.Deserialize(jsonString);
                        
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public List<Game> GetGamesWithUserId(long id, int offset, int max)
        {
            if (id <= 0 || offset < 0 || max <= 0)
                return null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetGamesWithCodUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUser", id);
                        command.Parameters.AddWithValue("@offset", offset);
                        command.Parameters.AddWithValue("@max", max);
                        SqlParameter outputParam = new SqlParameter("@jsonGames", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return Game.DeserializeList(jsonString);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public List<Game> GetGames(int offset, int max)
        {
            if (offset < 0 || max <= 0)
                return null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetGames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@offset", offset);
                        command.Parameters.AddWithValue("@max", max);
                        SqlParameter outputParam = new SqlParameter("@gamesJson", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputParam.Value == null || outputParam.Value == DBNull.Value)
                            return null;
                        string jsonString = outputParam.Value.ToString();
                        return Game.DeserializeList(jsonString);

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public int GetGamesCountWithCodUser(long codUser)
        {
            if (codUser <= 0)
                return 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetGamesCountWithCodUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codUser", codUser);
                        SqlParameter outputParam = new SqlParameter("@count", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();
                        if (outputParam.Value == DBNull.Value)
                            return 0;
                        else
                            return Convert.ToInt32(outputParam.Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }
    }
}
