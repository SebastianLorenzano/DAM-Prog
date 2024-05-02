namespace Rugby
{
    public class Defender : Player
    {
        public Defender(Team team, string name) : base(team, name)
        {

        }

        protected override void ExecuteTurnWithBall(Stadium stadium)
        {
            int random = Utils.GetRandomInt(0, 3);
            if (random < 3)
            {
                MoveForward(stadium);
            }
            else
                ThrowLongPass(stadium);
        }

        protected override void ExecuteTurnWithoutBall(Stadium stadium)
        {
            Position ballPos = stadium.GetBallPosition();
            if (Utils.GetDistance(ballPos, GetPosition())  == 1)
                TryToGetBall(stadium);
            else
            {
                DecideAndMove(stadium);
            }
        }
        
        private void TryToGetBall(Stadium stadium)
        {
            Player? playerWithBall = stadium.GetPlayerWithBall();
            if (playerWithBall == null)
                stadium.SetPlayerWithBall(this);
            else
                if (Utils.GetRandomInt(0, 1) == 1)                      // 50% chance of getting the ball
                    stadium.SetPlayerWithBall(this);
        }
        
        private void DecideAndMove(Stadium stadium)
        {
            if (Utils.GetRandomInt(0, 1) == 0)
                MoveToBall(stadium);                         // Tries to move to Ball, if it can't, it moves to the closest enemy
            else
                MoveToClosestEnemy(stadium);
        }

    }

    public class SpecialDefender : Defender
    {
        public SpecialDefender(Team team, string name) : base(team, name)
        {

        }
        public override void ExecuteTurn(Stadium stadium) 
        {
            var enemy = GetClosestEnemy(stadium);
            if (Utils.GetDistance(enemy.GetPosition(), GetPosition()) < 2)
                enemy.TurnsDisabled++;

            base.ExecuteTurn(stadium);
        }
    }

}
