

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

            app.MapPost("/commandrover", async (HttpContext httpContext) =>
            {
                string commandString = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
                char[] commands = commandString.ToCharArray();

                PlanetMap planetMap = new(10, 10);
                Rover rover = new(0, 0, Directions.N, planetMap);
                rover.ShowMap();

                // use test commands
                rover.ReceiveCommands(commands);

                return "Commands received and successfully executed!";
            })
            .WithName("SendCommandsRover")
            .WithOpenApi();


            app.Run();
        }
    }
}
