using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToe2
{
    public class Players
    {
        private Player _player;
        //private readonly List<Player> _players = new();
        public bool IsEmpty { get; private set; } = true;

        // public Players()
        // {
        //     
        // }
        // public int countPlayers()
        // {
        //   return _players.Count;
        // }


        public void AddPlayer(Player playerToAdd)
        {
            _player = playerToAdd;
            IsEmpty = false;
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
