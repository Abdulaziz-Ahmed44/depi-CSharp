namespace First_project_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello!");

            Console.Write("Input the first number: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.Write("Input the second number: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd");
            Console.WriteLine("[S]ubtract");
            Console.WriteLine("[M]ultiply");

            string choice = Console.ReadLine()?.Trim().ToLower();

            switch (choice)
            {
                case "a":
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                    break;
                case "s":
                    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                    break;
                case "m":
                    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
