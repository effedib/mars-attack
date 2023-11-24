namespace RoverCommandService.src
{
    public interface IPlanetMap
    {
        int Height { get; }
        int Width { get; }
        (int, int)[] MapGrid { get; }

        bool CheckObstacle(int x, int y);
    }
}