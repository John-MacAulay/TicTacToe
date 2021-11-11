using System.Collections.Generic;
using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class GameLogicTests
    {
        /*[Fact]
        public void PlayTicToe_WillShowGreetingAndBlankBoardOnNewGame()
        {
            // Arrange
            var testView = new TestView(new[] {"q"});
            var gameLogic = new GameLogic(testView);
            gameLogic.PlayTicTacToe();

            // Act //Assert
            Assert.Equal(" Welcome to Tic Tac Toe!", testView.FakeOutput[0]);
            Assert.Equal("\n Here's the current board:", testView.FakeOutput[1]);
          //  Assert.Equal($"   0 1 2\n 0 . . .\n 1 . . .\n 2 . . .\n", testView.FakeOutput[2]);
        }*/

        [Fact]
        public void NewRound_shouldPromptForPlayerInput()
        {
            // Arrange
            var testView = new TestView(new[] {"q"});
            var gameLogic = new GameLogic(testView);
            var player = new Player("Player 1", "X");

            gameLogic.NewRound(player);

            // Act // Assert
            Assert.Equal(" Player 1 enter a coord x,y to place your X or enter 'q' to give up:",
                testView.FakeOutput[0]);
        }

        public static IEnumerable<object[]> GetInputs()
        {
            yield return new object[]
            {
                 "1,0", new GridPosition(1, 0)
            }; 
            yield return new object[]
            {
                "0,4", new GridPosition(-1, -1)
            }; 
            yield return new object[]
            {
                "0,-1", new GridPosition(-1, -1)
            }; 
            yield return new object[]
            {
                "4,2", new GridPosition(-1, -1)
            }; 
            yield return new object[]
            {
                "2,0", new GridPosition(2, 0)
            }; 
            
        }

        [Theory]
        [MemberData(nameof(GetInputs))]
        public void GetPositionToPlay_GivenNewValuesAsInputUntilPositionIsValid_ThenReturnFirstValidPosition(
            string input, GridPosition expected) 
        {
            // Arrange
            var testView = new TestView(new []{""});
            var gameLogic = new GameLogic(testView);
            var player = new Player("Player 1", "X");

            // Act
            var actual =gameLogic.GetValidPosition(input);

            // Assert
             Assert.Equal(expected, actual);
        }
    }
}
