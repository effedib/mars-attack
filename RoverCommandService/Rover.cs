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
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'f':
                        MoveForward();
                        break;
                    case 'b':
                        MoveBackward();
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
            }
        }

        private void MoveForward()
        {
            Movement();
        }

        private void MoveBackward()
        {
            Movement(-1);
        }
        private void Movement(int directionMovement = 1)
        {
            switch (location.Direction)
            {
                case Directions.N:
                    location.Y = (location.Y + 1) * directionMovement;
                    break;
                case Directions.E:
                    location.X = (location.X + 1) * directionMovement;
                    break;
                case Directions.S:
                    location.Y = (location.Y - 1) * directionMovement;
                    break;
                case Directions.W:
                    location.X = (location.X - 1) * directionMovement;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"new Point = {location.X},{location.Y}");
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
