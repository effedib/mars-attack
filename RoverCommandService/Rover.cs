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
                        checkObastacle = MoveForward();
                        break;
                    case 'b':
                        checkObastacle = MoveBackward();
                        break;
                    case 'r':
                        TurnRight();
                        break;
                    case 'l':
                        TurnLeft();
                        break;
                    default:
                        break;
                }
                if (checkObastacle) break;
            }
        }

        private bool MoveForward()
        {
            return Movement();
        }

        private bool MoveBackward()
        {
            return Movement(-1);
        }
     
        private bool Movement(int directionMovement = 1)
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

        private void TurnRight()
        {
            location.Direction = GetNextDirection(location.Direction);
            Console.WriteLine($"new direction = {location.Direction}");
        }

        private void TurnLeft()
        {
            location.Direction = GetPreviousDirection(location.Direction);
            Console.WriteLine($"new direction = {location.Direction}");
        }

        private Directions GetNextDirection(Directions current)
        {
            return (Directions)(((int)current + 1) % directionsCount);
        }
        private Directions GetPreviousDirection(Directions current)
        {
            return (Directions)(((int)current - 1 + directionsCount) % directionsCount);
        }
    }
}
