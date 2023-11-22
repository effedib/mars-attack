

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
                'f','b','l','r'
            };

            app.MapGet("/commandrover", (HttpContext httpContext) =>
            {
                Rover rover = new(0, 0, 'N');
                rover.ReceiveCommands(commands);
            })
            .WithName("SendCommandsRover")
            .WithOpenApi();

            app.Run();
        }
    }
}
