namespace Race
{
    public class Race : IRace
    {
        private List<RaceObject> _objs = new();  
        public void AddObject(RaceObject obj, double position)
        {
            throw new NotImplementedException();
        }

        public RaceObject GetObjectAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetObjectCOunt()
        {
            throw new NotImplementedException();
        }

        public void Init(double distance)
        {
            throw new NotImplementedException();
        }

        public void SimulateStep()
        {
            throw new NotImplementedException();
        }

        public void VisitDrivers()
        {
            throw new NotImplementedException();
        }

        /*
        public static List<RaceObject> GetObjectsInRange(RaceObject obj)
        {
            var type = obj.GetType();
            if (type == ObjectType.ROCK)
                return GetObjectsInRange()
        }
        */

        public List<RaceObject> GetObjectsInRange(double range, double position)
        {
            var result = new List<RaceObject>();
            foreach (var item in _objs)
            {
                if ()
            }
        }
    }
}
