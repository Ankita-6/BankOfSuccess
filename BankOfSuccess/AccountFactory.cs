using System;
using System.Configuration;

namespace BankOfSuccess
{
    public class AccountFactory
    {
        public Account createAccount(AccountType type)
        {
            string className = ConfigurationManager.AppSettings[$"AccountType_{type.ToString()}"];
            if (string.IsNullOrEmpty(className))
                throw new InvalidAccountTypeException("Invalid or missing configuration for account type.");
            Type accountType = Type.GetType(className);
            return (Account)Activator.CreateInstance(accountType);
        }
    }
}
