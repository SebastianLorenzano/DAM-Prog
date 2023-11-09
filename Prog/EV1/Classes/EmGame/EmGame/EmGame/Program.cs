using Classes;
using UDK;

namespace EmGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmGame emgame = new EmGame();
            UDK.Game.Launch(emgame);
        }
    }
    }
