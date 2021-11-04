namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;
        private readonly Board _board;


        public GameLogic(IView view =null)
        {
            _view = view ?? new View();
            _board = new Board();
        }

        public void PlayTicTacToe()
        {
           _view.PrintText(" Welcome to Tic Tac Toe!");
           _view.PrintText("\n Here's the current board:");
           _view.PrintText(_board.Show());
           
        }
    }
}
