using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project_OOP
{
 
class BankAccount
    {
        // Fields
        public const string BankCode = "BNK001"; 
        public readonly DateTime CreatedDate; 
        private int _accountNumber;
        private string _fullName;
        private string _nationalID;
        private string _phoneNumber;
        private string _address;
        private double _balance;

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

        public string NationalID
        {
            get
            {
                return _nationalID;
            }
            set
            {
                if (value.Length != 14 || !long.TryParse(value, out _))
                {
                    Console.WriteLine("The national ID must be 14 digits");
                }
                else
                {
                    _nationalID = value;
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value.Length != 11 || !value.StartsWith("01"))
                {
                    Console.WriteLine("Mobile number must start with 01 and be 11 digits");
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                 _address = value;
            }
        }

        public double Balance
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
        public BankAccount()
        {
            CreatedDate = DateTime.Now;
            FullName = "unknown";
            NationalID = "00000000000000";
            PhoneNumber = "01000000000";
            Address = "unknown";
            Balance = 0;
        }

        public BankAccount(string fullName, string nationalID, string phoneNumber, string address, double balance)
        {
            CreatedDate = DateTime.Now;
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Address = address;
            Balance = balance;
        }

        public BankAccount(string fullName, string nationalID, string phoneNumber, string address)
            : this(fullName, nationalID, phoneNumber, address, 0) { }

        // Methods
        public void ShowAccountDetails()
        {
            Console.WriteLine("----- Account details -----");
            Console.WriteLine($"FullName: {FullName}");
            Console.WriteLine($"NationalID: {NationalID}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"CreatedDate: {CreatedDate}");
            Console.WriteLine($"BankCode: {BankCode}");
            Console.WriteLine();
        }

        public bool IsValidNationalID()
        {
            return NationalID.Length == 14 && long.TryParse(NationalID, out _);
        }

        public bool IsValidPhoneNumber()
        {
            return PhoneNumber.Length == 11 && PhoneNumber.StartsWith("01");
        }
    }

}

