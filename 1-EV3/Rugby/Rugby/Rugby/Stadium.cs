using System.Security.Cryptography.X509Certificates;

namespace Rugby
{
    public class Stadium
    {
        private int _width = 10, _height = 20;
        private List<Character> _chars = new();
        private Ball _ball = new();
        private Team[] _teams = new Team[2];

        const int GAME_DURATION = 1000;

        public int Width 
        { 
            get => _width; 
            set => SetWidth(value); 
        }
        public int Height
        {
            get => _height; 
            set => SetHeight(value); 
        }
        public int CharCount => _chars.Count;

        public Stadium(int width, int height, Team team1, Team team2) 
        {
            SetWidth(width);
            SetHeight(height);
            if (team1 == null)
                team1 = new Team("Team1");
            if (team2 == null)
                team2 = new Team("Team2");
            _teams[0] = team1;
            _teams[1] = team2;
        }

        public void SetWidth(int width)
        {
            if (width > 0 && width < 100)
                _width = width;
        }
        public void SetHeight(int height)
        {
            if (height > 0 && height < 100)
                _height = height;
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

        public Player? GetPlayerWhoHasBall()
        {
            return _ball.IsHolding;
        }

        public void FillPlayers()
        {
            var team1Pos = Team.GetTeam1DefaultPositions();
            var team2Pos = Team.GetTeam2DefaultPositions();
            FillSpecDefenders(team1Pos, team2Pos);
            FillDefenders(team1Pos, team2Pos);
            FillAttackers(team1Pos, team2Pos);
        }

        public void FillSpecDefenders((int x, int y)[] team1Pos, (int x, int y)[] team2Pos)
        {
            for (int i = 0; i < 2; i++)
            {
                _chars.Add(new SpecialDefender(_teams[0]) { DefaultPosition = team1Pos[i] });
                _chars.Add(new SpecialDefender(_teams[1]) { DefaultPosition = team2Pos[i] });
            }

        }

        public void FillDefenders((int x, int y)[] team1Pos, (int x, int y)[] team2Pos)
        {
            for (int i = 2; i < 6; i++)
            {
                _chars.Add(new Defender(_teams[0]) { DefaultPosition = team1Pos[i] });
                _chars.Add(new Defender(_teams[1]) { DefaultPosition = team2Pos[i] });
            }
        }

        public void FillAttackers((int x, int y)[] team1Pos, (int x, int y)[] team2Pos)
        {
            for (int i = 6; i < 10; i++)
            {
                _chars.Add(new Attacker(_teams[0]) { DefaultPosition = team1Pos[i] });
                _chars.Add(new Attacker(_teams[1]) { DefaultPosition = team2Pos[i] });
            }
        }


        public void FillGame()
        {
            throw new NotImplementedException(); //TODO: SHOULD ADD PLAYERS AND BALL
        } 


        public void RandomizeTurns()
        {
            throw new NotImplementedException();
        }


        public void StartGame()
        {
            for (int i = 0; i < GAME_DURATION; i++)
                foreach (var c in _chars)
                    c.ExecuteTurn();
        }
    }
}
