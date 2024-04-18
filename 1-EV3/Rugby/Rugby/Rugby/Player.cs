namespace Rugby
{
    public abstract class Player : Character
    {
        public string name = "Player";
        private Team _team;
        public Team Team => _team;
        public (int, int) DefaultPosition { get; init; }


        public Player(Team team)
        {
            if (team == null)
                throw new Exception("Team is null");
                _team = team;

        }

      
    }
}
