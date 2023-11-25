namespace RoverCommandService.src
{
    public sealed class Rover : IRover
    {
        private static Rover instance = null!;

        public static Rover Instance
        {
            get
            {
                // if instance == null
                return instance ??= new Rover(0, 0, Directions.N, new PlanetMap(10, 10));
            }
        }

        private int X { get; }
        private int Y { get; }
        private Directions Dir { get; }
        public Point Location { get; private set; }
        public PlanetMap PlanetMapObj { get; }
        private readonly int directionsCount = Enum.GetValues(typeof(Directions)).Length;
        public bool FoundObstacle { get; private set; }

        private Rover(int x, int y, Directions direction, PlanetMap planetMap)
        {
            X = x; Y = y; Dir = direction;
            Location = new(X, Y, Dir);
            PlanetMapObj = planetMap;
        }

        public void Reset()
        {
            Location.X = 0;
            Location.Y = 0;
            Location.Direction = Directions.N;
        }

        public void ShowMap()
        {
            Console.WriteLine("Generating Map...\n");
            (int, int)[] grd = PlanetMapObj.MapGrid;

            int previousX = 0;
            foreach (var point in grd)
            {
                if (point.Item1 == previousX)
                {
                    Console.Write($"{point} ");
                }
                else
                {
                    previousX = point.Item1;
                    Console.Write($"\n{point} ");
                }
            }
            Console.WriteLine("\n");
        }

        public void ReceiveCommands(char[] commands)
        {
            string commandsString = new(commands.ToArray());
            Console.WriteLine($"Commands received: {commandsString}\n");

            FoundObstacle = false;
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'f':
                        FoundObstacle = MoveRover(1);
                        break;
                    case 'b':
                        FoundObstacle = MoveRover(-1);
                        break;
                    case 'r':
                        TurnRover();
                        break;
                    case 'l':
                        TurnRover(-1);
                        break;
                    default:
                        break;
                }
                if (FoundObstacle) break;
            }
        }

        private bool MoveRover(int directionMovement)
        {
            Point nextLocation = CalculateNextLocation(directionMovement);

            if (!PlanetMapObj.CheckObstacle(nextLocation.X, nextLocation.Y))
            {
                Location = nextLocation;
                Console.WriteLine("Road clean, no obstacle detected");
                Console.WriteLine($"new Point = {Location.X},{Location.Y}\n");
                return false;
            }
            else
            {
                Console.WriteLine("Obstacle detected, STOP!\n");
                return true;
            }
        }

        private Point CalculateNextLocation(int directionMovement)
        {
            Point nextLocation = new(Location.X, Location.Y, Location.Direction);
            switch (Location.Direction)
            {
                case Directions.N:
                    nextLocation.Y = (Location.Y + directionMovement + PlanetMapObj.Height) % PlanetMapObj.Height;
                    break;
                case Directions.E:
                    nextLocation.X = (Location.X + directionMovement + PlanetMapObj.Width) % PlanetMapObj.Width;
                    break;
                case Directions.S:
                    nextLocation.Y = (Location.Y - directionMovement + PlanetMapObj.Height) % PlanetMapObj.Height;
                    break;
                case Directions.W:
                    nextLocation.X = (Location.X - directionMovement + PlanetMapObj.Width) % PlanetMapObj.Width;
                    break;
                default:
                    break;
            }

            return nextLocation;
        }

        private void TurnRover(int directionTournement = 1)
        {
            int addDirectionsCount = directionTournement < 0 ? directionsCount : 0;

            int newIndexDirection = (int)Location.Direction + directionTournement + addDirectionsCount;

            Location.Direction = (Directions)(newIndexDirection % directionsCount);

            Console.WriteLine($"new direction = {Location.Direction}\n");
        }
    }
}
