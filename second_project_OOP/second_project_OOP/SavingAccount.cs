using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_project_OOP
{
     class SavingAccount : BankAccount
    {
        private decimal _InterestRate;

        public SavingAccount( string AccountNumber, string FullName, decimal Balance, decimal InterestRate):base(AccountNumber, FullName, Balance)
        {
            _InterestRate = InterestRate;
        }

        public override decimal CalculateInterest()
        {
            return Balance * _InterestRate /100;
        }

        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"InterestRate: {_InterestRate}%");
        }
    }
}
