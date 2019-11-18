using System;

namespace ConsoleApp1
{
    public class RiskDataConsoleInputReader : IRiskDataConsoleInputReader
    {
        public RiskData Read()
        {
            Console.WriteLine("What is your first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("What is your last name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("What is your value:");
            var value = decimal.Parse(Console.ReadLine());

            Console.WriteLine("What is your make:");
            var make = Console.ReadLine();

            Console.WriteLine("What is your make:");
            DateTime? dob = DateTime.Parse(Console.ReadLine());

            return RiskData.Create(firstName, lastName, value, make, dob);
        }
    }
}
