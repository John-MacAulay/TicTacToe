using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class PlayersTest
    {
        [Fact]
        public void CheckANewPlayersShouldBeEmptyTest()
        {
            // Arrange
            var players = new Players();
            var actual = players.IsEmpty;
            
            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void GivenANewPlayerClass_WhenAddPlayer_PlayersIsEmptyEqualsFalse()
        {
            // Arrange 
            var players = new Players();
            var playerToAdd = new Player("Sam", "?");
            players.AddPlayer(playerToAdd);
            
            // Act
            var actual = players.IsEmpty;
            
            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void GivenAPlayersWithOnePlayer_GetCurrentPlayer_ReturnsTheExpectedPlayer()
        {
            // Arrange 
            var players = new Players(); 
            var expectedPlayer = new Player("Player One","X");
            players.AddPlayer(expectedPlayer);
            var actualPlayer = players.GetCurrentPlayer();
            
            // Act
            Assert.Equal(expectedPlayer,actualPlayer);
        }

        [Fact]
        public void GivenANewPlayersClass_WhenWeAddPlayer_ThenGetPlayerShouldReturnThisPlayer()
        {
            // Arrange
            var players = new Players();
            var playerToAdd = new Player("Sam", "X");
            players.AddPlayer(playerToAdd);
            
            // Act 
            var actual = players.GetCurrentPlayer();
            
            // Assert
            Assert.Equal(playerToAdd,actual);
        }
        [Fact]
        public void GivenABlankPlayers_WhenTwoPlayersAreAdded_PlayerCountShouldBeEqualToTotalNumberOfPlayersAdded()
        {
            // Arrange 
            var players = new Players();
            var playerOne = new Player("Player One", "X");
            var playerTwo = new Player("Player Two", "O");
            players.AddPlayer(playerOne);
            players.AddPlayer((playerTwo));
            
            // Act 
            var actual = players.Count();
            
            // Assert
            const int expected = 2;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void GivenABlankPlayers_WhenTwoPlayersAreAdded_GetPLayerShouldReturnFirstPlayer()
        {
            // Arrange 
            var players = new Players();
            var playerOne = new Player("Player One", "X");
            var playerTwo = new Player("Player Two", "O");
            players.AddPlayer(playerOne);
            players.AddPlayer(playerTwo);

            // Act 
            var actual = players.GetCurrentPlayer();

            // Assert
           
            var expected = playerOne;
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void GivenANewPlayersAndAddingTwoPlayers_WhenAdvanceToNextPLayer_ThenGetCurrentPLayerWillReturnPlayerTwo()
        {
            // Arrange 
            var players = new Players();
            var playerOne = new Player("Player One", "X");
            var playerTwo = new Player("Player Two", "O");
            players.AddPlayer(playerOne);
            players.AddPlayer(playerTwo);
            players.AdvanceToNextPlayer();
            
            // Act 
            var actual = players.GetCurrentPlayer();
            
            // Assert
            var expected = playerTwo;
            Assert.Equal(expected,actual);
            
        }

        [Fact]
        public void GivenABlankNewPlayerAndAddingTwoPLayers_ThenMultipleAdvancePlayers_CurrentPlayerPointerNeverPointsToNonExistentPlayer()
        {
            // Arrange 
            var players = new Players();
            var playerOne = new Player("Player One", "X");
            var playerTwo = new Player("Player Two", "O");
            players.AddPlayer(playerOne);
            players.AddPlayer(playerTwo);
            players.AdvanceToNextPlayer();
            players.AdvanceToNextPlayer();
            players.AdvanceToNextPlayer();
            players.AdvanceToNextPlayer();
            
            // Act 
            var actual = players.GetCurrentPlayer();
            
            // Assert
            var expected = playerOne;
            Assert.Equal(expected,actual);
        }
    }
}
