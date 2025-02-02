using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace RobotControl.Tests
{
    public class RobotTests
    {
        private Dictionary<char, int> cardinalDirections = new Dictionary<char, int>
        {
            { 'N', 1 },
            { 'E', 2 },
            { 'S', 3 },
            { 'W', 4 }
        };

        [Fact]
        public void Constructor_ShouldInitializeRobot()
        {
            // Arrange
            string[] position = { "0", "0", "N" };
            Surface floor = new Surface(new[] { "5", "5" });

            // Act
            Robot robot = new Robot(position, floor);

            // Assert
            Assert.Equal("0 0 N", robot.ReportPosition());
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenPositionLengthIsLessThan3()
        {
            // Arrange
            string[] position = { "0", "0" };
            Surface floor = new Surface(new[] { "5", "5" });

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Robot(position, floor));
            Assert.Equal("To initialise a robot, provide three values", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenCardinalDirectionIsInvalid()
        {
            // Arrange
            string[] position = { "0", "0", "X" };
            Surface floor = new Surface(new[] { "5", "5" });

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Robot(position, floor));
            Assert.Equal("X is not a valid cardinal direction", exception.Message);
        }

        [Fact]
        public void TurnLeft_ShouldUpdateRotation()
        {
            // Arrange
            string[] position = { "0", "0", "N" };
            Surface floor = new Surface(new[] { "5", "5" });
            Robot robot = new Robot(position, floor);

            // Act
            robot.TurnLeft();

            // Assert
            Assert.Equal("0 0 W", robot.ReportPosition());
        }

        [Fact]
        public void TurnRight_ShouldUpdateRotation()
        {
            // Arrange
            string[] position = { "0", "0", "N" };
            Surface floor = new Surface(new[] { "5", "5" });
            Robot robot = new Robot(position, floor);

            // Act
            robot.TurnRight();

            // Assert
            Assert.Equal("0 0 E", robot.ReportPosition());
        }

        [Fact]
        public void MoveForward_ShouldUpdatePosition()
        {
            // Arrange
            string[] position = { "0", "0", "N" };
            Surface floor = new Surface(new[] { "5", "5" });
            Robot robot = new Robot(position, floor);

            // Act
            robot.MoveForward();

            // Assert
            Assert.Equal("0 1 N", robot.ReportPosition());
        }

        [Fact]
        public void GetPosition_ShouldReturnCurrentPosition()
        {
            // Arrange
            string[] position = { "0", "0", "N" };
            Surface floor = new Surface(new[] { "5", "5" });
            Robot robot = new Robot(position, floor);

            // Act
            string result = robot.GetPosition();

            // Assert
            Assert.Equal("0 0", result);
        }
    }
}
