namespace RoverCommandService
{
    public class PlanetMap(int width, int height)
    {
        public int Width => width;
        public int Height => height;

        private readonly Random random = new();
        public (int, int)[] GenerateGrid()
        {
            var grid = new (int, int)[width * height];
            int index = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[index++] = (x, y);
                }
            }

            return grid;
        }

        public bool CheckObstacle(int x, int y, (int, int)[] grd)
        {
            Console.WriteLine($"Check obstacle for {x},{y}");
            return random.Next(0, 2) == 0;
        }
    }
}
