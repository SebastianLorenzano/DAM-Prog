using System;

namespace Database
{
    public class SqLiteDatabase : IDatabase
    {
        private static SqLiteDatabase _database = new();
        public static SqLiteDatabase Instance => _database; // How can I prevent for people to put it to null?

        public long AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public long AddMovement(Movement mov)
        {
            throw new NotImplementedException();
        }

        public long AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Game? GetGameWithId(long id)
        {
            throw new NotImplementedException();
        }

        public Movement? GetMovementWithId(long id)
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

        public void RemoveMovement(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(long id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGame(long id, Game game)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovement(long id, Movement mov)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(long id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
