namespace Calc_Extension_Method
{


    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>() {10,20,30,40 };
            var numSum = Numbers.Sum();
            Console.WriteLine($"Sum of numbers: {Numbers.Sum()}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Subtraction of numbers: {Numbers.Subtract()}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Multiplication of numbers: {Numbers.Multiplicate()}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Division of numbers: {Numbers.Division()}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Modulas of numbers: {Numbers.Modulo()}");
            Console.WriteLine("---------------------------------------");



        }
    }
}
