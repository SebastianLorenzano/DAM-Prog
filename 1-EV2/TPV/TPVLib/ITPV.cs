namespace TPVLib
{
    public interface ITPV       // CRUD CREATE READ UPDATE DELETE
    {
        // long AddProduct(Product product) Throws Exception;    Devuelve un long que es el id de donde lo pone la base de datos
        // void RemoveProductWithID(long id) Throws Exception;
        // Product? GetProductWithID(long id);
        // void UpdateProductWithID(long id, Product product) Throws Exception;
        // List<Product> GetProducts(int offset, int limit)     offset = desde donde empieza   count = cuantos agarra

        long AddProduct(Product product);
        bool RemoveProductWithID(long id);
        Product? GetProductWithID(long id);
        void UpdateProductWithID(long id, Product product);
        List<Product> GetProducts(int offset, int limit);


        static ITPV CreateNewTPV()
        {
            return new RAMTPV();
        }
    }
}
