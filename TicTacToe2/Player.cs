namespace TicTacToe2
{
    public class Player
    {
        public string Name { get; set; }
        public  string Mark { get; set; }
        public Player(string nameToAdd ,string markToAdd)
        {
            Mark = markToAdd;
            Name = nameToAdd;
       
        }
    }
}
