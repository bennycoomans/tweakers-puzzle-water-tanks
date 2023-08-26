namespace TweakersPuzzle;

public class WaterTankEmptyException : Exception
{
	public WaterTankEmptyException(int tankNumber)
	{
		TankNumber = tankNumber;
	}

	public int TankNumber { get; }
}