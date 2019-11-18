using System.Dynamic;

namespace ConsoleApp1
{
    public class QuotationSystem1 : QuotationSystem
    {
        private readonly dynamic request;

        public QuotationSystem1(string url, string port, dynamic request)
        {
            this.request = request;
        }

        public override PriceEngineResult GetPrice()
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 123.45M;
            response.IsSuccess = true;
            response.Name = "Test Name";
            response.Tax = 123.45M * 0.12M;

            return PricePostProcessor(response);
        }

        public override PriceEngineResult PricePostProcessor(dynamic system1Response)
        {
            if (system1Response.IsSuccess)
            {
                return new PriceEngineResult()
                {
                    Price = system1Response.Price,
                    InsurerName = system1Response.Name,
                    Tax = system1Response.Tax

                };
            }

            return null;
        }

        public override bool IsValid => (request.RiskData.DOB != null);
    }
}