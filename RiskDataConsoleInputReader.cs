using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IRiskDataConsoleInputReader
    {
        RiskData Read();
    }
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

    public class RiskDataConsoleInputReaderStub : IRiskDataConsoleInputReader
    {
        public RiskData Read()
        {
            return RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"));
        }
    }

}
