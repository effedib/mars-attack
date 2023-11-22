namespace RoverCommandService
{
    public interface IRoverCommandReceiver
    {
        void ReceiveCommands(char[] commands);
    }

    public enum Directions
    {
        N,
        E,
        S,
        W
    }

    public class Point(int x, int y, Directions direction)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Directions Direction { get; set; } = direction;

    }
    public class Rover(int x, int y, Directions direction) : IRoverCommandReceiver
    {

        private Point location = new(x, y, direction);

        private readonly int directionsCount = Enum.GetValues(typeof(Directions)).Length;

        private static PlanetMap planetMap = new(10, 10);

        private (int, int)[] mapGrid = planetMap.GenerateGrid();
        public void ReceiveCommands(char[] commands)
        {
            bool checkObastacle = false;
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'f':
                        checkObastacle = MoveRover();
                        break;
                    case 'b':
                        checkObastacle = MoveRover(-1);
                        break;
                    case 'r':
                        TurnRover(location.Direction);
                        break;
                    case 'l':
                        TurnRover(location.Direction, -1);
                        break;
                    default:
                        break;
                }
                if (checkObastacle) break;
            }
        }

     
        private bool MoveRover(int directionMovement = 1)
        {
            Point nextLocation = new(location.X, location.Y, location.Direction);
            switch (location.Direction)
            {
                case Directions.N:
                    nextLocation.Y = (location.Y + 1) * directionMovement;
                    break;
                case Directions.E:
                    nextLocation.X = (location.X + 1) * directionMovement;
                    break;
                case Directions.S:
                    nextLocation.Y = (location.Y - 1) * directionMovement;
                    break;
                case Directions.W:
                    nextLocation.X = (location.X - 1) * directionMovement;
                    break;
                default:
                    break;
            }

            if (planetMap.CheckObstacle(nextLocation.X, nextLocation.Y))
            {
                location = nextLocation;
                Console.WriteLine("Road clean, no obstacle detected");
                Console.WriteLine($"new Point = {location.X},{location.Y}");
                return false;
            }
            else
            {
                Console.WriteLine("Obstacle detected, STOP!");
                return true;
            }

        }

        private void TurnRover(Directions current, int directionTournement = 1)
        {
            int newIndexDirection = (int)current + directionTournement;

            int addDirectionsCount = (directionTournement == 1) ? directionsCount : 0;

            location.Direction = (Directions)((newIndexDirection + addDirectionsCount) % directionsCount);

            Console.WriteLine($"new direction = {location.Direction}");

        }
    }
}
