namespace Rugby
{
    public class Team
    {
        private string _name = "";
        public string Name => _name;

        public Team(string name)
        {
            if (name != null)
                _name = name;
        }

        public List<Player> GetTeamPlayers(Stadium stadium)
        {
            if (stadium == null)
                throw new Exception("Stadium is null");
            List<Player> result = new();
            for (int i = 0; i < stadium.CharCount; i++)
            {
                Character? character = stadium.GetCharacterAtIndex(i);
                if (character is Player)
                {
                    Player player = (Player)character;
                    if (player.Team == this)
                        result.Add(player);
                }
            }
            return result;
        }

        public static (int x, int y)[] GetTeam1DefaultPositions()
        {
            var result = new (int x, int y)[10];    // 10 players per team
            result[0] = (2, 0);                     // first 2 players are Special Defenders,  
            result[1] = (7, 0);                     // 2-5 are Defenders, 6-9 are Attackers
            result[2] = (3, 0);
            result[3] = (4, 0); 
            result[4] = (5, 0);
            result[5] = (6, 0);
            result[6] = (3, 1);
            result[7] = (4, 1);
            result[8] = (5, 1);
            result[9] = (6, 1);
            return result;
        }

        public static (int x, int y)[] GetTeam2DefaultPositions()
        {
            var result = new (int x, int y)[10];    // 10 players per team
            result[0] = (2, 19);                     // first 2 players are Special Defenders,   
            result[1] = (7, 19);                     // 2-5 are Defenders, 6-9 are Attackers
            result[2] = (3, 19);
            result[3] = (4, 19);
            result[4] = (5, 19);
            result[5] = (6, 19);
            result[6] = (3, 18);
            result[7] = (4, 18);
            result[8] = (5, 18);
            result[9] = (6, 18);
            return result;
        }


    }


}
