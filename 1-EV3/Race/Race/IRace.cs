namespace Race
{
    public interface IRace
    {
        delegate void VisitDelegate<T>(T element);
        
        void AddObject(RaceObject obj, double position);
        void Init(double distance);
        void SimulateStep();
        void VisitDrivers();
        int GetObjectCOunt();
        RaceObject GetObjectAt(int index);

    }
}
