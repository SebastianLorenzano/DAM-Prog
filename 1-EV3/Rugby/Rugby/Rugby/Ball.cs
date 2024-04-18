namespace Rugby
{
    public class Ball
    {
        public int x, y;

        public Player? PlayerWithBall { get; set;}


        public bool IsOutOfBonds(Stadium stadium)
        {
            return x < 0 || x >= stadium.Width || y < 0 || y >= stadium.Height;
        }

        public void MoveToStartingPosition(Stadium stadium)
        {
            int newX = Utils.GetRandomInt(0, stadium.Width);
            int newY = Utils.GetRandomInt(0, stadium.Height);
            var entity = stadium.GetCharacterAt(newX, newY);
            if (entity != null && entity is Player)
                PlayerWithBall = (Player)entity;
            else
                PlayerWithBall = null;
        }
    }
}
