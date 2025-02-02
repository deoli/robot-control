using System;
using Xunit;

namespace RobotControl.Tests
{
    public class InputTests
    {
        [Fact]
        public void Parse_ShouldThrowException_WhenCommandIsNull()
        {
            // Arrange
            var input = new Input { command = null };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => input.Parse());
            Assert.Equal("Please provide a command", exception.Message);
        }

        [Fact]
        public void Parse_ShouldThrowException_WhenCommandIsEmpty()
        {
            // Arrange
            var input = new Input { command = "" };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => input.Parse());
            Assert.Equal("Please provide a command", exception.Message);
        }

        [Fact]
        public void Parse_ShouldThrowException_WhenCommandIsWhitespace()
        {
            // Arrange
            var input = new Input { command = "    " };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => input.Parse());
            Assert.Equal("Please provide a command", exception.Message);
        }

        [Fact]
        public void Parse_ShouldReturnArray_WhenCommandIsValid()
        {
            // Arrange
            var input = new Input { command = "Line1\\nLine2\\nLine3" };

            // Act
            var result = input.Parse();

            // Assert
            Assert.Equal(new[] { "Line1", "Line2", "Line3" }, result);
        }
    }
}
