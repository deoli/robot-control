using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace RobotControl.Tests
{
    public class ControlTests
    {
        [Fact]
        public void Constructor_ShouldInitializeControl()
        {
            // Arrange
            string[] commands = { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

            // Act
            Control control = new Control(commands);

            // Assert
            Assert.Equal("1 3 N\n5 1 E", control.Execute());
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenCommandLengthIsLessThan2()
        {
            // Arrange
            string[] commands = { "5" };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Surface(commands));
            Assert.Equal("To define a surface, provide two vales", exception.Message);
        }

        [Fact]
        public void Execute_ShouldMoveRobotsCorrectly()
        {
            // Arrange
            string[] commands = { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            Control control = new Control(commands);

            // Act
            string result = control.Execute();

            // Assert
            Assert.Equal("1 3 N\n5 1 E", result);
        }

        [Fact]
        public void Execute_ShouldThrowException_OnCollision()
        {
            // Arrange
            string[] commands = { "5 5", "1 2 N", "LMLMLMLMM", "1 3 E", "MMRMMRMRRM" };
            Control control = new Control(commands);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => control.Execute());
            Assert.Equal("Collision detected /!\\", exception.Message);
        }
    }
}
