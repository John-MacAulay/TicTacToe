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
            var testView = new TestView(new[] {"q"});
            var gameLogic = new GameLogic(testView);
            gameLogic.PlayTicTacToe();

            // Act //Assert
            Assert.Equal(" Welcome to Tic Tac Toe!", testView.FakeOutput[0]);
            Assert.Equal("\n Here's the current board:", testView.FakeOutput[1]);
            Assert.Equal($"   0 1 2\n 0 . . .\n 1 . . .\n 2 . . .\n", testView.FakeOutput[2]);
        }

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
           Assert.Equal(" Game over.", testView.FakeOutput[1]);
        }
        
        [Theory]
        [InlineData(new []{"some invalid position","1,0"},"(1, 0)", "non splittable string first then valid parameters")]
        [InlineData(new []{"0,4","0,1"},"(0, 1)", "invalid position for column parameter then valid parameters")]
        [InlineData(new []{"0,-1","0,1"},"(0, 1)", "invalid position for column parameter then valid parameters")]  
        [InlineData(new []{"4,2","0,2"}, "(0, 2)", "invalid position for row parameter, then valid parameters")]  
        [InlineData(new []{"-1,2","2,0"}, "(2, 0)", "invalid position for row parameter, then valid parameters")]
 
        [InlineData(new []{"0,1", "0,2"}, "(0, 1)", "splittable string, valid 1st set of parameters")]
        [InlineData(new []{"1,1"}, "(1, 1)", "splittable string, valid parameters")] 
        [InlineData(new []{"0,2"}, "(0, 2)", "splittable string, valid parameters")]
        [InlineData(new []{"2,0"}, "(2, 0)", "splittable string, valid parameters")]
        [InlineData(new []{"2,2"}, "(2, 2)", "splittable string, valid parameters")]
        
        [InlineData(new []{"2,2", "1,1"}, "(2, 2)", "both entries valid parameters, only first returned")]
        
        // Ok although this is a clear TDD test; I still think it sucks because it would be better to have position
        // as a class and then test position parameters - still need to research testing objects in XUnit 
     public void GetPositionToPlay_GivenNewValuesAsInputUntilPositionIsValid_ThenReturnFirstValidPosition(string[] position, string expected, string description)
                 {
            // Arrange
            var testView = new TestView(position);
            var gameLogic = new GameLogic(testView);
            
            // Act
               var actual = gameLogic.GetPositionToPlay().ToString();
           
           // Assert
           Assert.True(expected == actual,description);
        }
    }
}
