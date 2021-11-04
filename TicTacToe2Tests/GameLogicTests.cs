using System;
using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class GameLogicTests
    {
        [Fact]
        public void PlayTicToe_WillShowGreetingOnNewGame()
        {
            // Assert 
            var testView = new TestView(new []{""});
            var gameLogic = new GameLogic(testView);

            // Act
            gameLogic.PlayTicTacToe();
            Assert.Equal(" Welcome to Tic Tac Toe!",testView.FakeOutput[0]);
            Assert.Equal("\n Here's the current board:", testView.FakeOutput[1]);
        }

        public void ShowBoard_WillShowABlankBoard_WhenNewlyInstantiated()
        {
            var testView = new TestView(new []{""});
            var gameLogic = new GameLogic(testView);
            
        }
    }
}
