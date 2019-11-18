using System;

namespace ConsoleApp1
{
    public class RiskData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Value { get; set; }
        public string Make { get; set; }
        public DateTime? DOB { get; set; }

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