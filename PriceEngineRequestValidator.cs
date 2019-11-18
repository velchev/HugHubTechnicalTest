using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PriceEngineRequestValidator
    {
        public static Tuple<bool, string> IsValid(PriceRequest priceRequest)
        {
            //validation
            if (priceRequest.RiskData == null)
            {
                return new Tuple<bool, string>(false, "Risk Data is missing");
            }

            if (String.IsNullOrEmpty(priceRequest.RiskData.FirstName))
            {
                return new Tuple<bool, string>(false, "First name is required");
            }

            if (String.IsNullOrEmpty(priceRequest.RiskData.LastName))
            {
                return new Tuple<bool, string>(false, "Surname is required");
            }

            if (priceRequest.RiskData.Value == 0)
            {
                return new Tuple<bool, string>(false, "Value is required");
            }

            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
