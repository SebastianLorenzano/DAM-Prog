using EmGame;
using System;
using System.Text;

namespace Classes
{
    public class WarZone
    {
        private int _x, _y, _width, _height;
        private List<Warrior> _warriorList = new List<Warrior>();

        public WarZone()
        {
            

        }

        public int GetX()
        {
            return _x; 
        }

        public int GetY()
        {
            return _y; 
        }

        public int GetWidth() 
        { 
            return _width; 
        }

        public int GetHeight()
        { 
            return _height; 
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

        public bool IsEnemyInRange(int x, int y, Warrior warrior)
        {
            var w = GetWarriorAt(x, y);
            if (w == null)
                return false;
            return  (GetDistance(w.GetX(), w.GetY(), x, y) <= warrior.GetWeaponRange() && w.GetTeam() != warrior.GetTeam());
        }

        public int GetEnemiesInRange(int x, int y)                    
        {
            int result = 0;
            if (GetWarriorAt(x, y) == null)
                return result;
            for (var i = 0; i < _warriorList.Count; i++)
            {
                var warrior = _warriorList[i];
                if (IsEnemyInRange(x, y, warrior))
                    result++;
            }
            return result;
        }

        public Warrior? GetEnemyInRange(int x, int y)
        {
            for (var i = 0; i < _warriorList.Count; i++)
            {
                if (IsEnemyInRange(x, y, _warriorList[i]))
                    return _warriorList[i];
            }
            return null;
        }

        //public List<Warrior> GetWarriorsInside(int x, int y, int width, int height)           // Esto es para hacer un daño en area tipo un Fireball //
        //{
        //    List<Warrior> lista = new List<Warrior>();
        //    for (int i = 0; i < _warriorList.Count; i++)
        //        if (IsEnemyInRange(x, y, _warriorList[i]))
        //            lista.Add(_warriorList[i]);
        //    return lista;
        //}

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
