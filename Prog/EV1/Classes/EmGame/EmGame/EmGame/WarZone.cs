using EmGame;
using System;

namespace Classes
{
    public class WarZone
    {
        private int x, y, width, height;
        private List<Warrior> _warriorList = new List<Warrior>();

        public WarZone()
        {


        }

        public List<Warrior> GetWarriorList()
        {
            return _warriorList;
        }

        public void CreateWarriors(int count, TeamType team, WeaponType weaponType)
        {
            for (int i= 0; i < count; i++)
            {
                var warrior = new Warrior(team, weaponType);
                _warriorList.Add(warrior);
            }

        }

        public void RemoveWarrior(int index)
        {
            _warriorList.RemoveAt(index);
        }

        public void ExecuteRound(WarZone warzone)
        {

        }

        public Warrior? GetWarriorAt(int x, int y)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                if (_warriorList[i].GetX() == x && _warriorList[i].GetY() == y)
                    return _warriorList[i];
            }
            return null;
        }

        public Warrior? GetWarriorAt(int index)
        {
            if (index < 0 || index >= _warriorList.Count)
                return null;
            return _warriorList[index];
        }

        public int GetEnemiesInRange(int x, int y, TeamType team)
        {
            return 0;
        }

        public Warrior? GetWarriorsInRange(int x, int y, TeamType team)
        {
            return null;
        }

        public List<Warrior> GetWarriorsInside(int x, int y, int width, int height)
        {
            return _warriorList;
        }

        public List<Warrior> GetWarriorsSortedByDistance(int x, int y)
        {
            return _warriorList;
        }

        public static double GetDistance(Warrior w1, Warrior w2)
        {
            return GetDistance(w1.GetX(), w1.GetY(), w2.GetX(), w2.GetY());

        }

        public static double GetDistance(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}    
