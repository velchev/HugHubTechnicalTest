using System;

namespace ConsoleApp1
{
    public class RiskData
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal Value { get; private set; }
        public string Make { get; private set; }
        public DateTime? DOB { get; private set; }

        private RiskData()
        {

        }

        public static RiskData Create(string firstName, string lastName, decimal value, string make, DateTime? dob)
        {
            return new RiskData
            {
                FirstName = firstName,
                LastName = lastName,
                Value = value,
                Make = make,
                DOB = dob
            };
        }
    }
}