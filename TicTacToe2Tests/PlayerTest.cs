using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Player_ShouldHaveMark()
        {
            // Arrange 
            var player = new Player("x");

            // Act
            var actual = player.Mark;

            // Assert
            Assert.Equal("x",actual);
        }
    }
}
