namespace second_project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
           SavingAccount savingAccount = new SavingAccount(
                "CA123",
                "Abdulaziz Ahmed",
                5000m,
                2000m);
           CurrentAccount currentAccount = new CurrentAccount(
                "IS456",
                "Ali Ahmed",
                10000m,
                5m);


            List<BankAccount> accounts = new List<BankAccount> { savingAccount, currentAccount };


            foreach (var account in accounts)
            {
                account.ShowAccountDetails();
                Console.WriteLine($"Interest: {account.CalculateInterest()}");


                Console.WriteLine(new string('-', 30));

               
            }
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }
    }
}
