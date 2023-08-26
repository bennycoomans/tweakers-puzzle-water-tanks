// See https://aka.ms/new-console-template for more information

using TweakersPuzzle;

try
{
	const bool log = false;
	const int minBreakLength = 1;
	const int maxBreakLength = 20;
	var solutions = new List<Solution>();
	for (int i = minBreakLength; i <= maxBreakLength; i++)
	{
		for (int j = minBreakLength; j <= maxBreakLength; j++)
		{
			for (int k = minBreakLength; k <= maxBreakLength; k++)
			{
				solutions.Add(new Solution(1, new List<int?> { 1, 5, 4, 3, 2, 5, 4, null, 1 }, new[] { i }, log));
				solutions.Add(new Solution(2, new List<int?> { 5, 2, 3, 4, 1, null, 2, 3, 5, 4, 1, 2, 3, null }, new[] { i, j }, log));
				solutions.Add(new Solution(3, new List<int?> { 5, 3, 2, 1, null, 3, 2, 5, 1, 3, 2, null, 5 }, new[] { i, j }, log));
				solutions.Add(new Solution(4, new List<int?> { null, 2, 4, 1, 5, 3, null, 1, 2, 1, 3, 1, 5, null }, new[] { i, j, k }, log));
			}
		}
	}

	var workingSolutions = new List<Solution>();
	foreach (var solution in solutions)
	{
		if (log)
		{
			Console.WriteLine($"Trying solution {solution.Number} with break lengths {string.Join(",", solution.BreakLengths)}");
		}

		try
		{
			solution.Process();
			
			workingSolutions.Add(solution);
			if (log)
			{
				Console.WriteLine("Solution {0} seems to check out :)", solution.Number);
			}
		}
		catch (WaterTankEmptyException ex)
		{
			if (log)
			{
				Console.WriteLine("Tank {0} became empty while trying solution {1}", ex.TankNumber, solution.Number);
			}
		}
		catch (BreakNotUsedException)
		{
			if (log)
			{
				Console.WriteLine("A break was not used completely");
			}
		}
	}

	if (workingSolutions.Any())
	{
		foreach (var solution in workingSolutions)
		{
			Console.WriteLine($"Solution {solution.Number} with break lengths {string.Join(",", solution.BreakLengths)} seems to check out :)");
		}
	}
	else
	{
		Console.WriteLine("No solutions found :(");
	}
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
