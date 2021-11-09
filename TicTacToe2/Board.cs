namespace TicTacToe2
{
    public class Board
    {
        public string[,] CurrentBoardState { get; init; }

        public Board()
        {
            CurrentBoardState = new string [3, 3]
            {
                {".", ".", "."},
                {".", ".", "."},
                {".", ".", "."},
            };
        }

        public string Show()
        {
            return $"   0 1 2\n" +
                   $" 0 {CurrentBoardState[0, 0]} {CurrentBoardState[0, 1]} {CurrentBoardState[0, 2]}\n" +
                   $" 1 {CurrentBoardState[1, 0]} {CurrentBoardState[1, 1]} {CurrentBoardState[1, 2]}\n" +
                   $" 2 {CurrentBoardState[2, 0]} {CurrentBoardState[2, 1]} {CurrentBoardState[2, 2]}\n";
        }
    }
    
}
