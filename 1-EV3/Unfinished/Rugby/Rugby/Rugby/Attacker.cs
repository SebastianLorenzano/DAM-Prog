namespace Rugby
{
    public class Attacker : Player
    {
        public Attacker(Team team, string name) : base(team, name)
        {

        }

        protected override void ExecuteTurnWithBall(Stadium stadium)
        {
            if (MoveForward(stadium))
            {
                if (Utils.GetRandomInt(0, 4) == 0)
                    ExecuteTurnWithBall(stadium);
            }

            else
                ThrowShortPass(stadium);
        }

        protected override void ExecuteTurnWithoutBall(Stadium stadium)
        {
         if (GetDistanceToGoal() > 2)
                MoveForward(stadium);
        }
    }
}
