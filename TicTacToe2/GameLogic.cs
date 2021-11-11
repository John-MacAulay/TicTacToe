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
        private bool _gameOver;
        private bool _playerOneWon;
        private bool _playerTwoWon;

        private bool _validMoveMade;
        private int _turnCount = 1;

        public GameLogic(IView view = null)
        {
            _view = view ?? new View();
            _board = new Board();
            var listPLayers = new Players();
            _players = listPLayers._players;
            _gameOver = false;
        }

        public void PlayTicTacToe()
        {
            _view.PrintText(" Welcome to Tic Tac Toe!");
            _view.PrintText("\n Here's the current board:");
            _view.PrintText(_board.Show());

            while (!_gameOver)
            {
                foreach (var player in _players)
                {
                    if (!_gameOver)
                    {
                        NewRound(player);
                    }
                }
            }

            if (_playerOneWon)
            {
                _view.PrintText("Player One Wins!");
            }
            else if (_playerTwoWon)
            {
                _view.PrintText("Player Two Wins!");
            }
            else _view.PrintText("It's a draw.");
        }

        public void NewRound(Player player)
        {
            _turnCount++;
            _validMoveMade = false;
            while (!_validMoveMade)
            {
                _view.PrintText($" {player.name} enter a coord x,y to place your X or enter 'q' to give up:");
                var input = _view.GetText();

                CheckForQuit(input, player);
                GetPositionToPlay(input, player);
                if (_turnCount > 9)
                {
                    _gameOver = true;
                }
            }
        }

        public void GetPositionToPlay(string input, Player player)
        {
            var position = new GridPosition(-1, 1);
            if (_gameOver) return;


            position = GetValidPosition(input);


            if (!_validMoveMade) return;
            if (position.Row != -1)
            {
                _board.CurrentBoardState[position.Row, position.Column] = player.mark;

                _view.PrintText(_board.Show());
            }
        }

        private void CheckForQuit(string input, Player player)
        {
            if (input.ToLower() != "q") return;
            _validMoveMade = true;
            _gameOver = true;
            if (player == _players[0])
            {
                _playerTwoWon = true;
            }
            else _playerOneWon = true;
        }


        public GridPosition GetValidPosition(string positionToPlay)
        {
            var position = new GridPosition(-1, -1);
            var splitStringArray = positionToPlay.Split(",");
            if (splitStringArray.Length != 2) return position;
            var positionXValid = Int32.TryParse(splitStringArray[0], out var gridPositionRow);
            var positionYValid = Int32.TryParse(splitStringArray[1], out var gridPositionColumn);

            if (positionXValid && positionYValid && gridPositionRow is >= 0 and <= 2 &&
                gridPositionColumn is >= 0 and <= 2)
            {
                position.Row = gridPositionRow;
                position.Column = gridPositionColumn;
                if (_board.CurrentBoardState[position.Row, position.Column] == ".")
                {
                    _validMoveMade = true;
                }
                else _view.PrintText("That position is already filled, try again.");
            }
            else _view.PrintText("One of those grid positions is invalid, try again.");

            return position;
        }
    }
}
