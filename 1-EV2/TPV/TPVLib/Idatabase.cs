namespace TPVLib
{
    public interface IDatabase
    {
        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
        void Close();


        long AddProduct(Product product);
        void RemoveProductWithID(long id);
        Product? GetProductWithID(long id);
        Product GetProductWithName(string name);
        void UpdateProductWithID(long id, Product product);
        List<Product> GetProducts(int offset, int limit);

        long AddTicketHeader(TicketHeader header);
        Ticket GetTicketWithID(long id);



    }
}
