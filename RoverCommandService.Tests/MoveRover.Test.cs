using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class MoveRoverTests
    {
        [Fact]
        public void ExecuteCommands_NoCommandJson_ReturnsNoCommandsReceivedMessage()
        {
            MoveRover moveRover = new("");

            var result = moveRover.ExecuteCommands();

            Assert.Equal("No commands received", result);
        }

        [Fact]
        public void ExecuteCommands_ValidCommandJson_ExecutesCommandsAndShowsPosition()
        {
            const string commandJson = "{\"commands\":\"FFRBL\"}";
            MoveRover moveRover = new(commandJson);

            string result = moveRover.ExecuteCommands().ToLower();

            Assert.Contains("obstacle detected", result);
            Assert.Contains("current position", result);
            Assert.Contains("current direction", result);
        }
    }
}