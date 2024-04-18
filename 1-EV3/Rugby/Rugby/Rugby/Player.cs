namespace Rugby
{
    public class Player : Character
    {
        public string name = "Player";
        private Team _team;
        public Team Team => _team;


        public Player(Team team)
        {
            if (team == null)
                throw new Exception("Team is null");
                _team = team;
        }



        public override void ExecuteTurn()
        {
            throw new NotImplementedException();
        }
    }
}
