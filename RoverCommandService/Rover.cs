namespace RoverCommandService
{
    public interface IRoverCommandReceiver
    {
        void ReceiveCommands(char[] commands);
    }

    public class Rover : IRoverCommandReceiver
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }

        private char[] Directions { get;  }

        public Rover(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

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

        // check direction before move (if right/left, update direction, then move)
        private void MoveForward()
        {
            X += 1;
            Console.WriteLine("Move Forward!");
            Console.WriteLine($"new X = {X}");
        }

        private void MoveBackward()
        {
            X -= 1;
            Console.WriteLine("Move Backward!");
            Console.WriteLine($"new X = {X}");
        }

        private void TurnRight()
        {
            Console.WriteLine("Turn Right!");
        }

        private void TurnLeft()
        {
            Console.WriteLine("Turn Left!");
        }
    }
}
