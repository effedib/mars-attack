using RoverCommandService.src;

namespace RoverCommandService
{
    /// <summary>
    /// Entry point for the program that sets up a simple web application to handle Rover commands.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to configure and run the web application for handling Rover commands.
        /// </summary>
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            var app = builder.Build();

            app.MapPost("/commandrover", async (HttpContext httpContext) =>
            {
                string commandJson = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

                return new MoveRover(commandJson.ToLower()).ExecuteCommands();
            });

            app.Run();
        }
    }
}
