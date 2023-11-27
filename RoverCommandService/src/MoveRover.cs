
namespace RoverCommandService.src
{
    /// <summary>
    /// Represents a class responsible for moving a Rover based on commands received in JSON format.
    /// Implements the <see cref="IMoveRover"/> interface.
    /// </summary>
    public class MoveRover(string commandJson) : IMoveRover
    {
        /// <summary>
        /// Singleton instance of the Rover.
        /// </summary>
        Rover RoverIstance { get; } = Rover.Instance;

        /// <summary>
        /// Parsed commands from the JSON string.
        /// </summary>
        Dictionary<string, string>? CommandJsonParsed { get; } = CommandJsonParser.ParseJson(commandJson);

        /// <summary>
        /// Array of individual commands extracted from the parsed JSON.
        /// </summary>
        char[] Commands { get; set; } = [];

        /// <summary>
        /// String indicating the presence or absence of obstacles during execution.
        /// </summary>
        string Obstacle { get; set; } = string.Empty;

        /// <summary>
        /// Executes the parsed Rover commands and returns the result.
        /// </summary>
        /// <returns>A string containing information about obstacle detection and the Rover's current position.</returns>
        public string ExecuteCommands()
        {
            if (CommandJsonParsed == null) { return "No commands received"; }

            Commands = CommandJsonParsed["commands"].ToCharArray();

            RoverIstance.ReceiveCommands(Commands);

            //if (RoverIstance.FoundObstacle)
            //{
            //    Obstacle = $"Obstacle detected at position: ({RoverIstance.Obstacle.X}, {RoverIstance.Obstacle.Y})";
            //}
            //else
            //{
            //    Obstacle = "No obstacle detected!";
            //}

            Obstacle = RoverIstance.FoundObstacle.Equals(true) ? 
                        $"Obstacle detected at position: ({RoverIstance.Obstacle.X}, {RoverIstance.Obstacle.Y})" :
                        "No obstacle detected!";

            return Obstacle + $"\nCurrent position: ({RoverIstance.Location.X}, {RoverIstance.Location.Y})\nCurrent direction: {RoverIstance.Location.Direction}";
        }
    }
}
