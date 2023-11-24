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
            var planetMap = new PlanetMap(7, 9);
            var rover = new Rover(0, 0, Directions.N, planetMap);
            var expectedOutput = "Generating Map...";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                rover.ShowMap();
                var output = sw.ToString().Trim();

                Assert.Contains(expectedOutput, output);
            }
        }

        [Theory]
        [InlineData('f', Directions.N, 0, 0, 0, 1, Directions.N)]
        [InlineData('b', Directions.N, 5, 5, 5, 4, Directions.N)]
        [InlineData('r', Directions.N, 0, 0, 0, 0, Directions.E)]
        [InlineData('l', Directions.N, 0, 0, 0, 0, Directions.W)]
        public void ReceiveCommands_UpdateLocationCorrectly(
            char command, Directions initialDirection, int initialX, int initialY,
            int expectedX, int expectedY, Directions expectedDirection)
        {
            var planetMap = new PlanetMap(10, 10);
            var rover = new Rover(initialX, initialY, initialDirection, planetMap);

            rover.ReceiveCommands([command]);

            bool obstacleDetected = rover.FoundObstacle;

            if (obstacleDetected)
            {
                Assert.Equal(initialX, rover.Location.X);
                Assert.Equal(initialY, rover.Location.Y);
                Assert.Equal(initialDirection, rover.Location.Direction);
            }
            else
            {
                Assert.Equal(expectedX, rover.Location.X);
                Assert.Equal(expectedY, rover.Location.Y);
                Assert.Equal(expectedDirection, rover.Location.Direction);
            }
        }
    }
}