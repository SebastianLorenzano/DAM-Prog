namespace Domino
{
    public class PlayersList
    {
        private List<Player> _players = new();

        public int Count => _players.Count;
        public Player? First => Count > 0 ? _players[0] : null;
        public Player? Last => Count > 0 ? _players[Count - 1] : null;

        public Player? this[int index]
        {
            get => _players[index];
            set => _players[index] = value;
        }

        public PlayersList()
        {

        }

        public PlayersList(List<Player> players)
        {
            _players = players.ToList();
        }

        /* VER SI SE PUEDE HACER ESTO        
         
         //TODO 
        public void Foreach()
        {
            base.Foreach();
        }

        */

        public void AddPlayer(Player player)
        {
            if (player != null || !_players.Contains(player))
                _players.Add(player);
        }

        public void RemovePlayerAt(int index)
        {
            if (index < 0 || index >= _players.Count)
                return;
            _players.RemoveAt(index);
        }

        public Player? GetPlayerAt(int index)
        {
            if (index >= 0 && index < _players.Count)
                return _players[index];
            return null;
        }

        public bool ContainsPlayer(Player player)
        {
            return IndexOfPlayer(player) >= 0;
        }

        public int IndexOfPlayer(Player player)
        {
            if (player == null)
                return -1;
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i] == player)
                    return i;
            }
            return -1;
        }

        public PlayersList Clone()
        {
            return new PlayersList(_players);
        }

        public List<Player> ToList()
        {
            return new List<Player>(_players);

        }


    }
}
