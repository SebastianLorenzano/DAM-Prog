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

    }


}
