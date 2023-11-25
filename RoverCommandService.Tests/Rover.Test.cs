using System;
using System.IO;
using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData('f', 0, 1, Directions.N)]
        [InlineData('b', 0, 9, Directions.N)]
        [InlineData('r', 0, 0, Directions.E)]
        [InlineData('l', 0, 0, Directions.W)]
        public void ReceiveCommands_UpdateDirectionLocationCorrectly(char command, int expectedX, int expectedY,
                                                                     Directions expectedDirection)
        {
            var rover = Rover.Instance;
            rover.Reset();

            rover.ReceiveCommands([command]);

            bool obstacleDetected = rover.FoundObstacle;

            if (obstacleDetected)
            {
                Assert.Equal(0, rover.Location.X);
                Assert.Equal(0, rover.Location.Y);
                Assert.Equal(Directions.N, rover.Location.Direction);
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