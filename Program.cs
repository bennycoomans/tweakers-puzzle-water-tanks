// See https://aka.ms/new-console-template for more information

using TweakersPuzzle;

try
{
	var tanks = new List<WaterTank>
	{
		new WaterTank(100, 1),
		new WaterTank(30, 2),
		new WaterTank(30, 2),
		new WaterTank(50, 2),
		new WaterTank(72, 2),
	};
	
	// Take a 10 minute break.
	for (int i = 0; i < 10; i++)
	{
		foreach (var tank in tanks)
		{
			tank.Empty();
		}
	}
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
