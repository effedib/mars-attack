using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class PointTests
    {
        [Fact]
        public void Point_InitializedCorrectly()
        {
            // Arrange
            int expectedX = 5;
            int expectedY = 10;
            Directions expectedDirection = Directions.E;

            // Act
            var point = new Point(expectedX, expectedY, expectedDirection);

            // Assert
            Assert.Equal(expectedX, point.X);
            Assert.Equal(expectedY, point.Y);
            Assert.Equal(expectedDirection, point.Direction);
        }

        [Fact]
        public void Point_DefaultValues()
        {
            // Arrange & Act
            var point = new Point(0, 0, Directions.N); // Creating a Point with default values

            // Assert
            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
            Assert.Equal(Directions.N, point.Direction);
        }
    }
}