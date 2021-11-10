using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe2
{
    public class Players
    {
        public readonly List<Player> _players = new();

        public Players()
        {
            AddPlayers();
        }

        private void AddPlayers()
        {
            _players.Add(new Player("Player 1", "X"));
            _players.Add(new Player("Player 2", "O"));
        }
    }
}
