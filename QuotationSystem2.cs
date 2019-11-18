using System.Dynamic;

namespace ConsoleApp1
{
    public class QuotationSystem2: QuotationSystem
    {
        private readonly dynamic request;
        public QuotationSystem2(string url, string port, dynamic request)
        {
            this.request = request;
        }

        public override dynamic GetPrice()
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;

            return PricePostProcessor(response);
        }

        public override dynamic PricePostProcessor(dynamic system2Response)
        {
            if (system2Response.HasPrice)
            {
                return new PriceEngineResult()
                {
                    Price = system2Response.Price,
                    InsurerName = system2Response.Name,
                    Tax = system2Response.Tax
                };
            }

            return null;
        }

        public override bool IsValid
        {
            get
            {
                return (request.RiskData.Make == "examplemake1" || request.RiskData.Make == "examplemake2" ||
                        request.RiskData.Make == "examplemake3");
            }
    }
    }
}