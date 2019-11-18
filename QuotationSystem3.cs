using System.Dynamic;

namespace ConsoleApp1
{
    public class QuotationSystem3: QuotationSystem
    {
        public QuotationSystem3(string url, string port)
        {

        }

        public dynamic GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 92.67M;
            response.IsSuccess = true;
            response.Name = "zxcvbnm";
            response.Tax = 92.67M * 0.12M;

            return response;
        }

        public override dynamic GetPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}