using System.Dynamic;

namespace ConsoleApp1
{
    public class QuotationSystem3: QuotationSystem
    {
        public QuotationSystem3(string url, string port, dynamic request)
        {

        }

        public override dynamic GetPrice()
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 92.67M;
            response.IsSuccess = true;
            response.Name = "zxcvbnm";
            response.Tax = 92.67M * 0.12M;

            return PricePostProcessor(response);
        }

        public override dynamic PricePostProcessor(dynamic system3Response)
        {
            if (system3Response.IsSuccess)
            {
                return new PriceEngineResult()
                {
                    Price = system3Response.Price,
                    InsurerName = system3Response.Name,
                    Tax = system3Response.Tax
                };
            }

            return null;
        }
    }
}