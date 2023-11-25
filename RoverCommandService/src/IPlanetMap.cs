namespace RoverCommandService.src
{
    public interface IPlanetMap
    {
        int Width { get; }
        int Height { get; }
        (int, int)[] MapGrid { get; }

        bool CheckObstacle(int x, int y);
    }
}