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

        public static List<Player> GetTeammates(Player player, Stadium stadium)
        {
            List<Player> result = new();
            for (int i = 0; i < stadium.CharCount; i++)
            {
                Character? character = stadium.GetCharacterAtIndex(i);
                if (character is Player)
                {
                    Player p = (Player)character;
                    if (p.Team == player.Team && p != player)
                        result.Add(p);
                }
            }
            return result;
        }

        public static List<Player> GetTeammatesOnPointLine(Player player, Stadium stadium)
        {
            var result = GetTeammates(player, stadium);
            int y;
            if (player.Team == stadium.FirstTeam)
                y = 0;
            else
                y = 9;
            foreach (var p in result)
            {
                if (Math.Abs( p.y - y) <= 2)
                    result.Add(p);
            }
            return result;
        }

    }
}
