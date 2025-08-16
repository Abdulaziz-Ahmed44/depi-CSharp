using System;

namespace Bank_System_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Welcome to Bank System =====");

            Console.Write("Enter Bank Name: ");
            string bankName = Console.ReadLine();

            Console.Write("Enter Branch Code: ");
            string branchCode = Console.ReadLine();

            Bank bank = new Bank(bankName, branchCode);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Main Menu =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Account to Customer");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Show Bank Report");
                Console.WriteLine("7. Remove Customer");
                Console.WriteLine("8. Show Total Balance of a Customer");
                Console.WriteLine("9. Calculate Monthly Interest for Savings Accounts");
                Console.WriteLine("10. Show Transaction History");
                Console.WriteLine("11. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Add Customer
                        Console.Write("Enter Full Name: ");
                        string fullName = Console.ReadLine();

                        Console.Write("Enter National ID (14 digits): ");
                        string nationalId = Console.ReadLine();

                        Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                        DateTime dob = DateTime.Parse(Console.ReadLine());

                        Customer customer = new Customer(fullName, nationalId, dob);
                        bank.AddCustomer(customer);
                        Console.WriteLine("Customer added successfully.");
                        break;

                    case "2": // Add Account
                        Console.Write("Enter Customer National ID: ");
                        string cid = Console.ReadLine();
                        Customer cust = bank.FindCustomerByID(cid);

                        if (cust != null)
                        {
                            Console.WriteLine("1. Current Account");
                            Console.WriteLine("2. Savings Account");
                            Console.Write("Choose account type: ");
                            string accType = Console.ReadLine();

                            if (accType == "1")
                            {
                                Console.Write("Enter overdraft limit: ");
                                decimal overdraft = decimal.Parse(Console.ReadLine());
                                cust.AddAccount(new CurrentAccount(overdraft));
                                Console.WriteLine("Current Account added.");
                            }
                            else if (accType == "2")
                            {
                                Console.Write("Enter interest rate: ");
                                decimal rate = decimal.Parse(Console.ReadLine());
                                cust.AddAccount(new SavingsAccount(rate));
                                Console.WriteLine("Savings Account added.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;

                    case "3": // Deposit
                        Console.Write("Enter Customer National ID: ");
                        string depId = Console.ReadLine();
                        Customer depCust = bank.FindCustomerByID(depId);

                        if (depCust != null)
                        {
                            Console.Write("Enter Account Number: ");
                            int accNum = int.Parse(Console.ReadLine());
                            Account acc = depCust.Accounts.Find(a => a.AccountNumber == accNum);

                            if (acc != null)
                            {
                                Console.Write("Enter amount: ");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                acc.Deposit(amount);
                                Console.WriteLine("Deposit successful.");
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }
                        }
                        break;

                    case "4": // Withdraw
                        Console.Write("Enter Customer National ID: ");
                        string wId = Console.ReadLine();
                        Customer wCust = bank.FindCustomerByID(wId);

                        if (wCust != null)
                        {
                            Console.Write("Enter Account Number: ");
                            int accNum = int.Parse(Console.ReadLine());
                            Account acc = wCust.Accounts.Find(a => a.AccountNumber == accNum);

                            if (acc != null)
                            {
                                Console.Write("Enter amount: ");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                if (acc.Withdraw(amount))
                                    Console.WriteLine("Withdraw successful.");
                                else
                                    Console.WriteLine("Insufficient balance.");
                            }
                        }
                        break;

                    case "5": // Transfer
                        Console.Write("Enter Source Customer ID: ");
                        string sId = Console.ReadLine();
                        Customer sCust = bank.FindCustomerByID(sId);

                        Console.Write("Enter Target Customer ID: ");
                        string tId = Console.ReadLine();
                        Customer tCust = bank.FindCustomerByID(tId);

                        if (sCust != null && tCust != null)
                        {
                            Console.Write("Enter Source Account Number: ");
                            int sAccNum = int.Parse(Console.ReadLine());
                            Account sAcc = sCust.Accounts.Find(a => a.AccountNumber == sAccNum);

                            Console.Write("Enter Target Account Number: ");
                            int tAccNum = int.Parse(Console.ReadLine());
                            Account tAcc = tCust.Accounts.Find(a => a.AccountNumber == tAccNum);

                            if (sAcc != null && tAcc != null)
                            {
                                Console.Write("Enter amount: ");
                                decimal amount = decimal.Parse(Console.ReadLine());

                                if (sAcc.Transfer(tAcc, amount))
                                    Console.WriteLine("Transfer successful.");
                                else
                                    Console.WriteLine("Transfer failed.");
                            }
                        }
                        break;

                    case "6":
                        bank.GenerateReport();
                        break;

                    case "7": // Remove Customer
                        Console.Write("Enter Customer National ID: ");
                        string removeId = Console.ReadLine();
                        Customer removeCust = bank.FindCustomerByID(removeId);

                        if (removeCust != null)
                        {
                            
                            bool canRemove = true;
                            foreach (var account in removeCust.Accounts)
                            {
                                if (account.Balance != 0)
                                {
                                    canRemove = false;
                                    break;
                                }
                            }

                            if (canRemove)
                            {
                                bank.RemoveCustomer(removeCust);
                                Console.WriteLine("Customer removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Cannot remove customer. One or more accounts still have balance.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;

                    case "8": // Show Total Balance
                        Console.Write("Enter Customer National ID: ");
                        string totalId = Console.ReadLine();
                        Customer totalCust = bank.FindCustomerByID(totalId);

                        if (totalCust != null)
                        {
                            decimal totalBalance = 0;
                            foreach (var account in totalCust.Accounts)
                            {
                                totalBalance += account.Balance;
                            }

                            Console.WriteLine($"Total Balance for {totalCust.FullName} = {totalBalance}");
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;

                    case "9": // Calculate Monthly Interest
                        Console.Write("Enter Customer National ID: ");
                        string interestId = Console.ReadLine();
                        Customer interestCust = bank.FindCustomerByID(interestId);

                        if (interestCust != null)
                        {
                            bool hasSavings = false;

                            foreach (var account in interestCust.Accounts)
                            {
                                if (account is SavingsAccount savingsAcc)
                                {
                                    hasSavings = true;
                                    decimal interest = savingsAcc.CalculateMonthlyInterest();
                                    Console.WriteLine($"Savings Account {savingsAcc.AccountNumber} -> Balance: {savingsAcc.Balance}, Interest: {interest}");
                                }
                            }

                            if (!hasSavings)
                            {
                                Console.WriteLine("This customer has no savings accounts.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;

                    case "10": // Transaction History
                        Console.Write("Enter Customer National ID: ");
                        string searchId = Console.ReadLine();
                        Customer c = bank.FindCustomerByID(searchId);

                        if (c != null)
                        {
                            foreach (var acc in c.Accounts)
                            {
                                Console.WriteLine($"\nAccount {acc.AccountNumber} - Balance: {acc.Balance}");
                                if (acc.Transactions.Count == 0)
                                    Console.WriteLine("No transactions.");
                                else
                                {
                                    foreach (var t in acc.Transactions)
                                    {
                                        Console.WriteLine($"{t.Date} - {t.Type} - {t.Amount}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;


                    case "11":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
