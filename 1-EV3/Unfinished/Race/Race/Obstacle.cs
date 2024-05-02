namespace Race
{
    public abstract class Obstacle : RaceObject
    {
        protected Obstacle(string name) : base(name) 
        { 
            IsAlive = true;
        }
    }
}
