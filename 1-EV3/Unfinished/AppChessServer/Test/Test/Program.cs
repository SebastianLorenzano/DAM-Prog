using Model;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlDatabase.CreateSimpleton("Server=192.168.56.101,1433;Database=CHESS;User Id=sa;Password=SqlServer123;");
            TestConnection();
            var user1 = new User() { Name = "Pepe", Email = "test6@example.com", Password = "password123" };
            long result = SqlDatabase.Instance.AddUser(user1);
            Console.WriteLine($"Resultado de AddUser: {result}, codUser: {user1.codUser}");
            Console.WriteLine("pepe");
            var user2 = SqlDatabase.Instance.GetUserWithId(user1.codUser);
            if (user2 == null)
                Console.WriteLine("No se pudo encontrar un usuario");
            else
                Console.WriteLine(user2.ToString());

        }
        public static void TestConnection()
        {
            SqlDatabase.Instance.TestConnection();
        }
    }
}
