using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_System_Project
{
    internal class SavingsAccount:Account
    {
        public decimal InterestRate { get; private set; }

        public SavingsAccount(decimal interestRate)
        {
            InterestRate = interestRate;

        }

        public decimal CalculateMonthlyInterest()
        {
            return Balance * InterestRate / 100;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(Transactions.Count + 1, amount, "Withdraw", AccountNumber, null));
                return true;
            }
            return false;
        }
    }
}
