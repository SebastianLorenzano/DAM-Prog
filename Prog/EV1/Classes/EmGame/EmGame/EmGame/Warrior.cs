﻿using EmGame;
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
        RANDOM,
        NORMAL,
        BERSERKER
    }

    public class Warrior : Rect
    {
        private int _health = 20;
        private TeamType _team;
        private Weapon _weapon;
        private AttackMode _mode;

        public Warrior(TeamType team, WeaponType weapontype, AttackMode attackMode, double r, double g, double b, int width, int height)
        {
            this.r = r;
            _team = team;
            _weapon = new Weapon(weapontype);
            if (attackMode == AttackMode.RANDOM)
                _mode = GetRandomAttackMode();
            this.r = r;
            this.g = g;
            this.b = b;
            _width = width;
            _height = height;

        }

        public AttackMode GetRandomAttackMode()
        {
            var r1 = Utils.GetRandomInt(0, 2);
            if (r1 == 1)
                return AttackMode.BERSERKER;
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
                Position warrPosition = new Position(this.GetX(), this.GetY());
                var goToPosition = warzone.GetClosestEnemyPosition(_team, warrPosition);
                goToPosition = warzone.GetBestPosition(goToPosition, warrPosition);
                MoveTo(goToPosition, warzone);


            }

            else 
            {
                var position = warzone.GetEnemiesCenterPosition(_team);
                Position warrPosition = new Position(GetX(), GetY());
                position = warzone.GetBestPosition(position, warrPosition);
                MoveTo(position, warzone);


            }








            /*  
                  if (WarZone.GetDistance(_x, _y, _x, warzone.rect._height / 2) != 0)
                  {
                      if (_y < warzone.rect._height / 2 && !warzone.IsOccupied(_x, _y + 1))
                          _y += 1;
                      else if (_y > warzone.rect._height / 2 && !warzone.IsOccupied(_x, _y - 1))
                          _y += -1;
                  }
                  if (WarZone.GetDistance(_x, _y, _x, warzone.rect._height / 2) == 0)
                  {
                      if (_x < warzone.rect._width / 2 && !warzone.IsOccupied(_x + 1, _y))
                          _x += 1;
                      else if (_x > warzone.rect._width / 2 && !warzone.IsOccupied(_x - 1, _y))
                          _x += -1;
                  }

         */
        }


    }
    // Preguntarle a javi si combiene en WarZone poner una funcion que cuente donde estan los enemigos para moverse ahi //

}



