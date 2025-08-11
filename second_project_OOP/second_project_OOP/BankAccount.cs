using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_project_OOP
{
    class BankAccount
    {
        // Fields
       
        private  string _accountNumber;
        private string _fullName;
        private decimal _balance;

        // Properties
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("The name cannot be empty");
                }
                else
                {
                    _fullName = value;
                }
            }
        }


        

        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The balance cannot be negative");
                }
                else
                {
                    _balance = value;
                }
            }
        }

        // Constructors
     

        public BankAccount(string accountNumber,string fullName,decimal balance)
        {
           
            FullName = fullName;
            
            _accountNumber = accountNumber;
            
            Balance = balance;
        }



        // Methods
        public virtual decimal CalculateInterest()
        {
            return 0;
        }
        public virtual void ShowAccountDetails()
        {
            Console.WriteLine("----- Account details -----");
            Console.WriteLine($"FullName: {FullName}");
      
            Console.WriteLine($"Balance: {Balance}");
          
        }

        
    }
}

