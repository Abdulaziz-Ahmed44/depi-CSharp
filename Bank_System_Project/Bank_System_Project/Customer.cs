using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bank_System_Project
{
    internal class Customer
    {
        //fields
        private static int _idCounter = 0;
        private int _id;
        private string _fullName;
        private string _natioalId;
        private DateTime _DateOfBirth;


        //properties
        public int Id { get; private set; }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 3 || value.Length > 50))
                {
                    Console.WriteLine("Invalid Full Name");
                }
                else
                {
                    _fullName = value;
                }
            }
        }
        public string NatioalId
        {
            get
            {
                return _natioalId;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (_natioalId.Length != 14))
                {
                    Console.WriteLine("Invalid National ID ");
                }
                else
                {
                    _natioalId = value;
                }
            }

        }
        public List<Account> Accounts { get; private set; }

        //Constructor
        public Customer(string fullName, string nationalId, DateTime dob)
        {
            _id = ++_idCounter;
            _fullName = fullName;
            _natioalId = nationalId;
            _DateOfBirth = dob;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public decimal GetTotalBalance()
        {
            decimal total = 0;
            foreach (var acc in Accounts)
            {
                total += acc.Balance;
            }
            return total;
        }

        public void UpdateDetails(string name, DateTime dob)
        {
            _fullName = name;
            _DateOfBirth = dob;
        }






    }
}
