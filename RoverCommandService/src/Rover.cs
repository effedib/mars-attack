namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a Rover that can navigate on a planet map based on received commands.
    /// Implements the <see cref="IRover"/> interface.
    /// </summary>
    public sealed class Rover : IRover
    {
        /// <summary>
        /// Singleton instance of the Rover.
        /// </summary>
        private static Rover instance = null!;

        /// <summary>
        /// X-coordinate of the Rover's initial location.
        /// </summary>
        private int X { get; }

        /// <summary>
        /// Y-coordinate of the Rover's initial location.
        /// </summary>
        private int Y { get; }

        /// <summary>
        /// Current direction the Rover is facing when starting.
        /// </summary>
        private Directions Dir { get; }

        /// <summary>
        /// Gets or sets the current location of the Rover.
        /// </summary>
        public Point Location { get; private set; }

        /// <summary>
        /// Gets the planet map passed to the Rover.
        /// </summary>
        public PlanetMap PlanetMapObj { get; }

        /// <summary>
        /// Total count of possible directions the Rover can face.
        /// </summary>
        private readonly int directionsCount = Enum.GetValues(typeof(Directions)).Length;

        /// <summary>
        /// Indicates whether the Rover has encountered an obstacle during its movement.
        /// </summary>
        public bool FoundObstacle { get; private set; }

        /// <summary>
        /// Private constructor for creating a Rover instance with specified initial parameters.
        /// </summary>
        private Rover(int x, int y, Directions direction, PlanetMap planetMap)
        {
            X = x; Y = y; Dir = direction;
            Location = new(X, Y, Dir);
            PlanetMapObj = planetMap;
            ShowMap();
        }

        /// <summary>
        /// Gets or initializes the singleton instance of the Rover.
        /// </summary>
        public static Rover Instance
        {
            get
            {
                // if instance == null
                return instance ??= new Rover(0, 0, Directions.N, new PlanetMap(10, 10));
            }
        }

        /// <summary>
        /// Resets the Rover's location to the starting position.
        /// </summary>
        public void Reset()
        {
            Location.X = 0;
            Location.Y = 0;
            Location.Direction = Directions.N;
        }

        /// <summary>
        /// Displays the map of the planet with Rover's initial position and obstacles.
        /// </summary>
        private void ShowMap()
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

        /// <summary>
        /// Receives and processes a sequence of commands to move and turn the Rover.
        /// </summary>
        /// <param name="commands">An array of commands (characters) to be executed.</param>
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
                }
                if (FoundObstacle) break;
            }
        }
        
        /// <summary>
        /// Moves the Rover in the specified direction on the planet map.
        /// </summary>
        /// <param name="directionMovement">The movement direction (1=forward, -1=backward).</param>
        /// <returns>True if an obstacle is encountered, otherwise false.</returns>
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

        /// <summary>
        /// Calculates the next location of the Rover based on the current direction and movement.
        /// </summary>
        /// <param name="directionMovement">The movement direction (1=forward, -1=backward).</param>
        /// <returns>The calculated next location of the Rover.</returns>
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
            }

            return nextLocation;
        }

        /// <summary>
        /// Turns the Rover in the specified direction on the planet map.
        /// </summary>
        /// <param name="directionTournement">The direction of the turn (1 for right, -1 for left).</param>
        private void TurnRover(int directionTournement = 1)
        {
            int addDirectionsCount = directionTournement < 0 ? directionsCount : 0;

            int newIndexDirection = (int)Location.Direction + directionTournement + addDirectionsCount;

            Location.Direction = (Directions)(newIndexDirection % directionsCount);

            Console.WriteLine($"new direction = {Location.Direction}\n");
        }
    }
}
