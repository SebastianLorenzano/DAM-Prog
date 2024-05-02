namespace TPVLib
{
    public interface IDatabase
    {
        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
        void Close();


        long AddProduct(Product product);
        bool RemoveProductWithID(long id);
        Product? GetProductWithID(long id);
        Product GetProductWithName(string name);
        void UpdateProductWithID(long id, Product product);
        List<Product> GetProducts(int offset, int limit);


        long AddTicket(Ticket ticket);
        long AddTicketHeader(TicketHeader header);
        long AddTicketBodyWithId(long id, TicketBody body);
        long AddTicketLineWithId(long id, TicketLine line);
        Ticket GetTicketWithID(long id);



    }
}
