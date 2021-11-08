using System;
using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class GameLogicTests
    {
        [Fact]
        public void PlayTicToe_WillShowGreetingANdBlankBoardOnNewGame()
        {
            // Arrange
            var testView = new TestView(new[] {""});
            var gameLogic = new GameLogic(testView);
            gameLogic.PlayTicTacToe();

            // Act //Assert
            Assert.Equal(" Welcome to Tic Tac Toe!", testView.FakeOutput[0]);
            Assert.Equal("\n Here's the current board:", testView.FakeOutput[1]);
            Assert.Equal($" . . .\n . . .\n . . .\n", testView.FakeOutput[2]);
        }

        [Fact]
        public void NewRound_shouldPromptForPlayerInput()
        {
            // Arrange
            var testView = new TestView(new[] {"q"});
            var gameLogic = new GameLogic(testView);
            
            gameLogic.NewRound();
            
            // Act // Assert
            Assert.Equal(" Player 1 enter a coord x,y to place your X or enter 'q' to give up:",
                testView.FakeOutput[0]);
            Assert.Equal(" Game over.", testView.FakeOutput[1]);
        }


        [Theory]
        [InlineData("some invalid position", false, "non splittable string")]
        [InlineData("0,4", false, "splittable string, invalid position for y parameter")]
        [InlineData("0,-1", false, "splittable string, invalid position for y parameter")]
        [InlineData("4,2", false, "splittable string, invalid position for x parameter")]
        [InlineData("-1,2", false, "splittable string, invalid position for x parameter")]
        [InlineData("0,1", true, "splittable string, valid position")]
        [InlineData("1,1", true, "splittable string, valid position")]
        [InlineData("2,1", true, "splittable string, valid position")]
        [InlineData("2,0", true, "splittable string, valid position")]
        [InlineData("2,2", true, "splittable string, valid position")]
        public void CheckValidPosition_shouldOnlyReturnValidPositions(string position, bool expected, string description)
        {
            // Arrange
            var testView = new TestView(new[] {position});
            var gameLogic = new GameLogic(testView);
            
            // Act
           var actual = gameLogic.CheckValidPosition(position);
           
           // Assert
           Assert.True(expected == actual, description);
        }
    }
}
