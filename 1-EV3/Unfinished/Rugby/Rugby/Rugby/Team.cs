namespace Rugby
{

    public enum TeamNumber
    {
        TEAM1 = 1,
        TEAM2 = 2
    }

    public class Team
    {
        private string _name = "";
        public string Name => _name;
        public TeamNumber TeamNumber { get; init; }

        public Team(string name, TeamNumber teamNumber)
        {
            if (name != null)
                _name = name;
            TeamNumber = teamNumber;
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

        public static Position[] GetTeam1DefaultPositions()
        {
            var result = new Position[10];                      // 10 players per team
            result[0] = new Position(2, 0);                              // first 2 players are Special Defenders,  
            result[1] = new Position(7, 0);                              // 2-5 are Defenders, 6-9 are Attackers
            result[2] = new Position(3, 0);
            result[3] = new Position(4, 0); 
            result[4] = new Position(5, 0);
            result[5] = new Position(6, 0);
            result[6] = new Position(3, 1);
            result[7] = new Position(4, 1);
            result[8] = new Position(5, 1);
            result[9] = new Position(6, 1);
            return result;
        }

        public static Position[] GetTeam2DefaultPositions(int height)
        {
            var result = new Position[10];                      // 10 players per team
            result[0] = new Position(2, height - 1);                     // first 2 players are Special Defenders,   
            result[1] = new Position(7, height - 1);                     // 2-5 are Defenders, 6-9 are Attackers
            result[2] = new Position(3, height - 1);
            result[3] = new Position(4, height - 1);
            result[4] = new Position(5, height - 1);
            result[5] = new Position(6, height - 1);
            result[6] = new Position(3, height - 2);
            result[7] = new Position(4, height - 2);
            result[8] = new Position(5, height - 2);
            result[9] = new Position(6, height - 2);
            return result;
        }


    }


}
