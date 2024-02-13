namespace TPVLib
{
    public class Product
    {
        public long Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}


        public Product Clone()
        {
            Product result = new Product();
            result.Id = Id;
            result.Name = Name;
            result.Description = Description;
            result.Price = Price;
            return result;


        }

    }
}
