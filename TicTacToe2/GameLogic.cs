using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace TicTacToe2
{
    public class GameLogic
    {
        private readonly IView _view;
        public readonly Board Board;
        private readonly Players _players;
        private bool _gameOver;
        private Player _winningPlayer;
        private bool _validMoveMade;
        private int _turnCount = 1;

        public GameLogic(IView view = null)
        {
            _view = view ?? new View();
            Board = new Board();
            _players = new Players();
        }

        public void PlayTicTacToe()
        {
            SetUpStandardPlayerNames();
            DisplayWelcomeAndInitialBoard();
            while (!_gameOver)       
            {
                var player = _players.GetCurrentPlayer();
                NewRound(player);
                _players.AdvanceToNextPlayer();
            }

            DisplayResultOfGame();
        }

        public void SetUpStandardPlayerNames()
        {
            _players.AddPlayer(new Player("Player 1", "X"));
            _players.AddPlayer(new Player("Player 2", "O"));
        }

        private void DisplayWelcomeAndInitialBoard()
        {
            _view.PrintText(" Welcome to Tic Tac Toe!");
            _view.PrintText("\n Here's the current board:");
            _view.PrintText(Board.Show());
        }

        public void DisplayResultOfGame()
        {
            _view.PrintText(_winningPlayer != null ? $"{_winningPlayer.Name} has won!" : "It's a draw.");
        }

        public void NewRound(Player player)
        {
            _turnCount++;
            _validMoveMade = false;
            while (!_validMoveMade)
            {
                _view.PrintText(
                    $" {player.Name} enter a coord x,y to place your {player.Mark} or enter 'q' to give up:");
                var input = _view.GetText();
                CheckForQuit(input);
                GetPositionToPlay(input, player);
                if (_turnCount > 9)
                {
                    _gameOver = true;
                }
                CheckPlayerWon(player);
            }
        }

        public void GetPositionToPlay(string input, Player player)
        {
            if (_gameOver) return;
            var position = ValidatePosition(input);
            if (!_validMoveMade) return;
            Board.CurrentBoardState[position.Row, position.Column] = player.Mark;
            _view.PrintText(Board.Show());
        }

        public void CheckPlayerWon(Player player)
        {
            var playerWins = CheckPlayerWinsOnRow(player);

            if (playerWins == false)
            {
                playerWins = CheckPlayerWinsOnColumn(player);
            }

            if (playerWins == false)
            {
                playerWins = CheckPlayerWinsOnDiagonal(player);
            }

            if (playerWins)
            {
                ChangeToGameWonStates(player);
            }
        }

        private void ChangeToGameWonStates(Player player)
        {
            _winningPlayer = player;
            _gameOver = true;
        }

        private bool CheckPlayerWinsOnRow(Player player)
        {
            var playerWins = false;
            for (var i = 0; i <= 2; i++)
            {
                if (Board.CurrentBoardState[i, 0] == player.Mark && Board.CurrentBoardState[i, 1] == player.Mark &&
                    Board.CurrentBoardState[i, 2] == player.Mark)
                {
                    playerWins = true;
                }
            }

            return playerWins;
        }

        private bool CheckPlayerWinsOnColumn(Player player)
        {
            var playerWins = false;
            for (var i = 0; i <= 2; i++)
            {
                if (Board.CurrentBoardState[0, i] == player.Mark && Board.CurrentBoardState[1, i] == player.Mark &&
                    Board.CurrentBoardState[2, i] == player.Mark)
                {
                    playerWins = true;
                }
            }

            return playerWins;
        }

        private bool CheckPlayerWinsOnDiagonal(Player player)
        {
            var playerWins =
                Board.CurrentBoardState[0, 0] == player.Mark
                && Board.CurrentBoardState[1, 1] == player.Mark &&
                Board.CurrentBoardState[2, 2] == player.Mark
                || Board.CurrentBoardState[2, 0] == player.Mark
                && Board.CurrentBoardState[1, 1] == player.Mark &&
                Board.CurrentBoardState[0, 2] == player.Mark;

            return playerWins;
        }


        private void CheckForQuit(string input)
        {
            if (input.ToLower() != "q") return;
            _validMoveMade = true;
            _gameOver = true;
            _players.AdvanceToNextPlayer();
            var player = _players.GetCurrentPlayer();
            
                _winningPlayer = player;
     
        }


        public GridPosition ValidatePosition(string positionToPlay)
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
                if (Board.CurrentBoardState[position.Row, position.Column] == ".")
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
