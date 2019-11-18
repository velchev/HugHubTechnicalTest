namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem4: QuotationSystem
    {
        protected override Option<PriceEngineResult> GetPrice()
        {
            return Option.Create(new PriceEngineResult
            {
                Price = 1,
                Tax = 1,
                InsurerName = "Velchev"
            });
        }
    }
}
