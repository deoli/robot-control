using System;
using Xunit;

namespace RobotControl.Tests
{
    public class SurfaceTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCoordinates()
        {
            // Arrange
            string[] coordinates = { "5", "10" };

            // Act
            Surface surface = new Surface(coordinates);

            // Assert
            Assert.Equal(5, surface.X);
            Assert.Equal(10, surface.Y);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenCoordinatesLengthIsLessThan2()
        {
            // Arrange
            string[] coordinates = { "5" };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Surface(coordinates));
            Assert.Equal("To define a surface, provide two vales", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenCoordinatesAreInvalid()
        {
            // Arrange
            string[] coordinates = { "invalid", "10" };

            // Act & Assert
            Assert.Throws<FormatException>(() => new Surface(coordinates));
        }
    }
}
