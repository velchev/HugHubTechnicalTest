using System;

namespace ConsoleApp1.QuotationSystems.DTOs
{
    public class QuotationSystem3RequestDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DOB { get; set; }
        public string Make { get; set; }
        public decimal Amount { get; set; }
    }
}