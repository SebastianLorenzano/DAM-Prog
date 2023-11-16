using EmGame;
using FreeTypeSharp.Native;
using Microsoft.VisualBasic;
using System;


namespace Classes
{

    // Que tengan proficiencias las razas con distintas armas, o distintas estrategias
    public enum TeamType
    {
        HUMAN,
        DWARF,
        ORC,
        ELF
    }

    public enum AttackMode
    {
        NORMAL,
        BERSERKER
    }

    public class Warrior : Rect
    {
        private int _health = 20;
        private TeamType _team;
        private Weapon _weapon;
        private AttackMode _mode;

        public Warrior(TeamType team, WeaponType weapontype, double r, double g, double b, int width, int height)
        {
            this.r = r;
            _team = team;
            _weapon = new Weapon(weapontype);
            this.r = r;
            this.g = g;
            this.b = b;
            this.width = width;
            this.height = height;

        }


        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public double GetR()
        {
            return r;
        }

        public double GetG()
        {
            return g;
        }

        public double GetB()
        {
            return b;
        }

        public int GetHealth()
        {
            return _health;
        }

        public TeamType GetTeam()
        {
            return _team;
        }

        public WeaponType GetWeaponType()
        {
            return _weapon.GetWeaponType();
        }

        public double GetWeaponRange()
        {
            return _weapon.GetRange();

        }

        public int GetWeaponDamage()
        {
            return _weapon.GetDamage();
        }

        public int GetWeaponReloadTime()
        {
            return _weapon.GetReloadTime();
        }

        public bool IsDead()
        {
            return _health <= 0;
        }
        public Warrior? ExecuteTurn(WarZone warzone)
        {
            List<Warrior>? result = warzone.GetEnemiesInRange(GetX(), GetY());
            if (result.Count == 0 || result == null)
            {
                Move(warzone);
            }
            else
            {
                Attack(result[0]);
                _weapon.reloadTimeLeft -= 1;
                if (result[0].IsDead())
                    return result[0];
            }
            return null;
        }

        public void Attack(Warrior warrior)
        {
            if (_weapon.reloadTimeLeft == 0)
            {
                warrior._health -= GetWeaponDamage();
                _weapon.reloadTimeLeft = _weapon.GetReloadTime();
            }
        }

        public void MoveTo(Position position, WarZone warzone)
        {
           //  if (x < )            COMPLETAR
        }
        public void Move(WarZone warzone)
        { 
               
            if (_mode == AttackMode.BERSERKER)
            {
                var position = warzone.GetEnemiesCenterPosition(_team);
                // que recorra una lista de posiciones disponibles y que se mueva a aquella que esta a menor distancia del centro // 
                MoveTo(position, warzone);


            }
            
            
       
            




          /*  
                if (WarZone.GetDistance(x, y, x, warzone.rect.height / 2) != 0)
                {
                    if (y < warzone.rect.height / 2 && !warzone.IsOccupied(x, y + 1))
                        y += 1;
                    else if (y > warzone.rect.height / 2 && !warzone.IsOccupied(x, y - 1))
                        y += -1;
                }
                if (WarZone.GetDistance(x, y, x, warzone.rect.height / 2) == 0)
                {
                    if (x < warzone.rect.width / 2 && !warzone.IsOccupied(x + 1, y))
                        x += 1;
                    else if (x > warzone.rect.width / 2 && !warzone.IsOccupied(x - 1, y))
                        x += -1;
                }
            
       */
        }


    }
    // Preguntarle a javi si combiene en WarZone poner una funcion que cuente donde estan los enemigos para moverse ahi //

}



