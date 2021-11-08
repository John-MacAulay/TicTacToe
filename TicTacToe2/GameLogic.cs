using System;
using System.Collections.Generic;

namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;
        private readonly Board _board;
        private readonly List<Player> _players;
        private bool _isPlayerOneTurn = false;


        public GameLogic(IView view =null)
        {
            _view = view ?? new View();
            _board = new Board();
            var listPLayers = new Players();
            _players = listPLayers._players;

        }

        public void PlayTicTacToe()
        {
           _view.PrintText(" Welcome to Tic Tac Toe!");
           _view.PrintText("\n Here's the current board:");
           _view.PrintText(_board.Show());
           
        }

        public void NewRound()
        {
            _view.PrintText(" Player 1 enter a coord x,y to place your X or enter 'q' to give up:");
            var positionToPlay = _view.GetText();
            if (positionToPlay.ToLower() == "q")
            {
                _view.PrintText(" Game over.");
            }
            // I want something to validate the text as a valid position or ask for re-entry of data 
            var isValidPosition = CheckValidPosition(positionToPlay);
        }

        public bool CheckValidPosition(string positionToPlay)
        {
            var splitStringArray = positionToPlay.Split(",");
            if (splitStringArray.Length != 2)
            {
                return false;
            }
            int posnX;
            int posnY;
            var positionXValid = Int32.TryParse(splitStringArray[0], out posnX);
            var positionYValid = Int32.TryParse(splitStringArray[1], out posnY);
            if (positionXValid && positionYValid && posnX is >= 0 and <= 2 && posnY is >= 0 and <= 2)
            {
            return true;
                
            }

            return false;
        }
    }
}
