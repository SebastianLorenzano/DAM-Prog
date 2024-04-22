namespace Rugby
{
    public class Defender : Player
    {
        public Defender(Team team, string name) : base(team, name)
        {

        }

        public override void ExecuteTurn(Stadium stadium)
        {
            if (HasBall(stadium))
                ExecuteTurnWithBall(stadium);
            else
                ExecuteTurnWithoutBall(stadium);
        }

        private void ExecuteTurnWithBall(Stadium stadium)
        {
            int random = Utils.GetRandomInt(0, 3);
            if (random < 3)
                MoveToRandomPosition(stadium);
            else
                ThrowLongPass(stadium);
        }

        private void ExecuteTurnWithoutBall(Stadium stadium)
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
                MoveToBall(stadium);                                // Tries to move to Ball, if it can't, it moves to the closest enemy
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
            throw new NotImplementedException();
        }
    }

}
