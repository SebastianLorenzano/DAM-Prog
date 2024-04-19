namespace Rugby
{
    public class Attacker : Player
    {
        public Attacker(Team team, string name) : base(team, name)
        {

        }

        public override void ExecuteTurn(Stadium stadium)
        {
            throw new NotImplementedException();
        }
    }
}
