using System.Collections.Generic;

namespace TicTacToe2
{
    public class Players
    {
        private readonly List<Player> _players = new ()
        {
            {new Player("Player 1","X")},
            {new Player("Player 2","O")} 
        };
    }
}
