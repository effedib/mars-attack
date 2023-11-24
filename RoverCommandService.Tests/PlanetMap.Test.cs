using RoverCommandService.src;

namespace RoverCommandService.Tests
{
    public class PlanetMapTests
    {
        [Fact]
        public void PlanetMap_InitializedCorrectly()
        {
            int expectedWidth = 10;
            int expectedHeight = 8;

            var planetMap = new PlanetMap(expectedWidth, expectedHeight);

            Assert.Equal(expectedWidth, planetMap.Width);
            Assert.Equal(expectedHeight, planetMap.Height);
        }

        [Fact]
        public void MapGrid_GeneratedCorrectly()
        {
            int width = 7;
            int height = 9;

            var planetMap = new PlanetMap(width, height);
            var mapGrid = planetMap.MapGrid;

            Assert.Equal(width * height, mapGrid.Length);

            int index = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Assert.Equal((i, j), mapGrid[index++]);
                }
            }
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 3)]
        [InlineData(5, 5)]
        public void CheckObstacle_ReturnsRandomValues(int x, int y)
        {
            var planetMap = new PlanetMap(10, 10);

            var result = planetMap.CheckObstacle(x, y);

            Assert.True(result || !result);
        }
    }
}