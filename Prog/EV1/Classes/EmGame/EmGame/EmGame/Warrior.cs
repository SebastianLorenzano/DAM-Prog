using EmGame;
using Microsoft.VisualBasic;
using System;


namespace Classes
{
    public enum TeamType
    {
        HUMAN,
        DWARF,
        ORC,
        ELF
    }

    public class Warrior
    {
        private Rect rect = new Rect();
        private int _health = 20;
        private TeamType _team;
        private Weapon _weapon;

        public Warrior(TeamType team, WeaponType weapontype, double r, double g, double b, int width, int height)
        {
            rect.r = r;
            _team = team;
            _weapon = new Weapon(weapontype);
            rect.r = r;
            rect.g = g;
            rect.b = b;
            rect.width = width;
            rect.height = height;

        }


        public int GetX()
        {
            return rect.x;
        }

        public int GetY()
        {
            return rect.y;
        }

        public int GetWidth()
        {
            return rect.GetWidth();
        }

        public int GetHeight()
        {
            return rect.GetHeight();
        }

        public void SetX(int x)
        {
            rect.x = x;
        }

        public void SetY(int y)
        {
            rect.y = y;
        }

        public void SetWidth(int width)
        {
            rect.width = width;
        }

        public void SetHeight(int height)
        {
            rect.height = height;
        }

        public double GetR()
        {
            return rect.r;
        }

        public double GetG()
        {
            return rect.g;
        }

        public double GetB()
        {
            return rect.b;
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
                return null;
            }
            Attack(result[0]);
            _weapon.reloadTimeLeft -= 1;
            if (result[0].IsDead())
                return result[0];
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

        public void Move(WarZone warzone)
        { 
                if (WarZone.GetDistance(rect.x, rect.y, rect.x, warzone.rect.height / 2) != 0)
                {
                    if (rect.y < warzone.rect.height / 2 && !warzone.IsOccupied(rect.x, rect.y + 1))
                        rect.y += 1;
                    else if (rect.y > warzone.rect.height / 2 && !warzone.IsOccupied(rect.x, rect.y - 1))
                        rect.y += -1;
                }
                if (WarZone.GetDistance(rect.x, rect.y, rect.x, warzone.rect.height / 2) == 0)
                {
                    if (rect.x < warzone.rect.width / 2 && !warzone.IsOccupied(rect.x + 1, rect.y))
                        rect.x += 1;
                    else if (rect.x > warzone.rect.width / 2 && !warzone.IsOccupied(rect.x - 1, rect.y))
                        rect.x += -1;
                
                }
            }
    
        }
        // Preguntarle a javi si combiene en WarZone poner una funcion que cuente donde estan los enemigos para moverse ahi //

    }



