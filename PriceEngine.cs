using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PriceEngine
    {
        //pass request with risk data with details of a gadget, return the best price retrieved from 3 external quotation engines
        public PriceEngineResult GetPrice(PriceRequest request, out decimal tax, out string insurerName)
        {
            //initialise return variables
            tax = 0;
            insurerName = "";

            //now call 3 external system and get the best price
            decimal price = 0;

            List<QuotationSystem> systemList = new List<QuotationSystem>();
            dynamic systemRequest1 = new ExpandoObject();
            systemRequest1.FirstName = request.RiskData.FirstName;
            systemRequest1.Surname = request.RiskData.LastName;
            systemRequest1.DOB = request.RiskData.DOB;
            systemRequest1.Make = request.RiskData.Make;
            systemRequest1.Amount = request.RiskData.Value;

            QuotationSystem system1 = new QuotationSystem1("http://quote-system-1.com", "1234", systemRequest1);

            systemList.Add(system1);

            dynamic systemRequest2 = new ExpandoObject();
            systemRequest2.FirstName = request.RiskData.FirstName;
            systemRequest2.LastName = request.RiskData.LastName;
            systemRequest2.Make = request.RiskData.Make;
            systemRequest2.Value = request.RiskData.Value;

            QuotationSystem system2 = new QuotationSystem2("http://quote-system-2.com", "1235", systemRequest2);

            systemList.Add(system2);

            dynamic systemRequest3 = new ExpandoObject();

            systemRequest3.FirstName = request.RiskData.FirstName;
            systemRequest3.Surname = request.RiskData.LastName;
            systemRequest3.DOB = request.RiskData.DOB;
            systemRequest3.Make = request.RiskData.Make;
            systemRequest3.Amount = request.RiskData.Value;
            QuotationSystem system3 = new QuotationSystem3("http://quote-system-3.com", "100", systemRequest3);
            systemList.Add(system3);

            decimal priceAfterItaration = 0;
            var counter = 0;
            PriceEngineResult presult = systemList[0].GetPrice();
            foreach (var system in systemList)
            {
                var priceResult = system.GetPrice();

                if (counter == 0)
                {
                    presult = priceResult;
                }
                else
                {
                    if (priceResult.Price < presult.Price)
                    {
                        presult = priceResult;
                    }
                }

                counter++;
            }



            if (presult.Price == 0)
            {
                presult.Price = -1;
            }

            return presult;
        }
    }
}
