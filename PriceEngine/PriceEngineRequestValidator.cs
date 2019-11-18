namespace ConsoleApp1.PriceEngine
{
    public class PriceEngineRequestValidator: IPriceEngineRequestValidator
    {
        public Option<string> GetValidationErrors(PriceRequest priceRequest)
        {
            if (priceRequest.RiskData == null)
            {
                return Option.Create("Risk Data is missing");
            }

            if (string.IsNullOrEmpty(priceRequest.RiskData.FirstName))
            {
                return Option.Create("First name is required");
            }

            if (string.IsNullOrEmpty(priceRequest.RiskData.LastName))
            {
                return Option.Create("Surname is required");
            }

            if (priceRequest.RiskData.Value == 0)
            {
                return Option.Create("Value is required");
            }

            return Option<string>.Empty;
        }
    }
}