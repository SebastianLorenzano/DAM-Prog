using EmGame;



namespace Classes
{

    public enum TeamType
    {
        HUMAN,
        ORC,
    }

    public enum AttackMode
    {
        RANDOM,
        NORMAL,             // VA HACIA LA MASA DE ENEMIGOS            
        BERSERKER,          // VA HACIA EL ENEMIGO MAS CERCANO
        ROGUE,              // BUSCA A LOS ARQUEROS
    }

    // Javi: Interesante herencia, ...
    public class Warrior : Rect
    {
        private int _health = 20;
        private TeamType _team;
        private Weapon _weapon;
        private AttackMode _mode;

        public Warrior(TeamType team, WeaponType weapontype, AttackMode attackMode, int width, int height)
        {
            _team = team;
            
            if (attackMode == AttackMode.RANDOM)
                _mode = GetRandomAttackMode();
            if (team == TeamType.HUMAN && _mode == AttackMode.ROGUE)
            {
                r = 1;
                g = 0.71;
                b = 0.75;
            }
            if (team == TeamType.HUMAN && _mode != AttackMode.ROGUE)
            {
                r = 0;
                g = 0;
                b = 0;
            }
            if (team == TeamType.ORC && _mode == AttackMode.ROGUE)
                {
                r = 0.75;
                g = 0.79;
                b = 0.34;
            }
            if (team == TeamType.ORC && _mode != AttackMode.ROGUE)
            {
                r = 0.12;
                g = 0.32;
                b = 0.16;
            }
            if (_mode == AttackMode.ROGUE)
                _weapon = new Weapon(WeaponType.SWORD);
            else
                _weapon = new Weapon(weapontype);
            _width = width;
            _height = height;

        }

        public AttackMode GetRandomAttackMode()
        {
            var r1 = Utils.GetRandomInt(0, 4);
            if (r1 == 1)
                return AttackMode.BERSERKER;
            if (r1 == 2)
                return AttackMode.ROGUE;
            return AttackMode.NORMAL;

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
        public Warrior? ExecuteTurn(WarZone wz)
        {
            List<Warrior>? result = wz.GetEnemiesInRange(GetX(), GetY());
            if (result.Count == 0 || result == null)
            {
                Move(wz);
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

        // Javi: AttackTo
        public void Attack(Warrior warr)
        {
            if (warr == null)
                return;
            if (_weapon.reloadTimeLeft == 0)
            {
                warr._health -= GetWeaponDamage();
                _weapon.reloadTimeLeft = _weapon.GetReloadTime();
            }
        }
        public void MoveTo(Position pos, WarZone wz)
        {
            if (pos.x > wz.GetX() && pos.x < wz.GetWidth() && pos.y > wz.GetX() && pos.y < wz.GetHeight()) 
            {
                _x = pos.x;
                _y = pos.y;
            }
        }// Agregar limitaciones luego

        public void Move(WarZone wz)
        { 
            if (_mode == AttackMode.BERSERKER)
            {
                Position warrPosition = new Position(GetX(), GetY());
                var goToPosition = wz.GetClosestEnemyPosition(_team, warrPosition);
                goToPosition = wz.GetBestPosition(goToPosition, warrPosition);
                MoveTo(goToPosition, wz);
            }
            // Javi: XXXXXXXXXDDDDDDDDDDDD, ..., mola
            else if (_mode == AttackMode.ROGUE)
            {
                Position warrPos = new Position(GetX(), GetY());
                var avoidPosition = wz.GetEnemiesCenterPositionWithWeaponType(WeaponType.BOW, _team, warrPos);
                var goToPosition = wz.GetClosestEnemyPositionWithWeaponType(WeaponType.BOW, _team, warrPos);
                goToPosition = wz.GetBestPosition(goToPosition, warrPos, avoidPosition);
                MoveTo(goToPosition, wz);
            }
            else 
            {
                var position = wz.GetEnemiesCenterPosition(_team);
                Position warrPos = new Position(GetX(), GetY());
                position = wz.GetBestPosition(position, warrPos);
                MoveTo(position, wz);
            }
        }
    }
}



