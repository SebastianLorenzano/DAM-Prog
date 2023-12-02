using EmGame;



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
        RANDOM,
        NORMAL,             // VA HACIA LA MASA DE ENEMIGOS            
        BERSERKER,          // VA HACIA EL ENEMIGO MAS CERCANO
        ROGUE,              // BUSCA A LOS ARQUEROS
    }

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
            var r1 = Utils.GetRandomInt(0, 3);
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
                _x = position.x;        // Agregar limitaciones luego
                _y = position.y;
        }
               
        public void Move(WarZone warzone)
        { 
            if (_mode == AttackMode.BERSERKER)
            {
                Position warrPosition = new Position(GetX(), GetY());
                var goToPosition = warzone.GetClosestEnemyPosition(_team, warrPosition);
                goToPosition = warzone.GetBestPosition(goToPosition, warrPosition);
                MoveTo(goToPosition, warzone);
            }
            else if (_mode == AttackMode.ROGUE)
            {
                Position warrPosition = new Position(GetX(), GetY());
                var avoidPosition = warzone.GetEnemiesCenterPositionWithWeaponType(WeaponType.BOW, _team, warrPosition);
                var goToPosition = warzone.GetClosestEnemyPositionWithWeaponType(WeaponType.BOW, _team, warrPosition);
                goToPosition = warzone.GetBestPosition(goToPosition, warrPosition, avoidPosition);
                MoveTo(goToPosition, warzone);
            }
            else 
            {
                var position = warzone.GetEnemiesCenterPosition(_team);
                Position warrPosition = new Position(GetX(), GetY());
                position = warzone.GetBestPosition(position, warrPosition);
                MoveTo(position, warzone);
            }
        }
    }
}



