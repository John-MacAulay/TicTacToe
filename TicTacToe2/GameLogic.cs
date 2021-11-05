namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;
        private readonly Board _board;
        private readonly Players _players;


        public GameLogic(IView view =null)
        {
            _view = view ?? new View();
            _board = new Board();
            _players = new Players();
        }

        public void PlayTicTacToe()
        {
           _view.PrintText(" Welcome to Tic Tac Toe!");
           _view.PrintText("\n Here's the current board:");
           _view.PrintText(_board.Show());
           
        }

        public void NewRound()
        {
            
        }
    }
}
