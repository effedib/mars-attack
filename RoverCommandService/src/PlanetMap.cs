namespace RoverCommandService.src
{
    public class PlanetMap(int width, int height) : IPlanetMap
    {
        public int Width => width;
        public int Height => height;

        private readonly Random random = new();

        public (int, int)[] MapGrid => GenerateGrid();

        private (int, int)[] GenerateGrid()
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

        public bool CheckObstacle(int x, int y)
        {
            return random.Next(0, 4) == 0;
        }
    }
}
