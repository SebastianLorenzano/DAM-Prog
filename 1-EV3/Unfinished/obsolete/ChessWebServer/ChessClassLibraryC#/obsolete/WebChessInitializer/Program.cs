using System;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace WebChessInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath("../../../../mywebchess.db");
            string connectionString = "Data Source=" + path;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS USERS (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    email TEXT UNIQUE NOT NULL,
                    password TEXT NOT NULL,
                    dateRegister DATETIME DEFAULT CURRENT_TIMESTAMP
                );";

                string createGamesTable = @"
                CREATE TABLE IF NOT EXISTS GAMES (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    playerWhiteId INTEGER NOT NULL,
                    playerBlacksId INTEGER NOT NULL,
                    dateStart DATETIME DEFAULT CURRENT_TIMESTAMP,
                    Resultado TEXT,
                    FOREIGN KEY (playerWhiteId) REFERENCES USERS(idd),
                    FOREIGN KEY (playerBlacksId) REFERENCES USERS(Id)
                );";

                string createMovementsTable = @"
                CREATE TABLE IF NOT EXISTS MOVEMENTS (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    gameId INTEGER NOT NULL,
                    movementNumber INTEGER NOT NULL,
                    playerId INTEGER NOT NULL,
                    description TEXT NOT NULL,
                    dateMovement DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (gameId) REFERENCES USERS(Id),
                    FOREIGN KEY (playerId) REFERENCES USERS(Id)
                );";

                using (var command = new SQLiteCommand(createUsersTable, connection))
                    command.ExecuteNonQuery();
                using (var command = new SQLiteCommand(createGamesTable, connection))
                    command.ExecuteNonQuery();

                using (var command = new SQLiteCommand(createMovementsTable, connection))
                    command.ExecuteNonQuery();

                Console.WriteLine("Tablas creadas correctamente.");

                // Insertar datos de ejemplo
                string insertUsuarios = @"
                INSERT INTO USERS (name, email, password) VALUES
                ('Juan Pérez', 'juan@example.com', 'password1'),
                ('Ana Gómez', 'ana@example.com', 'password2');";

                using (var command = new SQLiteCommand(insertUsuarios, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Datos iniciales insertados correctamente.");
            }

           
        }
    }

}



