namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a planet map with specified width and height.
    /// </summary>
    public interface IPlanetMap
    {
        int Width { get; }
        int Height { get; }

        /// <summary>
        /// Gets an array representing the coordinates of the planet map.
        /// </summary>
        (int, int)[] MapGrid { get; }

        /// <summary>
        /// Checks if there is an obstacle at the specified coordinates on the planet map.
        /// </summary>
        /// <param name="x">The X-coordinate to check.</param>
        /// <param name="y">The Y-coordinate to check.</param>
        /// <returns>True if there is an obstacle, otherwise false.</returns>
        bool CheckObstacle(int x, int y);
    }
}