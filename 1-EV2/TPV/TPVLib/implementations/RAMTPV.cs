namespace TPVLib
{

    internal class RAMTPV : ITPV
    {
        private int nextGeneratedId = 1;
        private Dictionary<long, Product> _products = new();
        public long AddProduct(Product product)
        {
            if (product == null)
                return -1;
            Product newProduct = product.Clone();
            long index = nextGeneratedId++;
            newProduct.Id = index;
            _products.Add(index, newProduct);
            return index;
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductWithID(long id)
        {
            foreach (var product in _products)
            {
                if (product.Key == id)
                    return product.Value;
            }
            return null;
        }

        public void RemoveProductWithID(long id)
        {
            foreach (var product in _products)
            {
                if (product.Key == id)
                    _products.Remove(id);
            }
        }

        public void UpdateProductWithID(long id, Product product)
        {
            Product? productInList;
            if (_products.TryGetValue(id, out productInList))
                productInList = product;
            
        }





    }
}