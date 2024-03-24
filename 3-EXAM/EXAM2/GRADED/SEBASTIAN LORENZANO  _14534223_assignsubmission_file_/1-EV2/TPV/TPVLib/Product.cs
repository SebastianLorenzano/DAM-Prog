using System.Data;

namespace TPVLib
{

    public enum StateType
    {
        UNAVAILABLE,
        AVAILABLE,
    }

    public enum TaxType
    {
        CERO,
        UNO,
        DOS
    }

    public class Product
    {
        public long Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
        public int Stock { get; set;}
        public StateType State { get; set;}
        public TaxType Tax { get; set;}


        public Product Clone()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                Stock = Stock,
                State = State,
                Tax = Tax,
            };
        }
    }
}
