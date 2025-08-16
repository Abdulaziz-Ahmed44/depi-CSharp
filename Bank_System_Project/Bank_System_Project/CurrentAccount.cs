using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_System_Project
{
    internal class CurrentAccount: Account
    {

        public decimal OverdraftLimit { get; private set; }

        public CurrentAccount(decimal overdraftLimit)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(Transactions.Count + 1, amount, "Withdraw", AccountNumber, null));
                return true;
            }
            return false;
        }


    }
}
