using ConsoleApp1.QuotationSystems.DTOs;

namespace ConsoleApp1.QuotationSystems
{
    public class QuotationSystem3 : QuotationSystem
    {
        private readonly string _url;
        private readonly string _port;
        private readonly dynamic _request;
        public QuotationSystem3(string url, string port, PriceRequest request)
        {
            _url = url;
            _port = port;
            var req = new QuotationSystem3RequestDto();

            req.FirstName = request.RiskData.FirstName;
            req.Surname = request.RiskData.LastName;
            req.DOB = request.RiskData.DOB;
            req.Make = request.RiskData.Make;
            req.Amount = request.RiskData.Value;
            this._request = req;
        }

        protected override Option<PriceEngineResult> GetPrice()
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            var response = new QuotationSystem3ResponseDto();
            response.Price = 92.67M;
            response.IsSuccess = true;
            response.Name = "zxcvbnm";
            response.Tax = 92.67M * 0.12M;

            return PricePostProcessor(response);
        }

        private Option<PriceEngineResult> PricePostProcessor(QuotationSystem3ResponseDto system3Response)
        {
            if (system3Response.IsSuccess)
            {
                return Option.Create(new PriceEngineResult()
                {
                    Price = system3Response.Price,
                    InsurerName = system3Response.Name,
                    Tax = system3Response.Tax
                });
            }

            return Option<PriceEngineResult>.Empty;
        }
    }
}