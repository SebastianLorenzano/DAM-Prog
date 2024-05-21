using System;

namespace Model
{
    public interface IDatabase
    {
        long AddUser(User user);
        void RemoveUser(long id);
        bool UpdateUser(long id, User user);
        User? GetUserWithId(long id);
        //User GetUserAt(int index);

        long AddGame(Game game);
        void RemoveGame(long id);
        bool UpdateGame(long id, Game game);
        Game? GetGameWithId(long id);

        long AddMovement(Movement mov);
        void RemoveMovement(long id);
        bool UpdateMovement(long id, Movement mov);
        Movement? GetMovementWithId(long id);


    }
}
