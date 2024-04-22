namespace Rugby
{

    public class Position
    {
        public int x, y;

        public Position()
        { }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

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
            return (int)Math.Floor(Math.Sqrt(dx * dx + dy * dy));       // Rounds down the distance to the nearest integer and casts it
        }

        public static int GetDistance(Position pos1, Position pos2)
        {
            int dx = pos2.x - pos1.x;
            int dy = pos2.y - pos1.y;
            return (int)Math.Floor(Math.Sqrt(dx * dx + dy * dy));       // Rounds down the distance to the nearest integer and casts it
        }

        public static Position? GetBestPosition(Position origin, Position destiny, Stadium stadium)    // Gets the best position to move when
        {                                                                                        // trying to get to the destiny
            if (origin == null || destiny == null)
                return null;
            var distance = GetDistance(origin, destiny);
            Position result = new Position(origin.x, origin.y);
            for (int y = origin.y - 1; y <= origin.y + 1; y++)
                for (int x = origin.x -1; x <= origin.x + 1; x++)
                {
                    int newDistance = GetDistance(new Position(x, y), destiny);
                    if (stadium.IsPositionAvailable(x, y) && newDistance > distance)
                    {
                        distance = newDistance;
                        result.x = x;
                        result.y = y;
                    }
                }
            return result;
        }

        public static List<Player> SortByDistance(List<Player> list, SortDelegate del)
        {
            if (del == null || list == null)
                throw new ArgumentNullException();
            var result = new List<Player>(list);
            for (int i = 0; i < result.Count - 1; i++)
                    for (int j = i + 1; j < result.Count; j++)
                    {
                        if (del(result[i], result[j]) > 0)
                        {
                            var aux = result[i];
                            result[i] = result[j];
                            result[j] = aux;
                        }
                    }
            return result;
        }
    }
}


