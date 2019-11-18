namespace ConsoleApp1.PriceEngine
{
    public interface IPriceEngineRequestValidator
    {
        Option<string> GetValidationErrors(PriceRequest priceRequest);
    }
}