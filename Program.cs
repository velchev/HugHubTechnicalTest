﻿using System;
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
            //SNIP - collect input (risk data from the user)

            var request = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
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
