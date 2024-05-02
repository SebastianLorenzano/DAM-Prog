using System.Runtime.InteropServices;

namespace Race
{

    public enum ObjectType
    {
        ROCK,
        PUDDLE, 
        BOMB,
        CAR,

    }

    public abstract class RaceObject
    {
        private string _name;
        protected double _position;
        protected int _roundsDisabled;

        public string Name => _name;
        public double Position { get => _position; set => SetPosition(value); }
        public int RoundsDisabled => _roundsDisabled;

        public abstract bool IsAlive { get; set; }


        protected RaceObject(string name, double position = 0, int roundsDisabled = 0)
        {
            _name = name;
            _position = position;
            _roundsDisabled = roundsDisabled;
        }


        public void SetPosition(double position) 
        {
            if (position < 0)
                throw new Exception("Position is out of the map.");
        }

        public virtual double GetRange()
        {
            return 0;
        }

        public abstract ObjectType GetObjectType();
        public void Disable(int value)
        {
            if (value > 0)
                _roundsDisabled += 0;
            else if (value == 0)
                _roundsDisabled = 0;
        }
        public virtual void Simulate(IRace race)
        {
            if (_roundsDisabled > 0)
                _roundsDisabled--;
        }




    }
}
