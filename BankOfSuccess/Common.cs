using System;

namespace BankOfSuccess
{
    public class InvalidAccountTypeException : Exception
    {
        public InvalidAccountTypeException(string message) : base(message)
        {
        }
    }
    public class InvalidPolicyTypeException : Exception
    {
        public InvalidPolicyTypeException(string message) : base(message) { }   
    }
}
