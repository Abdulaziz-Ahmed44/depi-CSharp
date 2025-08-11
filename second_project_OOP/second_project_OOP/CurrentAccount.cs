using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_project_OOP
{
    class CurrentAccount : BankAccount
    {
        private decimal _OverdraftLimit;


        public CurrentAccount(string accountNumber, string FullName, decimal Balance, decimal OverdraftLimit) : base(accountNumber,FullName, Balance)
        { 
            _OverdraftLimit = OverdraftLimit;
        }

        public override decimal CalculateInterest()
        {
            return 0;
        }
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"OverdraftLimit: {_OverdraftLimit}");
            
        }
    }
}
