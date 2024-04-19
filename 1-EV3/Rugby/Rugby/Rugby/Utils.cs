namespace Rugby
{
    public class Utils
    {
        private static Random random = new Random();

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static int GetDistance(Entity entity1, Entity entity2)
        {
            int dx = entity2.x - entity1.x;
            int dy = entity2.y - entity1.x;
            return (int)(Math.Floor(Math.Sqrt(dx * dx + dy * dy)));       // Rounds down the distance to the nearest integer and casts it
        }

    }
}
