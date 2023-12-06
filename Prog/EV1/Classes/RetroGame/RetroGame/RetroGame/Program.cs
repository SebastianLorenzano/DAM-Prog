namespace RetroGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            RetroGame retroGame = new();
            UDK.Game.Launch(retroGame);
        }
    }
}