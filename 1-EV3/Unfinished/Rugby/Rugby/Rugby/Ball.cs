namespace Rugby
{
    public class Ball : Entity
    {
        private Player? _playerWithBall;
        public Player? PlayerWithBall { get => _playerWithBall; set => SetPlayerWithBall(value); }


        public override Position GetPosition()
        {
            if (PlayerWithBall != null)
                return new Position() { x = PlayerWithBall.x, y = PlayerWithBall.y };
            return new Position() { x = x, y = y };
        }

        public void SetPlayerWithBall(Player player)
        {
            if (player != null)
            {
                x = player.x;
                y = player.y;
            }
            PlayerWithBall = player;
        }

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
