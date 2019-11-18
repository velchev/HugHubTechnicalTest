using ConsoleApp1.QuotationSystems.DTOs;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem2 : QuotationSystem
    {
        private readonly string _url;
        private readonly string _port;
        private readonly QuotationSystem2RequestDto _request;
        private readonly IQuotationSystem2Service _quotationSystem2Service;
        public QuotationSystem2(string url, string port, PriceRequest request, IQuotationSystem2Service quotationSystem2Service)
        {
            _url = url;
            _port = port;
            _quotationSystem2Service = quotationSystem2Service;
            var req = new QuotationSystem2RequestDto();
            req.FirstName = request.RiskData.FirstName;
            req.LastName = request.RiskData.LastName;
            req.Make = request.RiskData.Make;
            req.Value = request.RiskData.Value;

            _request = req;
        }

        protected override Option<PriceEngineResult> GetPrice()
        {
           return PricePostProcessor(_quotationSystem2Service.PostHttpRequest(_request));
        }

        private Option<PriceEngineResult> PricePostProcessor(QuotationSystem2ResponseDto system2Response)
        {
            if (system2Response.HasPrice)
            {
                return Option.Create(new PriceEngineResult()
                {
                    Price = system2Response.Price,
                    InsurerName = system2Response.Name,
                    Tax = system2Response.Tax
                });
            }

            return Option<PriceEngineResult>.Empty;
        }

        protected override bool CanCalculatePrice =>
            (_request.Make == "examplemake1" || _request.Make == "examplemake2" ||
             _request.Make == "examplemake3");
    }
}