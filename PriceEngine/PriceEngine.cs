using System.Collections.Generic;
using ConsoleApp1.QuotationSystems;

namespace ConsoleApp1.PriceEngine
{
    public class PriceEngine
    {
        private readonly List<QuotationSystem> _quotationSystemsList;

        public PriceEngine(List<QuotationSystem> quotationSystemsList)
        {
            _quotationSystemsList = quotationSystemsList;
        }

        public Option<PriceEngineResult> GetPrice(PriceRequest request)
        {
            var priceEngineResult = Option<PriceEngineResult>.Empty;
            foreach (var system in _quotationSystemsList)
            {
                var currentSystemResult = system.CalculatePrice();
                if (!priceEngineResult.HasValue && currentSystemResult.HasValue)
                {
                    priceEngineResult = currentSystemResult;
                }
                if (currentSystemResult.HasValue && priceEngineResult.HasValue && currentSystemResult.Value.Price < priceEngineResult.Value.Price)
                {
                    priceEngineResult = currentSystemResult;
                }
            }

            return priceEngineResult;
        }
    }
}
