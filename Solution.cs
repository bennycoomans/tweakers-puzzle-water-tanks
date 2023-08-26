namespace TweakersPuzzle;

public class Solution
{
	private readonly List<WaterTank> _tanks;

	public int Number { get; }
	public int[] BreakLengths { get; }

	private readonly List<int?> _tanksToFill;
	private readonly bool _log;

	private WaterTank? _currentlyFillingTank = null;

	public Solution(int number, List<int?> tanksToFill, int[] breakLengths, bool log)
	{
		Number = number;
		_tanksToFill = tanksToFill;
		BreakLengths = breakLengths;
		_log = log;

		_tanks = new()
		{
			new(1, 100, 1, log),
			new(2, 30, 2, log),
			new(3, 30, 2, log),
			new(4, 50, 2, log),
			new(5, 72, 2, log),
		};
	}

	public void Process()
	{
		int minutesPast = 0;
		for (int i = 0; i < 10; i++)
		{
			ProcessMinute();
			minutesPast++;
		}

		int breaksTaken = 0;

		foreach (int? tankToFill in _tanksToFill)
		{
			if (tankToFill.HasValue)
			{
				_currentlyFillingTank = _tanks[tankToFill.Value - 1];
				if (_log)
				{
					Console.WriteLine($"Now filling tank {_currentlyFillingTank.Number}");
				}
			}
			else if (_log)
			{
				Console.WriteLine($"Not filling any tank now");
			}

			int amountOfMinutesToTakeBreak = BreakLengths[breaksTaken];

			int currentTankMinutesPassed = 0;
			do
			{
				ProcessMinute();
				minutesPast++;

				currentTankMinutesPassed++;
			} while (minutesPast < 60 && (_currentlyFillingTank != null || (tankToFill == null && currentTankMinutesPassed < amountOfMinutesToTakeBreak)));

			if (minutesPast == 60)
			{
				if (tankToFill == null && currentTankMinutesPassed < amountOfMinutesToTakeBreak)
				{
					throw new BreakNotUsedException();
				}
				break;
			}
			
			if (!tankToFill.HasValue)
			{
				breaksTaken++;
			}
		}
	}

	private void ProcessMinute()
	{
		foreach (var tank in _tanks)
		{
			if (tank == _currentlyFillingTank)
			{
				bool isFull = tank.Fill();
				if (isFull)
				{
					_currentlyFillingTank = null;
				}
			}
			else
			{
				bool isEmpty = tank.Empty();
				if (isEmpty)
				{
					throw new WaterTankEmptyException(tank.Number);
				}
			}
		}
	}
}