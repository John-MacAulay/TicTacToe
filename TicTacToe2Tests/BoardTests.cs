using TicTacToe2;
using Xunit;

namespace TicTacToe2Tests
{
    public class BoardTests
    {
        [Fact]
        public void ShowBoard_WillReturnABlankBoardAsString_WhenNewlyInstantiated()
        {
            // Arrange
            var board = new Board();
            
            // Act
            var actual = board.Show();
            
            // Assert
            Assert.Equal($" . . .\n . . .\n . . .\n",actual);
        }
    }
}
