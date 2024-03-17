namespace Race
{
    public class Rock : Obstacle
    {

        public double Weight { get; }
        public override bool IsAlive { get; set; }

        private Rock(string name, double weight) : base(name)
        {
            Weight = weight;
        }

        public override double GetRange()
        {
            return 40;
        }

        public double GetPosition()
        {
            return _position;
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.ROCK;
        }

        public static Rock? Create(string name, double weight)
        {
            if (name == null || 10 > weight || weight > 30)
                return null;
            return new Rock(name, weight);
        }

        public override void Simulate(IRace race)
        {
            if (_roundsDisabled == 0)
            {
                var objects = Race.GetObjectsInRange(GetRange(), _position);
                throw new NotImplementedException();
                //TODO
            }

            base.Simulate(race);
        }
    }
}
