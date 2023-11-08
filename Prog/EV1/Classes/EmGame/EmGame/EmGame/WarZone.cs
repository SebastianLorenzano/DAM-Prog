using EmGame;
using System;
using System.Text;
using static UDK.IFont;

namespace Classes
{
    public class WarZone
    {
        private Rect rect = new Rect();
 
        private List<Warrior> _warriorList = new List<Warrior>();

        public WarZone()
        {
            rect.width = 50;
            rect.height = 50;
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

        public void ExecuteRound()
        {
            Warrior? turn;
            for (int i = 0; i < _warriorList.Count; i++)
            {
                turn = _warriorList[i].ExecuteTurn(this);
                if (turn != null)
                {
                    RemoveWarrior(GetWarriorIndex(turn));
                    i--;
                }
            }  
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

        public int GetWarriorIndex(Warrior warrior)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                if (_warriorList[i].GetX() == warrior.GetX() && _warriorList[i].GetY() == warrior.GetY()) 
                    return i;
            }
            return -1;
        }

        public bool IsEnemyInRange(int x, int y, Warrior warrior)
        {
            var w = GetWarriorAt(x, y);
            if (w == null)
                return false;
            return  (GetDistance(w.GetX(), w.GetY(), x, y) <= warrior.GetWeaponRange() && w.GetTeam() != warrior.GetTeam());
        }

        public int GetNumEnemiesInRange(int x, int y)                    
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

        public List<Warrior>? GetEnemiesInRange(int x, int y)
        {
            List<Warrior>? result = new List<Warrior>();
            for (var i = 0; i < _warriorList.Count; i++)
            {
                var warrior = _warriorList[i];

                if (IsEnemyInRange(x, y, warrior))
                    result.Add(_warriorList[i]);
            }
            result = GetWarriorsSortedByDistance(x, y, result);
            return result;
        }

        //public List<Warrior> GetWarriorsInside(int x, int y, int width, int height)           // Esto es para hacer un daño en area tipo un Fireball //
        //{
        //    List<Warrior> lista = new List<Warrior>();
        //    for (int i = 0; i < _warriorList.Count; i++)
        //        if (IsEnemyInRange(x, y, _warriorList[i]))
        //            lista.Add(_warriorList[i]);
        //    return lista;
        //}

        public List<Warrior> GetWarriorsSortedByDistance(int x, int y, List<Warrior>? lista)
        {
            if (lista == null)
                lista = _warriorList;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j= 1; j < lista.Count; j++)
                {
                    var d1 = GetDistance(x, y, lista[i].GetX(), lista[i].GetY());
                    var d2 = GetDistance(x, y, lista[j].GetX(), lista[j].GetY());
                    if (d1 > d2)
                    {
                        var aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
                }
            }
            return lista;
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

        public bool HitLeftWall(Warrior ch)
        {
            if (ch.GetX() < rect.GetX())
                return true;
            return false;
        }
        public bool HitRightWall(Warrior ch)
        {
            if (ch.GetX() > rect.GetX() + rect.GetWidth() - ch.GetRectWidth())
                return true;
            return false;
        }
        public bool HitTopWall(Warrior ch)
        {
            if (ch.GetY() > rect.GetY() + rect.GetHeight() - ch.GetRectHeight())
                return true;
            return false;
        }
        public bool HitBottomWall(Warrior ch)
        {
            if (ch.GetY() < rect.GetY())
                return true;
            return false;
        }
    }
}    
