
using Newtonsoft.Json;

namespace RoverCommandService.src
{
    public static class CommandJsonParser
    {
        public static readonly string Commands = "commands";

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
                return null;
            }
        }

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

        private static bool IsValidCommandString(string commandString)
        {
            return !string.IsNullOrEmpty(commandString);
        }
    }

}
