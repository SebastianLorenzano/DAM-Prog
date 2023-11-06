using EmGame;
using Microsoft.VisualBasic;
using System;


namespace Classes
{
    public class Warrior
    {
        private List<Weapon> _weaponList;





        public enum TeamType
        {
            HUMAN,
            DWARF,
            ORC,
            ELF
        }


        private int _x, _y, _health;
        private TeamType _team;
        private double _accuracity;

        public Warrior()
        {
            Weapon weapon0 = new Weapon(WeaponType.FISTS);
            Weapon weapon1 = new Weapon(WeaponType.SWORD);
            Weapon weapon2 = new Weapon(WeaponType.MAZE);
            Weapon weapon3 = new Weapon(WeaponType.SPEAR);
            Weapon weapon4 = new Weapon(WeaponType.ARROW);
            Weapon weapon5 = new Weapon(WeaponType.BOW);
            _weaponList.Add(weapon0);
            _weaponList.Add(weapon1);
            _weaponList.Add(weapon2);
            _weaponList.Add(weapon3);
            _weaponList.Add(weapon4);
            _weaponList.Add(weapon5);
        }


    }
}
