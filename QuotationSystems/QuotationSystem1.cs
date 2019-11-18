using ConsoleApp1.QuotationSystems.DTOs;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem1 : QuotationSystem
    {
        private readonly string _url;
        private readonly string _port;
        private readonly QuotationSystem1RequestDto _request;

        public QuotationSystem1(string url, string port, PriceRequest request)
        {
            _url = url;
            _port = port;
            var req = new QuotationSystem1RequestDto();
            req.FirstName = request.RiskData.FirstName;
            req.Surname = request.RiskData.LastName;
            req.DOB = request.RiskData.DOB;
            req.Make = request.RiskData.Make;
            req.Amount = request.RiskData.Value;

            _request = req;
        }

        protected override Option<PriceEngineResult> GetPrice()
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            var response = new QuotationSystem1ResponseDto();
            response.Price = 123.45M;
            response.IsSuccess = true;
            response.Name = "Test Name";
            response.Tax = 123.45M * 0.12M;

            return PricePostProcessor(response);
        }

        protected Option<PriceEngineResult> PricePostProcessor(QuotationSystem1ResponseDto system1Response)
        {
            if (system1Response.IsSuccess)
            {
                return Option.Create(new PriceEngineResult()
                {
                    Price = system1Response.Price,
                    InsurerName = system1Response.Name,
                    Tax = system1Response.Tax
                });
            }

            return Option<PriceEngineResult>.Empty;
        }

        protected override bool CanCalculatePrice => (_request.DOB != null);
    }
}