namespace TPVLib
{

    internal class RAMTPV : ITPV
    {
        private int nextGeneratedId = 1;
        private Dictionary<long, Product> _products = new();
        public long AddProduct(Product product)
        {
            if (product == null)
                throw new Exception("Adding a Product Failed");
            Product newProduct = product.Clone();
            long index = nextGeneratedId++;
            newProduct.Id = index;
            _products.Add(index, newProduct);
            return index;
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            var result = new List<Product>();
            if (offset < 0 || offset > _products.Count)
                return result;
            limit = Math.Min(limit, _products.Count);
            for (int i = 0; i < limit; i++)
            {
                result.Add(_products[i + offset]);
            }
            return result;
        }

        public Product? GetProductWithID(long id)
        {
            foreach (var product in _products)
            {
                if (product.Key == id)
                    return product.Value.Clone();
            }
            return null;
        }

        public Product? GetProductWithName(string name)
        {
            foreach (var product in _products)
            {
                if (product.Value.Name == name)
                    return product.Value.Clone();
            }
            return null;
        }



        public void RemoveProductWithID(long id)
        {
            _products.Remove(id);
        }

        public void UpdateProductWithID(long id, Product product)
        {
            Product? productInList;
            if (_products.TryGetValue(id, out productInList))
                productInList = product;
        }

    }
}