using System;

namespace ConsoleApp1.QuotationSystems.DTOs
{
    public class QuotationSystem1ResponseDto
    {
        public Decimal Price { get; set; }
        public bool IsSuccess { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
    }
}