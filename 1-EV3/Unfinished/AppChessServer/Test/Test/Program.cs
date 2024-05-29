using Model;
using System.Data.Entity.Validation;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlDatabase.CreateSimpleton("Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;");
            TestConnection();
            //TestUserDB();
            TestGameDB();

        }
        public static void TestConnection()
        {
            SqlDatabase.Instance.TestConnection();
        }

        public static void TestUserDB()
        {
            var db = SqlDatabase.Instance;
            var user1 = new User() { userName = "Pepe", email = "test1@example.com", password = "password123" };
            long result = db.AddUser(user1);
            Console.WriteLine($"Resultado de AddUser: {result}, codUser: {user1.codUser}");
            Console.WriteLine("pepe");
            var user2 = db.GetUserWithId(user1.codUser);
            if (user2 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine(user2.userName + user2.email + user2.codUser + user2.password);
            db.RemoveUser(user2.codUser);
            var user3 = db.GetUserWithId(user2.codUser);
            if (user3 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine(user3.userName + user3.email + user3.codUser + user3.password);

        }

        public static void TestGameDB()
        {
            var db = SqlDatabase.Instance;
            var user1 = new User() { userName = "Pepe", email = "gameTest1@example.com", password = "password123" };
            var user2 = new User() { userName = "Pepa", email = "gameTest2@example.com", password = "password456" };
            db.AddUser(user1);
            db.AddUser(user2);
            string gameJson = "Esto es un jsonDeGame";
            var game1 = new GameDB() { codUserWhites = user1.codUser, codUserBlacks = user2.codUser, gameJson =  gameJson };
            var result = db.AddGame(game1);
            Console.WriteLine($"Resultado de AddGame: {result}, codGame: {game1.codGame}");
            var game2 = db.GetGameWithId(game1.codGame);
            if (game2 == null)
                Console.WriteLine("No se pudo encontrar un game");
            else
                Console.WriteLine($"codGame: {game2.codGame} codUserWhites: {game2.codUserWhites} codUserBlacks: {game2.codUserBlacks} gameJson: {game2.gameJson}");
            var resultUpdateGameJson = db.UpdateGameJson(game1.codGame, new GameDB() { gameJson = "Este es el nuevo gameJson"});
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


        }
    }
}
