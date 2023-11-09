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
        private List<Weapon>? _weaponList;
        private Rect rect = new Rect();
        private int _health = 20;
        private TeamType _team;
        private double _accuracity;
        private Weapon _weapon;

        public Warrior(TeamType team, WeaponType weapontype, double r, double g, double b)
        {
            rect.r = r;
            _team = team;
            _weapon = new Weapon(weapontype);
        }

        private void SetSpawnPosition()
        {
            if (_team == TeamType.HUMAN)
            {
                rect.x = Utils.GetRandomInt(,1)
            }
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

        public bool IsDead()
        {
            return _health <= 0;
        }
        public Warrior? ExecuteTurn(WarZone warzone)
        {
            var result = warzone.GetEnemiesInRange(GetX(), GetY());
            if (result == null)
            {
                Move(warzone);
                return null;
            }
            Attack(result[0], warzone);
            if (result[0].IsDead())
                return result[0];
            return null;
        }

        public void Attack(Warrior warrior, WarZone warzone)
        {
            warrior._health -= GetWeaponDamage();           
        }

        public void Move(WarZone warzone)
        { 
            double k = Utils.GetRandom();
            double j = Utils.GetRandom();
            if (k > 0.5)
            {
                if (warzone.HitRightWall(this) != true)
                    rect.x += 1;
            }
            else
            {
                if (warzone.HitLeftWall(this) != true)
                    rect.x += -1;
            }
            if (j > 0.5)
            {
                if (warzone.HitTopWall(this) != true)
                    rect.y += 1;
            }
            else
            {
                if (warzone.HitBottomWall(this) != true)
                    rect.y += -1;
            }
        }
        // Preguntarle a javi si combiene en WarZone poner una funcion que cuente donde estan los enemigos para moverse ahi //

    }

    }

