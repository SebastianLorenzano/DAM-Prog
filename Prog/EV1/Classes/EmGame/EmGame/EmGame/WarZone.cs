using System;


namespace Classes
{
    public class WarZone
    {
        private int x, y, width, height;

        public WarZone()
        {
            var warrior = new Warrior();
            List<Warrior> warriorList = new List<Warrior>();
        }

        public void CreateWarriors(int count, Warrior.TeamType type)
        {

        }

        public void RemoveWarrior(int index)
        {
            warriorList.RemoveAt()
        }
    }
}
