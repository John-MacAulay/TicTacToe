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
            var player = players.GetPlayer();
            
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
            var actual = players.GetPlayer();
            
            // Assert
            var expected = playerToAdd;
            Assert.Equal(expected,actual);
        }
        
        /// do multi players
        /// retrieve one of a number of Players
        /// 
    }
}
