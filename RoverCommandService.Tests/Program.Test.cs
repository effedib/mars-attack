using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;

namespace RoverCommandService.Tests
{
    public class RoverApiTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory = factory;

        [Fact]
        public async Task SendCommands_ReturnsSuccessMessage()
        {
            var client = _factory.CreateClient();

            var commands = "bbbfffflbfllffb";

            var content = new StringContent(commands, Encoding.UTF8, "text/plain");

            var response = await client.PostAsync("/commandrover", content);

            response.EnsureSuccessStatusCode();
        }
    }
}