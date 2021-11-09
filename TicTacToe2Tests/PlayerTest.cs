using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class PlayerTest
    {
        [Theory]
        [InlineData("Player 1","X","X")]
        [InlineData("Player 2","y","y")]
        public void Player_ShouldHaveCorrectMark_assignedinMarkFIeld(string name, string mark, string expected)
        {
            // Arrange 
            var player = new Player(name, mark);

            // Act
            var actual = player.mark;

            // Assert
            Assert.Equal(expected,actual);
        }
    }
}
