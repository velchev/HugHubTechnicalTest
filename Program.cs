using System;
using System.Collections.Generic;
using ConsoleApp1.PriceEngine;
using ConsoleApp1.QuotationSystems;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IRiskDataConsoleInputReader dataReader = new RiskDataConsoleInputReaderStub();
            var request = new PriceRequest()
            {
                RiskData = dataReader.Read()
            };
            var systemList = new List<QuotationSystem>();
            QuotationSystem system1 = new QuotationSystem1("http://quote-system-1.com", "1234", request);
            QuotationSystem system2 = new QuotationSystem2("http://quote-system-2.com", "1235", request, new QuotationSystem2Service());
            QuotationSystem system3 = new QuotationSystem3("http://quote-system-3.com", "100", request);
            QuotationSystem system4 = new QuotationSystem4();//("http://quote-system-3.com", "100", request);

            systemList.Add(system1);
            systemList.Add(system2);
            systemList.Add(system3);

            var priceEngine = new PriceEngine.PriceEngine(systemList);

            var validator = new PriceEngineRequestValidator();
            var priceRequestValidationResult = validator.GetValidationErrors(request);
            if (!priceRequestValidationResult.HasValue)
            {
                var price = priceEngine.GetPrice(request);
                if (price.HasValue)
                {
                    Console.WriteLine(
                        $"You price is {price.Value.Price}, from insurer: {price.Value.InsurerName}. This includes tax of {price.Value.Tax}");
                }
            }
            else
            {
                Console.WriteLine($"There was an error - {priceRequestValidationResult.Value}");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
