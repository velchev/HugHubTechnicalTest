using System;
using System.Collections.Generic;
using ConsoleApp1.QuotationSystems;
using ConsoleApp1.QuotationSystems.DTOs;
using Moq;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class PriceEngine_With_QuotationSystem2
    {
        [Test]
        public void When_Only_System2_Is_Available_And_RiskDataMakeIsExampleMake1_Price_Is_Calculated()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "examplemake1", null)
            };

            var systemList = new List<QuotationSystem>();
            Mock<IQuotationSystem2Service> quotationSystem2ServiceMock = new Mock<IQuotationSystem2Service>();
            var response = new QuotationSystem2ResponseDto();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;
            
            quotationSystem2ServiceMock.Setup(x => x.PostHttpRequest(It.IsAny<QuotationSystem2RequestDto>())).Returns(response);

            QuotationSystem system2 = new QuotationSystem2("http://quote-system-1.com", "1234", request, quotationSystem2ServiceMock.Object);

            systemList.Add(system2);

            var priceEngine = new PriceEngine.PriceEngine(systemList);
            var price = priceEngine.GetPrice(request);
            //More than one assert but is checking for same logical result
            Assert.That(price.HasValue, Is.True);
            Assert.That(price.Value.Price, Is.EqualTo(234.56M));
            Assert.That(price.Value.InsurerName, Is.EqualTo("qewtrywrh"));
        }

        [Test]
        public void When_Only_System2_Is_Available_And_RiskDataMakeIsNotExampleMake1_Price_Is_Calculated()
        {
            var request = new PriceRequest()
            {
                RiskData = RiskData.Create("John", "Smith", 500, "Cool New Phone", DateTime.Parse("1980-01-01"))
            };

            var systemList = new List<QuotationSystem>();
            QuotationSystem system2 = new QuotationSystem2("http://quote-system-1.com", "1234", request,null);

            systemList.Add(system2);

            var priceEngine = new PriceEngine.PriceEngine(systemList);
            var price = priceEngine.GetPrice(request);
            Assert.That(price.HasValue, Is.False);
        }
    }
}
