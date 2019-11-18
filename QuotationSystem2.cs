﻿using System.Dynamic;

namespace ConsoleApp1
{
    public class QuotationSystem2: QuotationSystem
    {
        public QuotationSystem2(string url, string port)
        {

        }

        public override dynamic GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;

            return response;
        }
    }
}