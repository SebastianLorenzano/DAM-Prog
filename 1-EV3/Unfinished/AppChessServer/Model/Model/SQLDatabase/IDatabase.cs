using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDatabase
    {
        long AddUser(User user);
        void RemoveUser(long id);
        bool UpdateUser(long id, User user);
        User? GetUserWithId(long id);

        long AddGame(Game game);
        void RemoveGame(long id);
        bool UpdateGame(long id, Game game);
        Game? GetGame(long id);


    }
}
