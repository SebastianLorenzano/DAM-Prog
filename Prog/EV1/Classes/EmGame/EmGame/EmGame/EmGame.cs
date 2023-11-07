using Classes;
using System;

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

        public TeamType GetWinner()
        {
            return TeamType.HUMAN;
        }
    }
}
