namespace ConsoleApp1.QuotationSystems
{
   public abstract class QuotationSystem
   {
       protected virtual bool CanCalculatePrice => true;

       public Option<PriceEngineResult> CalculatePrice()
       {
           if (CanCalculatePrice)
           {
               return this.GetPrice();
           }

           return Option<PriceEngineResult>.Empty;
       }

       protected abstract Option<PriceEngineResult> GetPrice();
   }
}
