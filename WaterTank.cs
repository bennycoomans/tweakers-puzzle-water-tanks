namespace TweakersPuzzle;

public class WaterTank
{
	public int Number { get; }
	public int Capacity { get; }
	public int EmptyRate { get; }
	public int CurrentAmount { get; private set; }
	private readonly bool _logState;

	public WaterTank(int number, int capacity, int emptyRate, bool logState)
	{
		Number = number;
		Capacity = capacity;
		EmptyRate = emptyRate;
		_logState = logState;

		CurrentAmount = Capacity;
	}

	/// <summary>
	/// Removes <see cref="EmptyRate"/> liters of water from the tank.
	/// </summary>
	/// <returns>True if the tank is now empty or false otherwise</returns>
	public bool Empty()
	{
		CurrentAmount -= EmptyRate;
		LogState();
		return CurrentAmount < 0;
	}

	/// <summary>
	/// Adds 10 liters of water to the tank, or less if the capacity is reached.
	/// </summary>
	/// <returns>True if the tank is now full or false otherwise.</returns>
	public bool Fill()
	{
		CurrentAmount = Math.Min(CurrentAmount + Constants.FillRate, Capacity);
		LogState();
		return CurrentAmount == Capacity;
	}

	private void LogState()
	{
		if (_logState)
		{
			Console.WriteLine("Current state of tank {0}: {1} liters", Number, CurrentAmount);
		}
	}
}