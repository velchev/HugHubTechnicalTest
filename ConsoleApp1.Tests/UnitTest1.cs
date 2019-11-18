using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB =null,
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };

            decimal tax = 0;
            string insurer = "";
            string error = "";
            var mock = new Moq.Mock<QuotationSystem>();
            mock.Setup(x => x.GetPrice()).Returns("somethig");
            mock.Verify(x=>x.GetPrice(), Times.Never);
        }

        [Test]
        public void If_Dob_Is_Not_Null_Get_Price()
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
            var mock = new Moq.Mock<QuotationSystem>();
            mock.Setup(x => x.GetPrice()).Returns("somethig");
            mock.Verify(x => x.GetPrice(), Times.Once);

        }
    }
}
