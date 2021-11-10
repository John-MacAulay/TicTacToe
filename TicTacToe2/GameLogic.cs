using System;
using System.Collections.Generic;
using System.Data.Common;

namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;
        private readonly Board _board;
        private readonly List<Player> _players;
        private bool? playerOneWon;

        public GameLogic(IView view = null)
        {
            _view = view ?? new View();
            _board = new Board();
            var listPLayers = new Players();
            _players = listPLayers._players;
            playerOneWon = null;
        }

        public void PlayTicTacToe()
        {
       
            _view.PrintText(" Welcome to Tic Tac Toe!");
            _view.PrintText("\n Here's the current board:");
            _view.PrintText(_board.Show());

            while (playerOneWon == null)
            {
                foreach (var player in _players)
                {
                    if (playerOneWon == null)
                    {
                        NewRound(player);
                    }
                }
            }
        }

        public void NewRound(Player player)
        {
            _view.PrintText($" {player.name} enter a coord x,y to place your X or enter 'q' to give up:");
            var gridPosition = GetPositionToPlay();

            _board.CurrentBoardState[gridPosition.Row, gridPosition.Column] = player.mark;
            _view.PrintText(_board.Show());


            // need to check for win 
        }

        public GridPosition GetPositionToPlay()       // (int row, int column)
        {
            var position = new GridPosition(0,0);
           // (int row, int column) gridPosition = (0, 0);
            var positionToPlay = _view.GetText();
            if (positionToPlay.ToLower() == "q")
            {
                // I think I will need to pass in the player here so I have a win thing for a quit
                playerOneWon = true;
                _view.PrintText(" Game over.");
            }
            else if (positionToPlay.ToLower() != "q")
            {
                position = GetValidPosition(positionToPlay);
            }

            return position;
        }

        public GridPosition GetValidPosition(string positionToPlay)
        {
            // Really think I might just make a class position with parameters row and column 
            // as the tuple is getting kind of messy 
            var validPosition = false;
         //   (int row, int column) gridPosition = (0, 0);
            var position = new GridPosition(0,0);
            while (!validPosition)
            {
                var splitStringArray = positionToPlay.Split(",");

                if (splitStringArray.Length == 2)
                {
                    var positionXValid = Int32.TryParse(splitStringArray[0], out var gridPositionRow);
                    var positionYValid = Int32.TryParse(splitStringArray[1], out var gridPositionColumn);
                    if (positionXValid && positionYValid && gridPositionRow is >= 0 and <= 2 &&
                        gridPositionColumn is >= 0 and <= 2)
                    {
                        position.Row = gridPositionRow;
                        position.Column = gridPositionColumn;
                        // probably put the check in here to see if position is "." and thus available
                        if (_board.CurrentBoardState[position.Row, position.Column] == ".")
                        {
                            validPosition = true;
                        }
                    }
                }

                if (validPosition) continue;
                _view.PrintText($" Enter a coord x,y to place your X or enter 'q' to give up:");
                positionToPlay = _view.GetText();
            }


            return position;
        }
    }
}
