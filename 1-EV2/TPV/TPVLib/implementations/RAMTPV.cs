namespace TPVLib
{

    internal class RAMTPV : ITPV
    {
        public int _currentGeneratingId = 1;
        private List<Product> _products = new();
        public long AddProduct(Product product)
        {
            product.id = _currentGeneratingId++;
            Product newProduct = new(product);
            _products.Add(newProduct);
            return newProduct.id;
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductWithID(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductWithID(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductWithID(long id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}