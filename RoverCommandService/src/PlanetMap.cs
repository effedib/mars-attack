namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a planet map with specified width and height.
    /// Generates a grid of coordinates for the planet map based on its width and height.
    /// Implements the <see cref="IPlanetMap"/> interface.
    /// </summary>
    /// <returns>An array of coordinate tuples representing the planet map.</returns>
    public record PlanetMap(int Width, int Height) : IPlanetMap
    {
        private static readonly Random random = new();

        /// <summary>
        /// Gets the grid representing the coordinates of the planet map.
        /// </summary>
        public (int, int)[] MapGrid => GenerateGrid();

        /// <summary>
        /// Generates a grid of coordinates for the planet map based on its width and height.
        /// </summary>
        /// <returns>An array of coordinate tuples representing the planet map.</returns>
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

        /// <summary>
        /// Checks if there is an obstacle at the specified coordinates on the planet map.
        /// </summary>
        /// <param name="x">The X-coordinate to check.</param>
        /// <param name="y">The Y-coordinate to check.</param>
        /// <returns>True if there is an obstacle, otherwise false.</returns>
        public bool CheckObstacle(int x, int y)
        {
            return random.Next(0, 4) == 0;
        }
    }
}
