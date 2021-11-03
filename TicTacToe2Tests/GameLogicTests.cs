using System;
using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayTicToe_WillShowGreetingOnNewGame()
        {
            // Assert 
            var testView = new TestView(new []{""});
            var gameLogic = new GameLogic();

            // Act
            gameLogic.PlayYatzy();
            Assert.Equal("Welcome to Tic Tac Toe!",testView.FakeOutput[0]);
        }
    }
}
