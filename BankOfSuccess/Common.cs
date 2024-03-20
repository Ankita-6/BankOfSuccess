using System;

namespace BankOfSuccess
{
    public class InvalidAccountTypeException : Exception
    {
        public InvalidAccountTypeException(string message) : base(message)
        {
        }
    }
}
