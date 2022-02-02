using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class GameLogicTests
    {

        [Fact]
        public void NewRound_shouldPromptForPlayerInput()
        {
            // Arrange
            var testView = new TestView(new[] {"q"});
            var gameLogic = new GameLogic(testView);
            var player = new Player("Player 1", "X");
            gameLogic.SetUpStandardPlayerNames();
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
        public void GetValidPosition_GivenCommaSeperatedStringValues_ReturnGridPositionObject(
            string input, GridPosition expected) 
        {
            // Arrange
            var testView = new TestView(new []{""});
            var gameLogic = new GameLogic(testView);

            // Act
            var actual =gameLogic.ValidatePosition(input);

            // Assert
             Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0,0","   0 1 2\n 0 X . .\n 1 . . .\n 2 . . .\n")]
        [InlineData("0,1","   0 1 2\n 0 . X .\n 1 . . .\n 2 . . .\n")]
        [InlineData("0,2","   0 1 2\n 0 . . X\n 1 . . .\n 2 . . .\n")]
        [InlineData("1,0","   0 1 2\n 0 . . .\n 1 X . .\n 2 . . .\n")]
        [InlineData("1,1","   0 1 2\n 0 . . .\n 1 . X .\n 2 . . .\n")]
        [InlineData("1,2","   0 1 2\n 0 . . .\n 1 . . X\n 2 . . .\n")]
        [InlineData("2,0","   0 1 2\n 0 . . .\n 1 . . .\n 2 X . .\n")]
        [InlineData("2,1","   0 1 2\n 0 . . .\n 1 . . .\n 2 . X .\n")]
        [InlineData("2,2","   0 1 2\n 0 . . .\n 1 . . .\n 2 . . X\n")]
        public void WhenGivenANewBoardAndValidInputs_GetPositionToPlay_ShouldUpdateBoardWithCorrectMark(string input,string expected)
        {
            // Arrange
            var testView = new TestView(new[] {""});
            var gameLogic = new GameLogic(testView);
            var player = new Player("Player 1", "X");
            gameLogic.GetPositionToPlay(input,player);
            gameLogic.Board.CurrentBoardState[2, 2] = "O";

            //Act
            var actual = testView.FakeOutput[0];
            //Assert
            Assert.Equal(expected,actual);
            
        }
        [Theory]
        [InlineData(0,0,0,1,2,2,"Player One","X","It's a draw.")]
        
        [InlineData(0,0,0,1,0,2,"Player One","X","Player One has won!")]
        
        [InlineData(1,0,1,1,1,2,"Player Two","O","Player Two has won!")]
        [InlineData(2,0,2,1,2,2,"Player Two","O","Player Two has won!")]
        
        public void GivenABoard_CheckPlayerWon_shouldReturnCorrectWinner(
            int firstXGridCoordinate, int firstYGridCoordinate,
            int secondXGridCoordinate, int secondYGridCoordinate,
            int thirdXGridCoordinate, int thirdYGridCoordinate,
            string playerName, string playerMark,
            string expected
            )
        {

            var testView = new TestView(new[] {""});
            var gameLogic = new GameLogic(testView);
            var player = new Player(playerName,playerMark);
            gameLogic.Board.CurrentBoardState[firstXGridCoordinate, firstYGridCoordinate] = playerMark;
            gameLogic.Board.CurrentBoardState[secondXGridCoordinate, secondYGridCoordinate] = playerMark;
            gameLogic.Board.CurrentBoardState[thirdXGridCoordinate, thirdYGridCoordinate] = playerMark;
            gameLogic.CheckPlayerWon(player);
            gameLogic.DisplayResultOfGame();
            var actual = testView.FakeOutput[0];
            
            Assert.Equal(expected, actual);
        }
    }
    
}
