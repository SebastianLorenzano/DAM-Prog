namespace Rugby
{
    public class Defender : Player
    {
        public Defender(Team team, string name) : base(team, name)
        {

        }

        public override void ExecuteTurn(Stadium stadium)
        {
            int random = Utils.GetRandomInt(0, 3);
            if (random < 3)
                MoveToRandomPosition(stadium);
            else
                ThrowLongPass(stadium);
        }
    }

    public class SpecialDefender : Defender
    {
        public SpecialDefender(Team team, string name) : base(team, name)
        {

        }
        public override void ExecuteTurn(Stadium stadium) 
        {
            throw new NotImplementedException();
        }
    }

}
