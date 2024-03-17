namespace Race
{
    public class Bomb : Obstacle
    {

        public override bool IsAlive { get; set; }

        public Bomb(string name, int turns) : base(name)
        {
            _roundsDisabled = turns;
        }

        public override double GetRange()
        {
            return 70;
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.BOMB;
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
