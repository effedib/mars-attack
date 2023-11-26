namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a point in a two-dimensional space with coordinates (X, Y) and a facing direction.
    /// Implements the <see cref="IPoint"/> interface.
    /// </summary>
    public class Point(int x, int y, Directions direction) : IPoint
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Directions Direction { get; set; } = direction;
    }
}
