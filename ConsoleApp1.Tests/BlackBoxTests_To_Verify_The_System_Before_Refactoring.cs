using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string error = "";

            var priceEngine = new PriceEngine();
            var price = priceEngine.GetPrice(request, out tax, out insurer);

            Assert.That(price, Is.EqualTo(92.67));
            Assert.That(insurer, Is.EqualTo("zxcvbnm"));
            Assert.That(tax, Is.EqualTo(11.1204m));
            Assert.That(String.Format("You price is {0}, from insurer: {1}. This includes tax of {2}", price, insurer, tax),
                Is.EqualTo("You price is 92.67, from insurer: zxcvbnm. This includes tax of 11.1204"));
        }
    }
}