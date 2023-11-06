using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmGame
{
    public class EmGame
    {
        public EmGame()
        {
            var warzone = new WarZone();
        }
        public void Start(int value1, int value2, int value3, int value4)
        {

        }

        public Warrior.TeamType GetWinner()
        {
            return Warrior.TeamType.HUMAN;
        }
    }
}
