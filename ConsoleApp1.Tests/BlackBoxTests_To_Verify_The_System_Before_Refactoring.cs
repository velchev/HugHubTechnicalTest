using System;
using System.Collections.Generic;
using ConsoleApp1.QuotationSystems;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class BlackBoxTests_To_Verify_The_System_Before_Refactoring
    {
        [Test]
        public void VerifyCorrectResult_With_Sample_Data()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"))
            };
            var systemList = new List<QuotationSystem>();
            QuotationSystem system1 = new QuotationSystem1("http://quote-system-1.com", "1234", request);
            QuotationSystem system2 = new QuotationSystem2("http://quote-system-2.com", "1235", request, new QuotationSystem2Service());
            QuotationSystem system3 = new QuotationSystem3("http://quote-system-3.com", "100", request);

            systemList.Add(system1);
            systemList.Add(system2);
            systemList.Add(system3);

            var priceEngine = new PriceEngine.PriceEngine(systemList);
            var price = priceEngine.GetPrice(request).Value;

            Assert.That(price.Price, Is.EqualTo(92.67));
            Assert.That(price.InsurerName, Is.EqualTo("zxcvbnm"));
            Assert.That(price.Tax, Is.EqualTo(11.1204m));
            Assert.That(
                $"You price is {price.Price}, from insurer: {price.InsurerName}. This includes tax of {price.Tax}",
                Is.EqualTo("You price is 92.67, from insurer: zxcvbnm. This includes tax of 11.1204"));
        }
    }
}