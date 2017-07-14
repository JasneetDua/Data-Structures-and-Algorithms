using System;

namespace TicTacToe
{
    internal class SomethingIsSerioslyWrongException : Exception
    {
        public SomethingIsSerioslyWrongException(string message) : base(message)
        {
        }
    }
}