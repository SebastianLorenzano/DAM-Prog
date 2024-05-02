namespace Rugby
{
    public delegate void VisitEntity(Entity entity);
    public delegate int SortDelegate(Entity entity1, Entity entity2);
    public class Stadium
    {
        private List<Character> _chars = new();
        private Ball _ball = new();
        private Team[] _teams = new Team[2];
        public bool round_finished = false;

        const int GAME_DURATION = 1000;
        const int MAX_DEMENTORS = 4;
        const int WIDTH = 9;
        const int HEIGHT = 19;
        public int Width => WIDTH;
        public int Height => HEIGHT;
        public int CharCount => _chars.Count;
        public Team? FirstTeam => _teams.Length > 0 ? _teams[0] : null;
        public Team? SecondTeam => _teams.Length > 1 ? _teams[1] : null;
        public Stadium(Team team1, Team team2) 
        {
            if (team1 == null)
                team1 = new Team("Team1", TeamNumber.TEAM1);
            if (team2 == null)
                team2 = new Team("Team2", TeamNumber.TEAM2);
            _teams[0] = team1;
            _teams[1] = team2;
        }
        public Character? GetCharacterAtIndex(int index)
        {
            if (index >= 0 && index < _chars.Count)
                return _chars[index];
            return null;
        }

        public Character? GetCharacterAt(int x, int y)
        {
            foreach (var c in _chars)
                if (c.x == x && c.y == y)
                    return c;
            return null;
        }

        public void SetBallNewPosition(int x, int y)        // This function also takes into account if a player has the ball at the end
        {
                _ball.x = x;
                _ball.y = y;
            if (GetCharacterAt(x, y) is Player player)
                _ball.PlayerWithBall = player;
            else
                _ball.PlayerWithBall = null;
        }

        public Position GetBallPosition()
        {
            return _ball.GetPosition();
        }

        public Player? GetPlayerWithBall()
        {
            return _ball.PlayerWithBall;
        }

        public void SetPlayerWithBall(Player? player)
        {
            _ball.PlayerWithBall = player;
        }

        public void VisitEntities(VisitEntity visit)
        {
            if (visit != null)
                foreach (var c in _chars)
                    visit(c);
        }

        public bool IsPositionAvailable(int x, int y)
        {
            return GetCharacterAt(x, y) == null && !IsOutOfBounds(x, y);
        }

        public bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || x >= WIDTH || y < 0 || y >= HEIGHT;
        }

        public void FillGame()
        {
            FillPlayers();
            FillDementors();
        }

        public void FillDementors()
        {
            for (int i = 0; i < MAX_DEMENTORS; i++)
                _chars.Add(new Dementor());
        }


        public void FillPlayers()
        {
            int playerNum = 0;
            var team1Pos = Team.GetTeam1DefaultPositions();
            var team2Pos = Team.GetTeam2DefaultPositions(HEIGHT);
            FillSpecDefenders(team1Pos, team2Pos, ref playerNum);
            FillDefenders(team1Pos, team2Pos, ref playerNum);
            FillAttackers(team1Pos, team2Pos, ref playerNum);
        }

        public void FillSpecDefenders(Position[] team1Pos, Position[] team2Pos, ref int playerNum)
        {
            for (int i = 0; i < 2; i++)
            {
                _chars.Add(new SpecialDefender(_teams[0], "Player" + playerNum++) { DefaultPosition = team1Pos[i] });;
                _chars.Add(new SpecialDefender(_teams[1], "Player" + playerNum++) { DefaultPosition = team2Pos[i] });
            }

        }

        public void FillDefenders(Position[] team1Pos, Position[] team2Pos, ref int playerNum)
        {
            for (int i = 2; i < 6; i++)
            {
                _chars.Add(new Defender(_teams[0], "Player" + playerNum++) { DefaultPosition = team1Pos[i] });
                _chars.Add(new Defender(_teams[1], "Player" + playerNum++) { DefaultPosition = team2Pos[i] });
            }
        }

        public void FillAttackers(Position[] team1Pos, Position[] team2Pos, ref int playerNum)
        {
            for (int i = 6; i < 10; i++)
            {
                _chars.Add(new Attacker(_teams[0], "Player" + playerNum++) { DefaultPosition = team1Pos[i] });
                _chars.Add(new Attacker(_teams[1], "Player" + playerNum++) { DefaultPosition = team2Pos[i] });
            }
        }

        public void RandomizeTurns()
        {
            throw new NotImplementedException();
        }


        public void StartGame()
        {
            for (int i = 0; i < GAME_DURATION; i++)
                foreach (var c in _chars)
                {
                    if (!round_finished)    // TODO: When ball is out of bounds, round is finished
                        c.ExecuteTurn(this);
                }
                    
        }
    }
}
