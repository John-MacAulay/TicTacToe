
using System.Collections.Generic;


namespace TicTacToe2
{
    public class Players
    {
        private int _currentPlayerIndex;
        
        private readonly List<Player> _players = new();
        public bool IsEmpty => _players.Count == 0;

        public void AddPlayer(Player playerToAdd)
        {
            _players.Add(playerToAdd);
        }

        public Player GetCurrentPlayer()
        {
            return _players[_currentPlayerIndex];
        }

        public void AdvanceToNextPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex > _players.Count)
            {
                _currentPlayerIndex = 0;
            }
        }

        public object Count()
        {
            return _players.Count;
        }
    }
}
