namespace TicTacToe2
{
    public class Board
    {
        public char[,] CurrentBoardState { get; init; }

        public Board()
        {
            CurrentBoardState = new char [3, 3]
            {
                {'.', '.', '.'},
                {'.', '.', '.'},
                {'.', '.', '.'},
            };
        }

        public string Show()
        {
            return $" {CurrentBoardState[0, 0]} {CurrentBoardState[0, 1]} {CurrentBoardState[0, 2]}\n" +
                   $" {CurrentBoardState[1, 0]} {CurrentBoardState[1, 1]} {CurrentBoardState[1, 2]}\n" +
                   $" {CurrentBoardState[2, 0]} {CurrentBoardState[2, 1]} {CurrentBoardState[2, 2]}\n";
        }
    }
    
}
