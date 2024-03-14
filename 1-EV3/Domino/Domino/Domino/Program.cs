using static Domino.ConservativePlayer;

namespace Domino
{
    public class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            players.Add(new ImpulsivePlayer("Pepe"));
            players.Add(new ConservativePlayer("Rebecca"));
            players.Add(new ConservativePlayer("Marta"));
            players.Add(new ImpulsivePlayer("Luis"));

            Game game = new Game(new PlayersList(players), new DominoDeck().Fill());
            game.StartGame();
        }

        /* Si cada una de esas funciones devuelve al mazo, puede usar sus funciones  */
        /* Deck d = new Deck().Fill().Shuffle(); */
    }
}
