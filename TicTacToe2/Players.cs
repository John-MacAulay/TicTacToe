using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToe2
{
    public class Players
    {
        private Player _player;
        private readonly List<Player> _players = new();
        public bool IsEmpty { get; private set; } = true;

        // public Players()
        // {
        //     
        // }
        //


        public void AddPlayer(Player playerToAdd)
        {
            _players.Add(playerToAdd);
            IsEmpty = false;
        }

        public Player GetPlayer(int playerNumber)
        {
            return _players[playerNumber-1];
        }

        public object Count()
        {
            return _players.Count;
        }
    }
}
