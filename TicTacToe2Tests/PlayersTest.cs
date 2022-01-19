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
        public void GivenAPlayersWithOnePlayer_GetPlayer_ReturnsAPlayer()
        {
            // Arrange 
            var players = new Players();
            players.AddPlayer(new Player("Player One","X"));
            var player = players.GetPlayer(1);
            
            // Act
            Assert.IsType<Player>(player);
        }

        [Fact]
        public void GivenANewPlayerClass_WhenAddingPlayer()
        {
            // Arrange
            var players = new Players();
            var playerToAdd = new Player("Sam", "X");
            players.AddPlayer(playerToAdd);
            
            // Act 
            var actual = players.GetPlayer(1);
            
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
        public void GivenABlankPlayers_WhenTwoPlayersAreAdded_GetPLayerShouldReturnPlayersAccordingToTheirIndicesInList()
        {
            // Arrange 
            var players = new Players();
            var playerOne = new Player("Player One", "X");
            var playerTwo = new Player("Player Two", "O");
            players.AddPlayer(playerOne);
            players.AddPlayer((playerTwo));
            
            // Act 

            // Assert
            var expected = players.GetPlayer(2);
            Assert.Equal(expected,playerTwo);
            
            
        }
    }
}
