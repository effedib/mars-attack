using Microsoft.AspNetCore.Mvc.Testing;
using RoverCommandService.src;
using System.Net.Http.Json;
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

            var commandsJson = new { commands = "bbbfffflbfllffb" };

            var response = await client.PostAsJsonAsync("/commandrover", commandsJson);

            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task SendCommands_ReturnsBadRequestMessage_NoJsonFormat()
        {
            var client = _factory.CreateClient();

            const string commands = "bbbfffflbfllffb";

            var content = new StringContent(commands, Encoding.UTF8, "text/plain");

            var response = await client.PostAsync("/commandrover", content);

            response.StatusCode.Equals(false);
        }

        [Theory]
        [InlineData("")]
        [InlineData("aaa")]
        [InlineData("123")]
        public async Task SendCommands_ReturnsBadRequestMessage(string value)
        {
            var client = _factory.CreateClient();

            var commandsJson = new { commands = value };

            var response = await client.PostAsJsonAsync("/commandrover", commandsJson);

            response.StatusCode.Equals(false);
        }
    }
}