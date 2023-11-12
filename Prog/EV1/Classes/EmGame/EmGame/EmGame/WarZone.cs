using EmGame;
using System;
using System.Diagnostics.Metrics;
using System.Text;
using UDK;
using static UDK.IFont;

namespace Classes
{
    public class WarZone
    {
        public bool is_running = true;
        public Rect rect = new Rect();
        public int
            HX = 1,
            HY,
            OX = 1,
            OY;
        
        public bool HSpawnMaxxed = false;
        public bool OSpawnMaxxed = false;
        private List<Warrior> _warriorList = new List<Warrior>();
        public WarZone()
        {
            rect.x = 0;
            rect.y = 0;
            rect.width = 50;
            rect.height = 50;
            HY = rect.y + 1;
            OY = rect.height - 1;
        }

        public List<Warrior> GetWarriorList()
        {
            return _warriorList;
        }

        public int GetWarriorCount()
        {
            return _warriorList.Count;
        }
            
            public void CreateAllWarriors(int countH, int countO)
        {
                CreateWarrior(countH, TeamType.HUMAN, WeaponType.RANDOM, 0.0, 0.0, 0.0);  // Light skin 255, 182, 193
                CreateWarrior(countO, TeamType.ORC, WeaponType.RANDOM, 0.31, 0.84, 0.41);
        }

        public void CreateWarrior(int count, TeamType team, WeaponType weaponType, double r, double g, double b)
        {
            for (int i = 0; i < count; i++)
            {
                var warrior = new Warrior(team, weaponType, r, g, b, 1, 1);
                SetSpawnPosition(warrior);
                _warriorList.Add(warrior);
            }
        }

        public void RemoveWarrior(int index)
        {
            _warriorList.RemoveAt(index);
        }

        public void SetSpawnPosition(Warrior warr)
        {
            if (warr.GetTeam() == TeamType.HUMAN && HSpawnMaxxed == false)
            {
                warr.SetX(HX);
                warr.SetY(HY);
                HX++;
                DecideNextSpawnPostion(warr.GetTeam());
            }

            if (warr.GetTeam() == TeamType.ORC && OSpawnMaxxed == false)
            {
                warr.SetX(OX);
                warr.SetY(OY);
                OX++;
                DecideNextSpawnPostion(warr.GetTeam());
            }
            }

            public void DecideNextSpawnPostion(TeamType team)
            {
                if (team == TeamType.HUMAN)
                {
                    if (HX > rect.GetWidth() - 2)
                    {
                        HX = 1;
                        HY++;
                        if (HY > rect.height * 2 / 5 - 2)
                            HSpawnMaxxed = true;
                    }
                }
                if (team == TeamType.ORC)
                {
                    if (OX > rect.GetWidth() - 2)
                    {
                        OX = 1;
                        OY--;
                        if (OY < rect.height * 3 / 5 + 2)
                            OSpawnMaxxed = true;
                    }
                }
            }

            public void DrawAll(ICanvas canvas)
        {
            DrawMap(canvas);
            DrawWarriors(canvas);
        }
        private void DrawMap(ICanvas canvas)
        {
            canvas.FillShader.SetColor(1, 1, 1, 1);
            canvas.Camera.SetRectangle(rect.x - 5, rect.y - 5, rect.width + 10, rect.height + 10);
            canvas.DrawRectangle(rect.x, rect.y, rect.width , rect.height);
        }

        private void DrawWarriors(ICanvas canvas)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                Warrior warr = _warriorList[i];
                canvas.FillShader.SetColor(warr.GetR(), warr.GetG(), warr.GetB(), 1);
                canvas.DrawRectangle(warr.GetX(), warr.GetY(), warr.GetWidth() - 0.1, warr.GetHeight() - 0.1);
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
            return  (GetDistance(x, y, warrior.GetX(), warrior.GetY()) <= w.GetWeaponRange() && w.GetTeam() != warrior.GetTeam());
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
                if (IsEnemyInRange(x, y, _warriorList[i]))
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

        public bool IsOccupied(int x, int y)
        {
            for (int i = 0; i <  _warriorList.Count; i++)
            {
                if (_warriorList[i].GetX() == x && _warriorList[i].GetY() == y)
                    return true;
            }
            return false;
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
