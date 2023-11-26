namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a Rover capable of receiving and executing commands.
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// Receives an array of commands and executes them to control the Rover's movement and direction.
        /// </summary>
        /// <param name="commands">An array of commands to be executed.</param>
        void ReceiveCommands(char[] commands);

        /// <summary>
        /// Resets the Rover's location to the starting position.
        /// </summary>
        void Reset();
    }
}
