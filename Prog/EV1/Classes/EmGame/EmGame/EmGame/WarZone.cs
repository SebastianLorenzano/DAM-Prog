using EmGame;
using UDK;
using static UDK.IFont;

namespace Classes
{

    public class Position
    {
        public int x, y;
        public Position(int x, int y)
            {
            this.x = x;
            this.y = y;
            }
    }

    public class WarZone : Rect
    {
        public bool is_running = true;          // Estas son las coordenadas de spawn de los 
       private int                              // tipos, una vez llega al maximo suma la Y y 
            HX = 1,                             // reestablece la X al minimo.
            HY,
            OX = 1,
            OY; // Javi: No entiendo la funcionalidad de estos atributos. Por que no usas Position? Los nombres son muy malos
        private bool HSpawnMaxxed = false;
        private bool OSpawnMaxxed = false;
        private List<Warrior> _warriorList = new List<Warrior>();
        

        public WarZone()
        {
            // Javi: No deberías inventarte estos valores
            _x = 0;
            _y = 0;
            _width = 125;
           _height = 125;
            HY = _y + 1;
            OY = _height - 1;
        }

        public int GetWarriorCount()
        {
            return _warriorList.Count;
        }

        public void CreateAllWarriors(int countH, int countO)
        {
            CreateWarriors(countH, TeamType.HUMAN, WeaponType.RANDOM, AttackMode.RANDOM);  // Light skin 255, 182, 193
            CreateWarriors(countO, TeamType.ORC, WeaponType.RANDOM, AttackMode.RANDOM);
        }

        public void CreateWarriors(int count, TeamType team, WeaponType weaponType, AttackMode attackMode)
        {
            for (int i = 0; i < count; i++)
            {
                var warrior = new Warrior(team, weaponType, AttackMode.RANDOM, 1, 1);
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
                if (HX > GetWidth() - 2)
                {
                    HX = 1;
                    HY++;
                    if (HY > _height * 2 / 5 - 2)
                        HSpawnMaxxed = true;
                }
            }
            if (team == TeamType.ORC)
            {
                if (OX > GetWidth() - 2)
                {
                    OX = 1;
                    OY--;
                    if (OY < _height * 3 / 5 + 2)
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
            canvas.Camera.SetRectangle(_x - 5, _y - 5, _width + 10, _height + 10);
            canvas.DrawRectangle(_x, _y, _width, _height);
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
                // Javi: Mejor devuelve un enum
                turn = _warriorList[i].ExecuteTurn(this);
                if (turn != null)
                {
                    // Javi: el warrior index es i
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

        public int GetWarriorIndex(Warrior?  warrior)
        {
            for (int i = 0; i < _warriorList.Count; i++)
            {
                if (_warriorList[i].GetX() == warrior.GetX() && _warriorList[i].GetY() == warrior.GetY())
                    return i;
            }
            return -1;
        }

        // Javi: Yo no hubiese hecho esta función así, ..., y no sé si aquí
        public bool IsEnemyInRange(int x, int y, Warrior warrior)
        {
            var w = GetWarriorAt(x, y);
            if (w == null)
                return false;
            return (GetDistance(x, y, warrior.GetX(), warrior.GetY()) <= w.GetWeaponRange() && w.GetTeam() != warrior.GetTeam());
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

        // Javi: Esta función no puede devolver null. Por favor, me recuerdas esto en clase?
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


        public List<Warrior> GetWarriorsSortedByDistance(int x, int y, List<Warrior> lista = null)
        {
            if (lista == null)
                lista = _warriorList;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 1; j < lista.Count; j++)
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

        // Javi: Tal y como está, ..., yo hubiese sacado esto fuera
        public List<Position> GetPositionsSortedByDistance(int x, int y, List<Position>? lista = null)
        {
            if (lista == null)
                return lista;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 1; j < lista.Count; j++)
                {
                    var d1 = GetDistance(x, y, lista[i].x, lista[i].y);
                    var d2 = GetDistance(x, y, lista[j].x, lista[j].y);
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
            for (int i = 0; i < _warriorList.Count; i++)
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

        // Javi: Muy bien!!
        public Position GetEnemiesCenterPosition(TeamType team)
        {
            var wlist = _warriorList;
            int countX = 0, x = 0, y = 0, countY = 0;
            for (int i = 0; i < _warriorList.Count;i++)
            {
                if (_warriorList[i].GetTeam() != team)
                {
                    x += wlist[i].GetX();
                    y += wlist[i].GetY();
                    countX++;
                    countY++;
                }
            }
            if (countX == 0 || countY == 0)
                return new Position(0, 0);
            return new Position(x / countX, y / countY);
        }

        // Javi: Función demasiado larga, sepárala en varias
        public Position GetBestPosition(Position goToPosition, Position warPosition, Position toAvoidPosition = null)
        {
            var result = new Position(warPosition.x, warPosition.y);
            if (toAvoidPosition == null)
            {
                for (int y = warPosition.y - 1; y <= warPosition.y + 1; y++)
                {
                    for (int x = warPosition.x - 1; x <= warPosition.x + 1; x++)
                    {
                        if (GetDistance(result.x, result.y, goToPosition.x, goToPosition.y) > GetDistance(x, y, goToPosition.x, goToPosition.y) &&
                            GetWarriorAt(x, y) == null && x > _x && x < _width && y > _y && _y < _height)
                        {
                            result.x = x;  // Un -1 aca  (en x) soluciona el que se junten al lado derecho, pero al mismo tiempo produce cambios raros. Merece la pena verlo igual, aunque prefiero dejarlo asi.
                            result.y = y;       // Es lo unico que vi que puede solucionarlo, nose exactamente porque se comporta asi
                        }
                    }
                }
            }
            else          
            {
                List<Position> list = new List<Position>();
                for (int y = warPosition.y - 1; y <= warPosition.y + 1; y++)
                {
                    for (int x = warPosition.x - 1; x <= warPosition.x + 1; x++)
                    {
                        if (GetDistance(result.x, result.y, goToPosition.x, goToPosition.y) > GetDistance(x, y, goToPosition.x, goToPosition.y) &&
                            GetWarriorAt(x, y) == null && x > _x && x < _width && y > _y && _y < _height)
                        {
                            list.Add(new Position(x, y));
                        }
                    }
                }
                list = GetPositionsSortedByDistance(goToPosition.x, goToPosition.y, list);
                if (list.Count > 0)
                    result = list[0];
                for (int i =  1; i < list.Count - 1; i++) 
                {
                    var distanceResult = GetDistance(result.x, result.y, toAvoidPosition.x, toAvoidPosition.y);
                    var distanceI = GetDistance(list[i].x, list[i].y, toAvoidPosition.x, toAvoidPosition.y);
                    if (distanceResult < distanceI && distanceResult < 45)  // el 45 es la distancia en la que empiezan (ademas de moverse hacia los arqueros) a intentar alejarse del resto
                        result = list[i];
                }
            }
            return result;
        }

        public Position GetClosestEnemyPosition(TeamType team, Position warrPosition) //Pense detenidamente durante 3 segundos _y concurri que no voy a transformar todo el codigo a position. No.
        {
            var wlist = _warriorList;
            List<Warrior> list = new List<Warrior> ();
            for (int i = 0; i < wlist.Count; i++)
            {
                if (_warriorList[i].GetTeam() != team)
                    list.Add(_warriorList[i]);
            }
            if (list.Count > 0)
            {
                list = GetWarriorsSortedByDistance(warrPosition.x, warrPosition.y, list);
                // Javi: ciudado, la lista puede contener 0 elementos
                return new Position(list[0].GetX(), list[0].GetY());
            }
            return new Position(0, 0);
        }

        public Position GetClosestEnemyPositionWithWeaponType(WeaponType weaponType, TeamType team, Position warrPosition) //Pense detenidamente durante 3 segundos _y concurri que no voy a transformar todo el codigo a position. No.
        {
            List<Warrior> list = new List<Warrior>();
            var wlist = _warriorList;
            for (int i = 0; i < _warriorList.Count; i++)
            {
                if (wlist[i].GetTeam() != team && wlist[i].GetWeaponType() == weaponType)
                    list.Add(_warriorList[i]);
            }
            if (list.Count > 0)
            {
                list = GetWarriorsSortedByDistance(warrPosition.x, warrPosition.y, list);
                return new Position(list[0].GetX(), list[0].GetY());
            }
            return new Position(0, 0);
        }

        public Position GetEnemiesCenterPositionWithWeaponType(WeaponType weaponType, TeamType team, Position warrPosition) // Calcula la posicion central de todos los tipos de enemigos exceptuando el tipo que tiene el arma que pasa
        {
            {
                var wlist = _warriorList;
                List<Warrior> list = new List<Warrior>();
                for (int i = 0; i < _warriorList.Count; i++)
                {
                    if (wlist[i].GetTeam() != team && wlist[i].GetWeaponType() != weaponType)
                        list.Add(_warriorList[i]);
                }
                if (list.Count > 0)
                {
                    list = GetWarriorsSortedByDistance(warrPosition.x, warrPosition.y, list);
                    return new Position(list[0].GetX(), list[0].GetY());
                }
                return new Position(0, 0);
            }
        }
    }
}    
