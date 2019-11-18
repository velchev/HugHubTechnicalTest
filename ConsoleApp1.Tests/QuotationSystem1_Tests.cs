using System;
using ConsoleApp1.QuotationSystems;
using Moq;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class QuotationSystem1_Tests
    {
        [Test]
        public void If_Dob_Is_Null_Never_Get_Price()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", null)
            };

           var quotationSystem1 = new QuotationSystem1(It.IsAny<string>(), It.IsAny<string>(), request);
           var result = quotationSystem1.CalculatePrice();
           Assert.That(result.HasValue, Is.False);
        }

        [Test]
        public void If_Dob_Is_Not_Null_Get_Price()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"))
            };

            var quotationSystem1 = new QuotationSystem1(It.IsAny<string>(), It.IsAny<string>(), request);
            var result = quotationSystem1.CalculatePrice();
            Assert.That(result.HasValue, Is.True);
        }
    }
}
