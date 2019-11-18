using System;

namespace ConsoleApp1
{
    public class RiskDataConsoleInputReaderStub : IRiskDataConsoleInputReader
    {
        public RiskData Read()
        {
            return RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"));
        }
    }
}