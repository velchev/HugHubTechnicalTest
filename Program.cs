using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            decimal tax = 0;
            string insurer = "";

            var priceEngine = new PriceEngine();
            var priceRequestValidationResult = PriceEngineRequestValidator.IsValid(request);
            if (priceRequestValidationResult.Item1)
            {
                var price = priceEngine.GetPrice(request, out tax, out insurer);
                Console.WriteLine(String.Format("You price is {0}, from insurer: {1}. This includes tax of {2}", price.Price, price.InsurerName, price.Tax));
            }
            else
            {
                Console.WriteLine(String.Format("There was an error - {0}", priceRequestValidationResult.Item2));
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
