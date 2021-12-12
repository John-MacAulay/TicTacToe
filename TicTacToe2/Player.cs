namespace TicTacToe2
{
    public class Player
    {
        public string name { get; set; }
        public  string mark { get; set; }
        public Player(string nameToAdd ,string markToAdd)
        {
            mark = markToAdd;
            name = nameToAdd;
       
        }
    }
}
