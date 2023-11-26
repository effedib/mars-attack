
using Newtonsoft.Json;

namespace RoverCommandService.src
{
    /// <summary>
    /// Utility class for parsing JSON strings containing Rover commands.
    /// </summary>
    public static class CommandJsonParser
    {
        /// <summary>
        /// Key in the JSON object representing the Rover commands.
        /// </summary>
        public static readonly string Commands = "commands";

        /// <summary>
        /// Parses a JSON string and returns a dictionary representing the parsed object.
        /// </summary>
        /// <param name="jsonString">The JSON string to be parsed.</param>
        /// <returns>
        /// A dictionary representing the parsed JSON object if successful; otherwise, returns null.
        /// </returns>
        public static Dictionary<string, string>? ParseJson(string jsonString)
        {
            try
            {
                var parsedObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

                Validate(parsedObject!);

                return parsedObject;
            }
            catch
            {
                // Return null if parsing or validation fails.
                return null;
            }
        }

        /// <summary>
        /// Validates the parsed JSON object to ensure it contains the necessary keys and values.
        /// </summary>
        /// <param name="parsedObject">The parsed JSON object to be validated.</param>
        private static void Validate(Dictionary<string, string> parsedObject)
        {
            ArgumentNullException.ThrowIfNull(parsedObject);

            if (parsedObject.Keys == null || !parsedObject.ContainsKey(Commands))
            {
                throw new ArgumentException("Commands key not found");
            }

            if (!IsValidCommandString(parsedObject[Commands]))
            {
                throw new ArgumentException("The value associated with the key 'commands' is invalid.");
            }
        }

        /// <summary>
        /// Checks if a command string is valid (non-null and non-empty).
        /// </summary>
        /// <param name="commandString">The command string to be validated.</param>
        /// <returns>True if the command string is valid; otherwise, false.</returns>
        private static bool IsValidCommandString(string commandString)
        {
            return !string.IsNullOrEmpty(commandString);
        }
    }

}
