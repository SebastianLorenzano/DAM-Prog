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
        private List<Weapon> _weaponList;
        private int _x, _y, _health = 20;
        private TeamType _team;
        private double _accuracity;
        private Weapon _weapon;


        public Warrior(TeamType team, WeaponType weapontype)
        {
            _team = team;
            _weapon = new Weapon(weapontype);
            Weapon weapon1 = new Weapon(WeaponType.SWORD);
            Weapon weapon2 = new Weapon(WeaponType.MAZE);
            Weapon weapon3 = new Weapon(WeaponType.SPEAR);
            Weapon weapon4 = new Weapon(WeaponType.ARROW);
            Weapon weapon5 = new Weapon(WeaponType.BOW);
            _weaponList.Add(new Weapon(WeaponType.FISTS));
            _weaponList.Add(weapon1);
            _weaponList.Add(weapon2);
            _weaponList.Add(weapon3);
            _weaponList.Add(weapon4);
            _weaponList.Add(weapon5);
        }

        public int GetX()
        { 
            return _x; 
        }

        public int GetY()
        { 
            return _y; 
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

        public void ExecuteTurn()
        {

        }

        public void Attack()
        {

        }

        public void Move()
        {
            // Preguntarle a javi si combiene en WarZone poner una funcion que cuente donde estan los enemigos para moverse ahi //

        }



    }
}
