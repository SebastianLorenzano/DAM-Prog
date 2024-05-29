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
        User? GetUserWithId(long id);

        long AddGame(GameDB game);
        void RemoveGame(long id);
        bool UpdateGameJson(long id, GameDB game);
        GameDB? GetGameWithId(long id);


    }
}
