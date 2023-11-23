using System;
using System.IO;
using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class RoverTests
    {
        [Fact]
        public void ReceiveCommands_SingleCommand_MoveRoverCalled()
        {
            var planetMap = new PlanetMap(10, 15);
            var rover = new Rover(0, 0, Directions.N, planetMap);
            var commands = new char[] { 'f' };
            string commandsString = new(commands.ToArray());
            var expectedOutput = $"Commands received: {commandsString}\n\r\nRoad clean, no obstacle detected\r\nnew Point = 0,1";
            var alternativeOutput = $"Commands received: {commandsString}\n\r\nObstacle detected, STOP!";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                rover.ReceiveCommands(commands);
                var output = sw.ToString().Trim();

                Assert.True(expectedOutput == output || alternativeOutput == output);
                
            }
        }

        [Fact]
        public void ShowMap_WhenCalled_OutputContainsGeneratingMap()
        {
            // Arrange
            var planetMap = new PlanetMap(7, 9);
            var rover = new Rover(0, 0, Directions.N, planetMap);
            var expectedOutput = "Generating Map...";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                rover.ShowMap();
                var output = sw.ToString().Trim();

                // Assert
                Assert.Contains(expectedOutput, output);
            }
        }
    }
}