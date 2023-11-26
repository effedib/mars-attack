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
                string commandJson = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

                return new MoveRover(commandJson.ToLower()).ExecuteCommands();
            })
            .WithName("SendCommandsRover")
            .WithOpenApi();

            app.Run();
        }
    }
}
