using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe2
{
    public class Players
    {
        public readonly List<Player> _players = new();

        
        public Players(List<Player> players)
        {
            _players.AddRange(players);
        }
        
    }
}
