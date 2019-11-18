using System;

namespace ConsoleApp1.QuotationSystems.DTOs
{
    public class QuotationSystem2ResponseDto
    {
        public Decimal Price { get; set; }
        public bool HasPrice { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
    }
}