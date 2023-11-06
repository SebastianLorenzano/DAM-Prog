using System;


namespace EmGame
{
    public enum WeaponType
    {
        FISTS,
        SWORD,
        MAZE,
        SPEAR,
        ARROW,
        BOW
    }
    public class Weapon
    {
        public Weapon(WeaponType type)
        {

        }
        private WeaponType _weaponType;

        public WeaponType GetWeaponType()
            { return _weaponType; }

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
                return 2;
            if (_weaponType == WeaponType.SPEAR)
                return 2;
            if (_weaponType == WeaponType.ARROW)
                return 1;
            if (_weaponType == WeaponType.BOW)
                return 3;
            return 1;
        }



    }
}
