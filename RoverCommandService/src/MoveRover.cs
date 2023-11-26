
namespace RoverCommandService.src
{
    public class MoveRover(string commandJson) : IMoveRover
    {
        Rover RoverIstance { get; } = Rover.Instance;

        Dictionary<string, string>? CommandJsonParsed { get; } = CommandJsonParser.ParseJson(commandJson);

        char[] Commands { get; set; } = [];

        string Obstacle { get; set; } = string.Empty;

        public string ExecuteCommands()
        {
            if (CommandJsonParsed == null) { return "No commands received"; }

            Commands = CommandJsonParsed["commands"].ToCharArray();

            RoverIstance.ShowMap();
            RoverIstance.ReceiveCommands(Commands);

            if (RoverIstance.FoundObstacle)
            {
                Obstacle = "Obstacle detected!";
            }
            else
            {
                Obstacle = "No obstacle detected!";
            }
            return Obstacle + $"\nCurrent position: ({RoverIstance.Location.X}, {RoverIstance.Location.Y})\nCurrent direction: {RoverIstance.Location.Direction}";
        }
    }
}
