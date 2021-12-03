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
            Assert.Equal($"   0 1 2\n 0 . . .\n 1 . . .\n 2 . . .\n",actual);
            
            
        }
    }
}
