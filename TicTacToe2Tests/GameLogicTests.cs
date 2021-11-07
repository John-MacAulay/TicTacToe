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
    }
}
