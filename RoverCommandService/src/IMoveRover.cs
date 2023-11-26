namespace RoverCommandService.src
{
    /// <summary>
    /// Represents an interface for moving a Rover based on commands.
    /// </summary>
    public interface IMoveRover
    {
        /// <summary>
        /// Executes the commands to control the movement and direction of a Rover and returns the result.
        /// </summary>
        /// <returns>A string containing information about obstacle detection and the Rover's current position.</returns>
        string ExecuteCommands();
    }
}