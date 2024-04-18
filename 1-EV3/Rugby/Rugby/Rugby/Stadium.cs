using System.Security.Cryptography.X509Certificates;

namespace Rugby
{
    public class Stadium
    {
        private int _width = 10, _height = 20;
        private List<Character> _chars = new();
        private Ball _ball;
        private List<Team> _teams = new();

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

        public Stadium(int width, int height) 
        {
            SetWidth(width);
            SetHeight(height);
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

        public Player? GetPlayerWhoWithBall()
        {
            return _ball.IsHolding;
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
            for (int i = 0; i < 1000; i++)
                foreach (var c in _chars)
                    c.ExecuteTurn();
        }
    }
}
