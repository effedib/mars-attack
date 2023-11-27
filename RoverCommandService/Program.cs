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

                var result = new MoveRover(commandJson.ToLower()).ExecuteCommands();

                if (result == "No commands received")
                {
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsync(result);
                    return;
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    await httpContext.Response.WriteAsync(result);
                    return;
                }

            });

            app.Run();
        }
    }
}
