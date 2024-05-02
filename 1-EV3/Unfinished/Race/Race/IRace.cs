namespace Race
{
    public delegate void VisitDelegate<T>(T element);
    public interface IRace
    {
        void AddObject(RaceObject obj, double position);
        void Init(double distance);
        void SimulateStep();
        void VisitDrivers();
        int GetObjectCOunt();
        RaceObject GetObjectAt(int index);

    }
}
