using EmGame;
using System;
using System.Text;
using UDK;
using static UDK.IFont;

namespace Classes
{
    public class WarZone
    {
        public bool is_running = true;
        public Rect rect = new Rect();
 
        private List<Warrior> _warriorList = new List<Warrior>();
        public WarZone()
        {
            rect.x = 0;
            rect.y = 0;
            rect.width = 50;
            rect.height = 50;
        }

        public List<Warrior> GetWarriorList()
        {
            return _warriorList;
        }

        public int GetWarriorCount()
        {
            return _warriorList.Count;
        }

        public void SetSpawnPositions()
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                _warriorList[i].SetSpawnPosition(this);
            }
            
        }
        public void CreateAllWarriors(int countH, int countO)
        {
            for (int i = 0; i < countH; i++)
                CreateWarrior(TeamType.HUMAN, WeaponType.RANDOM, 0.0, 0.0, 0.0);  // Light skin 255, 182, 193
            for (int i = 0; i < countO; i++)
                CreateWarrior(TeamType.ORC, WeaponType.RANDOM, 31, 84, 41);

        }
        public void CreateWarrior(TeamType team, WeaponType weaponType, double r, double g, double b)
        {
            var warrior = new Warrior(team, weaponType, r, g, b, this);
            _warriorList.Add(warrior);
        }

        public void RemoveWarrior(int index)
        {
            _warriorList.RemoveAt(index);
        }

        public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawWarriors(canvas);
        }
        private void DrawMap(ICanvas canvas)
        {
            canvas.FillShader.SetColor(1, 1, 1, 1);
            canvas.Camera.SetRectangle(rect.x, rect.y, rect.width, rect.height);
            canvas.DrawRectangle(rect.x, rect.y, rect.width, rect.height);
        }

        private void DrawWarriors(ICanvas canvas)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                Warrior wr = _warriorList[i];
                canvas.FillShader.SetColor(wr.GetR(), wr.GetG(), wr.GetB(), 1);
                canvas.DrawRectangle(wr.GetX(), wr.GetY(), wr.GetWidth(), wr.GetHeight());
            }
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
            if (ch.GetX() > rect.GetX() + rect.GetWidth() - ch.GetWidth())
                return true;
            return false;
        }
        public bool HitTopWall(Warrior ch)
        {
            if (ch.GetY() > rect.GetY() + rect.GetHeight() - ch.GetHeight())
                return true;
            return false;
        }
        public bool HitBottomWall(Warrior ch)
        {
            if (ch.GetY() < rect.GetY())
                return true;
            return false;
        }

        public bool IsTeamRemaining(TeamType team)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                if (_warriorList[i].GetTeam() == team)
                    return true;
            }
            return false;
        }
        public bool AreAllTeamsRemaining()
        {
            return IsTeamRemaining(TeamType.HUMAN) && IsTeamRemaining(TeamType.ORC);
                
        }
    }
}    
