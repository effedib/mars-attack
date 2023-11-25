namespace RoverCommandService.src
{
    public record PlanetMap(int Width, int Height) : IPlanetMap
    {
        private static readonly Random random = new();

        public (int, int)[] MapGrid => GenerateGrid();

        private (int, int)[] GenerateGrid()
        {
            var grid = new (int, int)[Width * Height];
            int index = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
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
