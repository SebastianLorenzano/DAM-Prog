namespace TPVLib
{
    public interface Idatabase
    {

        long AddProduct(Product product);
        void RemoveProductWithID(long id);
        Product? GetProductWithID(long id);
        void UpdateProductWithID(long id, Product product);
        List<Product> GetProducts(int offset, int limit);

        long AddTicketHeader(Ticker);
        void AddTicketBody(TicketBody body);

    }
}
