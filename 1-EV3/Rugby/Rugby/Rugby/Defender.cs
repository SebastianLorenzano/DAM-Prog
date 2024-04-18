namespace Rugby
{
    public class Defender : Player
    {
        public Defender(Team team) : base(team)
        {

        }

        public override void ExecuteTurn()
        {
            throw new NotImplementedException();
        }
    }

    public class SpecialDefender : Defender
    {
        public SpecialDefender(Team team) : base(team)
        {

        }
    }

}
