using ConsoleApp1.QuotationSystems.DTOs;

namespace ConsoleApp1.QuotationSystems
{
    public interface IQuotationSystem2Service
    {
        QuotationSystem2ResponseDto PostHttpRequest(QuotationSystem2RequestDto request);
    }

    public class QuotationSystem2Service: IQuotationSystem2Service
    {
        public QuotationSystem2ResponseDto PostHttpRequest(QuotationSystem2RequestDto request)
        {
            var response = new QuotationSystem2ResponseDto();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;

            return response;
        }
    }
}
