using System;

namespace TicTacToe2
{
    public class View :  IView
    {
        public void PrintText(string textToPrint)
        {
            Console.WriteLine(textToPrint);
            
            
        }

        public string GetText()
        {
            var needThis = Console.ReadLine();
            return needThis;
        }
    }


}
