namespace Rugby
{
    public abstract class Player : Character
    {
        public string Name { get; init; }
        protected Team _team;
        public Team Team => _team;
        public (int, int) DefaultPosition { get; init; }


        public Player(Team team, string name = "Player")
        {
            Name = name;
            if (team == null)
                throw new Exception("Team is null");
            _team = team;

        }

        public bool IsTeammate(Player player)
        {
            return IsTeammate(this, player);
        }

        public static bool IsTeammate(Player player1, Player player2)
        {
            return player1.Team == player2.Team && player1 != player2;
        }
        
        public List<Player> GetTeammates(Stadium stadium)
        {
            return GetTeammates(this, stadium);
        }

        public static List<Player> GetTeammates(Player player, Stadium stadium)
        {
            List<Player> result = new();
            stadium.VisitEntities((entity) =>
            {
                if (entity is Player p && IsTeammate(p, player))
                {
                    result.Add(p);
                }
            });
            return result;

        }

        public List<Player> GetTeammatesOnDistance(Stadium stadium, int maxRange, int minRange = 0)
        {
            return GetTeammatesOnRange(stadium, this, maxRange);
        }

        public static List<Player> GetTeammatesOnRange(Stadium stadium, Player player, int maxRange, int minRange = 0)
        {                                                                           // maxRange = max distance between players
            List<Player> result = new();                                            // minRange = min distance between players, default = 0
            stadium.VisitEntities((entity) =>
            {
                if (entity is Player p && IsTeammate(p, player))
                {
                    int distance = Utils.GetDistance(p, player);
                    if (minRange <= distance && distance <= maxRange)
                        result.Add(p);
                }
            });
            return result;
        }


        public List<Player> GetTeammatesOnPointLine(Stadium stadium)
        {
            return GetTeammatesOnPointLine(this, stadium);
        }

        public static List<Player> GetTeammatesOnPointLine(Player player, Stadium stadium)
        {
            List<Player> result = new();
            stadium.VisitEntities((entity) =>
            {
                if (entity is Player p && IsTeammate(p, player))
                {
                    int y;
                    if (player.Team == stadium.FirstTeam)
                        y = 0;
                    else
                        y = 9;
                    if (Math.Abs(p.y - y) <= 2)
                        result.Add(p);
                }
            });
            return result;
        }

        public void MoveToRandomPosition(Stadium stadium)
        {
            int x = Utils.GetRandomInt(-1, 1);
            int y = Utils.GetRandomInt(-1, 1);
            if (!MoveTo(x, y, stadium))
                ThrowLongPass(stadium);
        }

        public void MoveToStartingPostion()
        {
            MoveToStartingPosition(this);
        }

        private bool MoveTo(int x, int y, Stadium stadium)
        {
            int newX = this.x + x;
            int newY = this.y + y;
            if (stadium.GetCharacterAt(newX, newY) == null)
            {
                this.x = newX;
                this.y = newY;
                return true;
            }
            return false;

        }

        public static void MoveToStartingPosition(Player player)
        {
            if (player.DefaultPosition == (0, 0))
                throw new Exception("Default position is not set");
            player.x = player.DefaultPosition.Item1;
            player.y = player.DefaultPosition.Item2;
        }

        public void ThrowShortPass(Stadium stadium)
        {
            if (stadium.GetPlayerWithBall() != this)
                return;
            List<Player> teammates = GetTeammatesOnDistance(stadium, 2);
            if (teammates.Count == 0)
                ThrowLongPass(stadium);
            else
            {
                var player = teammates[Utils.GetRandomInt(0, teammates.Count - 1)];
                if (Utils.GetRandomInt(0, 4) == 0)      // 80% chance to succeed
                {
                    FailThrow(stadium, player);
                    return;
                }
                stadium.SetPlayerWithBall(player);
            }


        }

        public void ThrowLongPass(Stadium stadium)
        {
            if (stadium.GetPlayerWithBall() != this)
                return;
            List<Player> teammates = GetTeammatesOnDistance(stadium, 5);
            if (teammates.Count != 0)
            {
                var player = teammates[Utils.GetRandomInt(0, teammates.Count - 1)];
                if (Utils.GetRandomInt(0, 4) != 0)      // 20% chance to succeed
                {
                    FailThrow(stadium, player);
                    return;
                }
                stadium.SetPlayerWithBall(player);
            }

        }

        private void FailThrow(Stadium stadium, Player objective)   // Ball is thrown to a random position near the objective
        {
            while (true)
            {
                int NewX = Utils.GetRandomInt(-2, 2) + objective.x;
                int NewY = Utils.GetRandomInt(-2, 2) + objective.y;
                if (!stadium.IsOutOfBounds(NewX, NewY))
                    stadium.SetBallNewPosition(NewX, NewY);         
            }


        }
    }
}
