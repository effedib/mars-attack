using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class CommandJsonParserTests
    {
        [Fact]
        public void ParseJson_ValidJson()
        {
            const string jsonString = "{\"commands\":\"someCommand\"}";

            var result = CommandJsonParser.ParseJson(jsonString);

            Assert.NotNull(result);
            Assert.IsType<Dictionary<string, string>>(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalidJson")]
        [InlineData("{\"\":\"bbbbbb\"}")]
        [InlineData("{\"commands\":\"\"}")]
        public void ParseJson_InvalidJson(string jsonString)
        {
            var result = CommandJsonParser.ParseJson(jsonString);

            Assert.Null(result);
        }
    }
}