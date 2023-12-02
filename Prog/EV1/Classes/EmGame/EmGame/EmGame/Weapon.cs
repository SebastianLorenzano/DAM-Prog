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
        public int reloadTimeLeft = 0;
        public Weapon(WeaponType type)   
        {
            if (type == WeaponType.RANDOM)
                _weaponType = GetRandomWeapon();
            else
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
            if (_weaponType == WeaponType.ARROW)
                return 2;
            if (_weaponType == WeaponType.BOW)
                return 3;
            return 1;
        }

        public int GetReloadTime()
        {
            if (_weaponType == WeaponType.MAZE) 
                return 3;
            if (_weaponType == WeaponType.SPEAR)
                return 3;
            if (_weaponType == WeaponType.ARROW)
                return 2;
            if (_weaponType == WeaponType.BOW)
                return 5;
            return 2;
        }

        public double GetRange()
        {
            if (_weaponType == WeaponType.SPEAR)
                return 3.5;
            if (_weaponType == WeaponType.BOW)
                return 20.5;
            return 1.5;
        }

        public WeaponType GetRandomWeapon()
        {

            var r1 = Utils.GetRandomInt(0, 5);
            if (r1 == 1)
                return WeaponType.SWORD;
            if (r1 == 2)
                return WeaponType.MAZE;
            if (r1 == 3)
                return WeaponType.SPEAR;
            if (r1 == 4)
            {
                return WeaponType.BOW;
            }
            return WeaponType.FISTS;
        }

    }
}
