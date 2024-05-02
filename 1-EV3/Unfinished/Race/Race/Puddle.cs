namespace Race
{
    public class Puddle : Obstacle
    {
        protected Puddle(string name) : base(name)
        {
        }

        public override bool IsAlive { get; set; }

        public override ObjectType GetObjectType()
        {
            return ObjectType.PUDDLE;
        }

        public static Puddle? Create(string name)
        {
            if (name == null)
                return null;
            return new Puddle(name);
        }

        public override double GetRange()
        {
            return 20;
        }

        public override void Simulate(IRace race)
        {
            if (_roundsDisabled == 0)
            {
                var objects = Race.GetObjectsInRange(GetRange(), _position);
                throw new NotImplementedException();
                //TODO
            }

        }
    }
