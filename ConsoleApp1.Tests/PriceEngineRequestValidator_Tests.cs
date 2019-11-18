using ConsoleApp1.PriceEngine;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class PriceEngineRequestValidator_Tests
    {
        [Test]
        public void Validate_RiskDataHasMissingFirstname_ReturnsErrorMessage1()
        {
            var priceRequest = new PriceRequest
            {
                RiskData = RiskData.Create("", "", 1, "", null)
            };

            var validator = new PriceEngineRequestValidator();

            var errors = validator.GetValidationErrors(priceRequest);

            Assert.That(errors.HasValue, Is.True);
            Assert.That(errors.Value, Is.EqualTo("First name is required"));
        }

        [Test]
        public void Validate_RiskDataHasMissingSurname_ReturnsErrorMessage()
        {
            var priceRequest = new PriceRequest
            {
               RiskData = RiskData.Create("Ivan","",1,"",null)
            };

            var validator = new PriceEngineRequestValidator();

            var errors = validator.GetValidationErrors(priceRequest);

            Assert.That(errors.HasValue, Is.True);
            Assert.That(errors.Value, Is.EqualTo("Surname is required"));
        }
    }
}
