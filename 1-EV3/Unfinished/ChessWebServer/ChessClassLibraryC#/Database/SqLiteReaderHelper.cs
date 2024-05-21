using System.Data.SQLite;
using System.Xml;

namespace Database
{
    public class SqLiteReaderHelper
    {

        public string ExecuteQueryAndConvertToJson(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var results = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            results.Add(row);
                        }
                        return JsonConvert.SerializeObject(results, Formatting.Indented);
                    }
                }
            }
        }

    }
}
