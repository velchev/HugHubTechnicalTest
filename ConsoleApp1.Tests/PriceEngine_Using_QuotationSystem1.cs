using System;
using System.Collections.Generic;
using ConsoleApp1.QuotationSystems;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class PriceEngine_Using_QuotationSystem1
    {
        [Test]
        public void When_Only_System1_Is_Available_And_Dob_Is_Null_Price_Is_Not_Calculated()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", null)
            };

            var systemList = new List<QuotationSystem>();
            QuotationSystem system1 = new QuotationSystem1("http://quote-system-1.com", "1234", request);

            systemList.Add(system1);

            var priceEngine = new PriceEngine.PriceEngine(systemList);
            var price = priceEngine.GetPrice(request);
            Assert.That(price.HasValue, Is.False);
        }

        [Test]
        public void When_Only_System1_Is_Available_And_Dob_Is_Not_Null_Price_Is_Calculated()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"))
            };

            var systemList = new List<QuotationSystem>();
            QuotationSystem system1 = new QuotationSystem1("http://quote-system-1.com", "1234", request);

            systemList.Add(system1);

            var priceEngine = new PriceEngine.PriceEngine(systemList);
            var price = priceEngine.GetPrice(request);
            Assert.That(price.HasValue, Is.True);
        }
    }
}
