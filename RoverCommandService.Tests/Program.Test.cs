using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RoverCommandService.src;
using System.Text;

namespace RoverCommandService.Tests
{
    public class RoverApiTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory = factory;

        [Fact]
        public async Task SendCommands_ReturnsSuccessMessage()
        {
            _factory.WithWebHostBuilder(builder =>
            {
                builder.Build().Run();
            });

            var client = _factory.CreateClient();

            var commands = "bbbfffflbfllffb";

            var content = new StringContent(commands, Encoding.UTF8, "text/plain");

            var response = await client.PostAsync("/commandrover", content);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Commands received and successfully executed!", responseString);
        }
    }
}