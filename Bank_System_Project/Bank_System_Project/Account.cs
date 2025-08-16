using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_System_Project
{
    abstract class Account
    {
        //fields
        private static int _accountCounter = 1000;
        

        // properties
        public int AccountNumber { get; private set; }
        public decimal Balance { get ; protected set; }
        public DateTime DateOpened { get; private set; }
        public List<Transaction> Transactions { get; private set; }


        // constructor
        public Account()
        {
            AccountNumber = ++_accountCounter;
            Balance = 0;
            DateOpened = DateTime.Now;
            Transactions = new List<Transaction>();
        }


        //methods
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction(Transactions.Count + 1, amount, "Deposit", null, AccountNumber));
        }

        public abstract bool Withdraw(decimal amount);
        public virtual bool Transfer(Account target, decimal amount)
        {
            if (Withdraw(amount))
            {
                target.Deposit(amount);
                Transactions.Add(new Transaction(Transactions.Count + 1, amount, "Transfer", this.AccountNumber, target.AccountNumber));
                return true;
            }
            return false;
        }



    }
}
