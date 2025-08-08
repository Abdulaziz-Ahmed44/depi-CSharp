namespace first_project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount();
            account1.ShowAccountDetails();

            BankAccount account2 = new BankAccount(
                "Abdulaziz Ahmed",
                "29805220123456",
                "01123456789",
                "shebin ElKom - Egypt",
                1500.75
            );
            account2.ShowAccountDetails();
        }
    }
}
