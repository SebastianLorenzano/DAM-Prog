
namespace Model
{
    public class SqlDatabase : IDatabase
    {
        private static SqlDatabase _database = new();
        public static SqlDatabase Instance => _database;

        private SqlDatabase()
        {

        }
        public long AddGame(GameDB game)
        {
            if (game != null && game.Board != null)
                throw new NotImplementedException();
            return -1;
        }

        public long AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public GameDB? GetGame(long id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserWithId(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(long id)
        {
            throw new NotImplementedException();
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
