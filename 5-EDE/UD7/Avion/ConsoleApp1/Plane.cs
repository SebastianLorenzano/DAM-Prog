namespace ConsoleApp1
{
    /// <summary>
    /// This class allows the creation of a plane object, which has the ability
    /// to do basic vertical movements, turn and consume fuel
    /// </summary>
    public class Plane
    {
        private double _height;
        private double _speed; 
        private double _fuel;
        private double _orientation = 0;

        /// <summary>
        /// Gets the height of the plane
        /// <value>Height of the plane</value>
        /// <remarks>Points to _height</remarks>
        /// </summary>
        public double Height => _height;
        /// <summary>
        /// Gets the speed of the plane
        /// <value>Speed of the plane</value>
        /// <remarks>Points to _speed</remarks>
        /// </summary>
        public double Speed => _speed;
        /// <summary>
        /// Gets the orientation of the plane in grades
        /// <value>Height of the plane</value>
        /// <remarks>Points to _orientation</remarks>
        /// </summary>
        public double Orientation => _orientation;
        /// <summary>
        /// Gets the fuel of the plane
        /// <value>Fuel of the plane</value>
        /// <remarks>Points to _fuel</remarks>
        /// </summary>
        public double Fuel => _fuel;
        /// <summary>
        /// Constructor of the object
        /// </summary>
        /// <param name="height"></param>
        /// <param name="velocity"></param>
        /// <param name="fuel"></param>
        /// <param name="orientation"></param>
        public Plane(double height, double velocity, double fuel, double orientation)
        {
            _height = height;
            _speed = velocity;
            _fuel = fuel;
            _orientation = orientation;
        }

        /// <summary>
        /// It allows the plane to turn horizontally.
        /// </summary>
        /// <param name="degrees"></param>
        public void Turn(double degrees)
        {
            _orientation = (_orientation + degrees) % 360;
            ConsumeFuel(degrees * 0.1);
        }

        /// <summary>
        /// It allows the plane to ascend.
        /// </summary>
        /// <param name="meters"></param>
        public void Ascend(double meters)
        {
            _height += meters;
            ConsumeFuel(meters * 0.3);
        }

        /// <summary>
        /// It allows the plane to descend.
        /// </summary>
        /// <param name="metros"></param>
        public void Descend(double metros)
        {
            _height -= metros;
            if (_height < 0)
                _height = 0;
        }

        /// <summary>
        /// It allows the plane to consume fuel. It can be negative, so you can also use it to add fuel.
        /// </summary>
        /// <param name="litros"></param>
        private void ConsumeFuel(double litros)
        {
            _fuel -= litros;
            if (_fuel < 0)
                _fuel = 0;
        }
    }
}
