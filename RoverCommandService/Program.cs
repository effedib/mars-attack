
using RoverCommandService.src;

namespace RoverCommandService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var rover = Rover.Instance;
            app.MapPost("/commandrover", async (HttpContext httpContext) =>
            {
                string commandString = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
                char[] commands = commandString.ToCharArray();

                rover.ShowMap();

                rover.ReceiveCommands(commands);

                string obstacle = "";
                if (rover.FoundObstacle)
                {
                    obstacle = "Obstacle detected!";
                }
                else
                {
                    obstacle = "No obstacle detected!";
                }
                string result = obstacle + $"\nCurrent position: ({rover.Location.X}, {rover.Location.Y})\nCurrent direction: {rover.Location.Direction}";
                return result;
            })
            .WithName("SendCommandsRover")
            .WithOpenApi();

            app.Run();
        }
    }
}
