

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

            var commands = new[]
            {
                //'f','f','f','l','b','l','f','f','r','f'
                'b','b','b','f','f','f','f','l','b','f','l','l','f','f','b'
            };

            app.MapGet("/commandrover", (HttpContext httpContext) =>
            {
                PlanetMap planetMap = new(10, 10);
                Rover rover = new(0, 0, Directions.N, planetMap);
                rover.ShowMap();
                rover.ReceiveCommands(commands);
            })
            .WithName("SendCommandsRover")
            .WithOpenApi();

            app.Run();
        }
    }
}
