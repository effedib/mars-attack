using System;
using System.IO;
using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData('f', Directions.N, 0, 0, 0, 1, Directions.N)]
        [InlineData('b', Directions.N, 5, 5, 5, 4, Directions.N)]
        [InlineData('r', Directions.N, 0, 0, 0, 0, Directions.E)]
        [InlineData('l', Directions.N, 0, 0, 0, 0, Directions.W)]
        public void ReceiveCommands_UpdateDirectionLocationCorrectly(
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