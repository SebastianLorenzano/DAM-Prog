namespace Model
{
    public interface IDatabase
    {
        long AddUser(User user);
        void RemoveUser(long id);
        bool UpdateUserName(long id, User user);
        User? GetUserWithId(long id);
        User? GetUserWithEmailAndPassword(string email, string password);
        

        long AddGame(Game game);
        void RemoveGame(long id);
        bool UpdateGameJson(long id, Game game);
        Game? GetGameWithId(long id);
        List<Game> GetGamesWithUserId(long id, int offset, int max);
    }
}
