using System.Collections.Generic;
using TicTacToe2;

namespace TicTacToe2Tests
{
    public class TestView  :IView
    {
        private readonly string [] _fakeInput;
        private int _getInputPosition;
        public readonly List<string> FakeOutput = new() ;

        public TestView(string[] fakeInput )
        {
            _fakeInput = fakeInput;
        }
        
        public void PrintText(string textToPrint)
        {
            FakeOutput.Add(textToPrint);
        }

        public string GetText()
        {
            return _fakeInput[_getInputPosition++];

        }
    }
}
