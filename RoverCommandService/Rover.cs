namespace RoverCommandService
{

    public enum Directions
    {
        N,
        E,
        S,
        W
    }
    public class Rover(int x, int y, Directions direction, PlanetMap planetMap) : IRoverCommandReceiver
    {

        private Point location = new(x, y, direction);

        private readonly int directionsCount = Enum.GetValues(typeof(Directions)).Length;

        private PlanetMap PlanetMapObj => planetMap;

        public void ReceiveCommands(char[] commands)
        {
            string commandsString = new string(commands.ToArray());
            Console.WriteLine($"Commands received: {commandsString}\n");

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
                        TurnRover();
                        break;
                    case 'l':
                        TurnRover(-1);
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
                    nextLocation.Y = (location.Y + directionMovement + PlanetMapObj.Height) % PlanetMapObj.Height;
                    break;
                case Directions.E:
                    nextLocation.X = (location.X + directionMovement + PlanetMapObj.Width) % PlanetMapObj.Width;
                    break;
                case Directions.S:
                    nextLocation.Y = (location.Y - directionMovement + PlanetMapObj.Height) % PlanetMapObj.Height;
                    break;
                case Directions.W:
                    nextLocation.X = (location.X - directionMovement + PlanetMapObj.Width) % PlanetMapObj.Width;
                    break;
                default:
                    break;
            }

            if (!PlanetMapObj.CheckObstacle(nextLocation.X, nextLocation.Y))
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

        private void TurnRover(int directionTournement = 1)
        {
            int addDirectionsCount = (directionTournement < 0) ? directionsCount : 0;

            int newIndexDirection = (int)location.Direction + directionTournement + addDirectionsCount;

            location.Direction = (Directions)(newIndexDirection % directionsCount);

            Console.WriteLine($"new direction = {location.Direction}");
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
    }
}
