namespace TweakersPuzzle;

public class WaterTank
{
	public int Capacity { get; }
	public int EmptyRate { get; }
	public int CurrentAmount { get; private set; }

	public WaterTank(int capacity, int emptyRate)
	{
		Capacity = capacity;
		EmptyRate = emptyRate;
	}

	/// <summary>
	/// Removes <see cref="EmptyRate"/> liters of water from the tank.
	/// </summary>
	/// <returns>True if the tank is now empty or false otherwise</returns>
	public bool Empty()
	{
		CurrentAmount -= EmptyRate;
		return CurrentAmount <= 0;
	}

	/// <summary>
	/// Adds 10 liters of water to the tank, or less if the capacity is reached.
	/// </summary>
	/// <returns>True if the tank is now full or false otherwise.</returns>
	public bool Fill()
	{
		CurrentAmount = Math.Min(CurrentAmount + Constants.FillRate, Capacity);
		return CurrentAmount == Capacity;
	}
}