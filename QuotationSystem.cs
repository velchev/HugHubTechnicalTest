using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public abstract class QuotationSystem
   {
       public virtual bool IsValid => true;
       public dynamic CalculatePrice()
       {
           if (IsValid)
           {
               return this.GetPrice();
           }

           return null;//TODO
       }
        public abstract dynamic GetPrice();
        public abstract dynamic PricePostProcessor(dynamic price);
   }
}
