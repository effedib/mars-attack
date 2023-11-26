using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        [Fact]
        public void ParseJson_InvalidJson()
        {
            const string jsonString = "invalidJson";

            var result = CommandJsonParser.ParseJson(jsonString);

            Assert.Null(result);
        }

        [Fact]
        public void ParseJson_EmptyJsonString()
        {
            const string jsonString = "";

            var result = CommandJsonParser.ParseJson(jsonString);

            Assert.Null(result);
        }
    }
}