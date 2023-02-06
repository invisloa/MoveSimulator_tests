namespace RouteCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			int startX = 0;
			int startY = 0;
			int endX = -8790;
			int endY = 649;

			CalculateRoute(startX, startY, endX, endY);
		}
		static bool CheckForObstacle(int x, int y, int xDirection, int yDirection, List<Tuple<int, int, int, int>> obstacles)
		{
			for (int i = 1; i <= 4; i++)
			{
				int nextX = x + i * xDirection;
				int nextY = y + i * yDirection;

				foreach (var obstacle in obstacles)
				{
					if (nextX >= obstacle.Item1 && nextX <= obstacle.Item1 + obstacle.Item3 &&
						nextY >= obstacle.Item2 && nextY <= obstacle.Item2 + obstacle.Item4)
					{
						return true;
					}
				}
			}

			return false;
		}
		static void CalculateRoute(int startX, int startY, int endX, int endY)
		{
			int xDiff = endX - startX;
			int yDiff = endY - startY;

			int xDirection = xDiff < 0 ? -1 : 1;
			int yDirection = yDiff < 0 ? -1 : 1;

			int x = startX;
			int y = startY;

			int moveNumber = 1;
			while (x != endX || y != endY)
			{
				int move = Math.Min(12, Math.Abs(endX - x));
				x += move * xDirection;

				move = Math.Min(12, Math.Abs(endY - y));
				y += move * yDirection;

				Console.WriteLine("Move " + moveNumber + ": x = " + x + ", y = " + y);
				moveNumber++;

				if (x == endX && y == endY)
				{
					break;
				}
			}
		}
	}
}