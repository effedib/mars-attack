namespace RoverCommandService.src
{
    public class Point(int x, int y, Directions direction) : IPoint
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Directions Direction { get; set; } = direction;

    }
}
