
public class Plane
{
	/// <summary>
	/// This class allows the creation of a plane object, which has the ability
	/// to do basic vertical movements, turn and consume fuel
	/// </summary>
    private double _height;
    private double _velocity;	// Velocity of the plane
    private double _fuel; 
	private double _orientation = 0;

	public double Velocity => _velocity;
	public double Height => _height;
	public double Orientation => _orientation;
    public double Fuel => _fuel;

    public Plane (double height, double velocity, double fuel, double orientation)
	{
		_height = height;
		_velocity = velocity;
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
