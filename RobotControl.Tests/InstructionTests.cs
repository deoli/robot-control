using System;
using Xunit;

namespace RobotControl.Tests
{
    public class InstructionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeInstructions()
        {
            // Arrange
            char[] instructionsArray = { 'A', 'B', 'C' };

            // Act
            Instruction instruction = new Instruction(instructionsArray);

            // Assert
            Assert.Equal(instructionsArray, instruction.GetInstructions());
        }

        [Fact]
        public void GetInstructions_ShouldReturnInstructions()
        {
            // Arrange
            char[] instructionsArray = { 'X', 'Y', 'Z' };
            Instruction instruction = new Instruction(instructionsArray);

            // Act
            char[] result = instruction.GetInstructions();

            // Assert
            Assert.Equal(instructionsArray, result);
        }
    }
}
