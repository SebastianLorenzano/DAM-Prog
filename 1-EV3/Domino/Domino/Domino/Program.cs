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

            var pieces = new List<Piece>();
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0;  j <= 6; j++) 
                    pieces.Add(new Piece(i, j));
            }

            Game game = new Game(new PlayersList(players), new DominoDeck(pieces));
            game.StartGame();
        }
    }
}
