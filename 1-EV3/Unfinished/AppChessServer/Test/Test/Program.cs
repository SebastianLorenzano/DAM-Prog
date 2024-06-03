using Model;
using System.Text.Json;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlDatabase.CreateSimpleton("Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;");
            TestConnection();
            //TestUserDB();
            //TestGameDB();
            //TestBoard();
            TestJson();

        }

        public static void TestJson()
        {
            
        }

        public static void TestConnection()
        {
            SqlDatabase.Instance.TestConnection();
        }

        public static void TestUserDB()
        {
            var db = SqlDatabase.Instance;
            var user1 = new User() { userName = "Pepe", email = "test10@example.com", password = "password123" };
            long result = db.AddUser(user1);
            Console.WriteLine($"Resultado de AddUser: {result}, codUser: {user1.codUser}");
            Console.WriteLine("pepe");
            var user2 = db.GetUserWithId(user1.codUser);
            if (user2 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine("Resultado de GetUserWithId: " + user2.codUser + user2.userName + user2.email  + user2.password);
            var user3 = db.GetUserWithEmailAndPassword(user1.email, user1.password);
            if (user3 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine("Resultado de GetUserWithEmailAndPassword: " + user3.codUser + user3.userName + user3.email + user3.password);
         
            db.RemoveUser(user2.codUser);
            var user4 = db.GetUserWithId(user2.codUser);
            if (user4 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine(user4.userName + user4.email + user4.codUser + user4.password);

        }

        public static void TestGameDB()
        {/*
            var db = SqlDatabase.Instance;
            var user1 = new User() { userName = "Pepe", email = "gameTest3@example.com", password = "password123" };
            var user2 = new User() { userName = "Pepa", email = "gameTest4@example.com", password = "password456" };
            db.AddUser(user1);
            db.AddUser(user2);
            string gameJson = "Esto es un jsonDeGame";
            var game1 = new Game() { codUserWhites = user1.codUser, codUserBlacks = user2.codUser, board =  new Board().Fill()};
            var result = db.AddGame(game1);
            Console.WriteLine($"Resultado de AddGame: {result}, codGame: {game1.codGame}");
            var game2 = db.GetGameWithId(game1.codGame);
            if (game2 == null)
                Console.WriteLine("No se pudo encontrar un game");
            else
                Console.WriteLine($"codGame: {game2.codGame} codUserWhites: {game2.codUserWhites} codUserBlacks: {game2.codUserBlacks} gameJson: {game2.gameJson}");
            var resultUpdateGameJson = db.UpdateGameJson(game1.codGame, new Game() {board = new Board().Fill() });
            if (resultUpdateGameJson)
                Console.WriteLine($"Resultado de UpdateGameJson: Satisfactorio");
            else
                Console.WriteLine($"Resultado de UpdateGameJson: Insatisfactorio");

            db.RemoveGame(game1.codGame);
            var game3 = db.GetGameWithId(game1.codGame);
            if (game3 == null)
                Console.WriteLine("No se pudo encontrar un game");
            else
                Console.WriteLine($"codGame: {game3.codGame} codUserWhites: {game3.codUserWhites} codUserBlacks: {game3.codUserBlacks} gameJson: {game3.gameJson}");
            var user3 = new User() { userName = "Pepe", email = "gameTestGetGamesWithUserId23@example.com", password = "password123" };
            var user4 = new User() { userName = "Pepa", email = "gameTestGetGamesWithUserId24@example.com", password = "password456" };
            result = db.AddUser(user3);
            Console.WriteLine($"Resultado de AddUser: {result}, codUser: {user3.codUser}");
            result = db.AddUser(user4);
            Console.WriteLine($"Resultado de AddUser: {result}, codUser: {user4.codUser}");
            var game4 = new Game() { codUserWhites = user3.codUser, codUserBlacks = user4.codUser, board = new Board().Fill() };
            result = db.AddGame(game4);
            Console.WriteLine($"Resultado de AddGame: {result}, codGame: {game4.codGame}");
            var resultGetGamesWithUserId1 = db.GetGamesWithUserId(user3.codUser, 0, 5);
            var resultGetGamesWithUserId2 = db.GetGamesWithUserId(user4.codUser, 0, 5);
            Console.WriteLine(resultGetGamesWithUserId1.ToString());
            Console.WriteLine(resultGetGamesWithUserId2.ToString());
            */
        }

        public static void TestBoard()
        {
            Board board = new Board();
            BoardToString(board);
            board.Fill();
            BoardToString(board);
        }

        private static void BoardToString(Board board)
        {
            Console.WriteLine("Empezando WriteLine");
            for (int i = 0; i <= Board.WIDTH; i++)
            {
                for (int j = 0; j <= Board.HEIGHT; j++)
                {
                    var p = board.GetPieceWithPosition(new Position(i, j));
                    if (p != null)
                        Console.WriteLine($"Position: {p.X}, ¨{p.Y}; Type: {p.Type}; Color: {p.Color}; PossiblePositions: {JsonSerializer.Serialize(p.GetPosiblePositions(board))}");
                }
            }
        }   
    }
}
