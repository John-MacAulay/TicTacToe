namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;

        public GameLogic(IView view =null)
        {
            _view = view ?? new View(); 
        }

        public void PlayYatzy()
        {
            throw new System.NotImplementedException();
        }
    }
}
