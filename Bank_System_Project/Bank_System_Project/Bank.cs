using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bank_System_Project
{
    internal class Bank
    {
        //fields
        private string _name;
        private string _branchcode ;


        //properties
        public string Name 
        { get
            { 
                return _name; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 3 || value.Length > 50))
                {
                    Console.WriteLine("Invalid Name");
                }
                else
                {
                    _name = value;
                }
            }

        }
        public string BranchCode
        {
            get
            {
                return _branchcode;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 3 || value.Length > 10))
                {
                    Console.WriteLine("Invalid branch code");
                }
                else
                {
                    _branchcode = value;
                }
            }
        }
       public List<Customer> Customers { get; private set ; }


        //constructor
        public Bank(string name,string branchcode)
        {
            _name = name;
            _branchcode = branchcode;
            Customers = new List<Customer>();

        }
        //methods
        public  void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public void RemoveCustomer(Customer customer)
        {

            if (customer != null && customer.GetTotalBalance() == 0)
            {
                Customers.Remove(customer);
            }
        }
        public Customer FindCustomerByID(String id)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.NatioalId == id)

                    return customer;
            }

            return null;

        }

        public Customer FindCustomerByName(String name)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.FullName == name)

                    return customer;
                    
            }
            return null;

        }

        public void GenerateReport()
        {
            Console.WriteLine($"Bank Report: {Name} - Branch {BranchCode}");
            foreach (var c in Customers)
            {
                Console.WriteLine($"Customer: {c.FullName}, Total Balance: {c.GetTotalBalance()}");
                foreach (var acc in c.Accounts)
                {
                    Console.WriteLine($"   Account {acc.AccountNumber}, Balance: {acc.Balance}");
                }
            }
        }
    }
}
