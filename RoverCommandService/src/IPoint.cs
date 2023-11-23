namespace RoverCommandService.src
{
    public interface IPoint
    {
        Directions Direction { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}