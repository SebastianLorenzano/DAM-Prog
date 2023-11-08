using System;
using System.Security.Cryptography;

namespace EmGame
{
    public enum WeaponType
    {
        FISTS,
        SWORD,
        MAZE,
        SPEAR,
        ARROW,
        BOW,
        RANDOM
    }
    public class Weapon
    {
        private WeaponType _weaponType;
        public Weapon(WeaponType type)   // Weapon pepe = new Weapon(WeaponType.SWORD)
        {
            _weaponType = type;
        }


        public WeaponType GetWeaponType()
        { 
            return _weaponType; 
        }

        public int GetDamage()
        {
            if (_weaponType == WeaponType.SWORD)
                return 3;
            if (_weaponType == WeaponType.MAZE)
                return 5;
            if (_weaponType == WeaponType.SPEAR)    
                return 2;
            if (_weaponType == WeaponType.ARROW)//eL DAÑO DE LAS FLECHAS QUE PASA PISHA?
                return 2;
            if (_weaponType == WeaponType.BOW)
                return 3;
            return 1;
        }

        public int GetReloadTime()
        {
            if (_weaponType == WeaponType.MAZE)
                return 2;
            if (_weaponType == WeaponType.SPEAR)
                return 2;
            if (_weaponType == WeaponType.ARROW)
                return 1;
            if (_weaponType == WeaponType.BOW)
                return 3;
            return 1;
        }

        public double GetRange()
        {
            if (_weaponType == WeaponType.SPEAR)
                return 2.5;
            if (_weaponType == WeaponType.BOW)
                return 3.5;
            return 1.5;
        }

        public static WeaponType GetRandomWeapon()
        {
            Random r = new Random();
            var r1 = r.Next(0, 5);
            if (r1 == 1)
                return WeaponType.SWORD;
            if (r1 == 2)
                return WeaponType.MAZE;
            if (r1 == 3)
                return WeaponType.SPEAR;
            if (r1 == 4)
                return WeaponType.BOW;
            return WeaponType.FISTS;
        }

    }
}
