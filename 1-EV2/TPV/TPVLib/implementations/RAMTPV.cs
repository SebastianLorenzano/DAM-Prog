namespace TPVLib
{

    internal class RAMTPV : ITPV
    {

        private Dictionary<long, Product> _products = new();
        private Dictionary<long, Ticket> _tickets = new();
        private IDatabase _db;

        public RAMTPV (IDatabase db)
        {
            _db = db;
        }

        public long AddProduct(Product product)
        {
            long id = -1;
            try
            {
                id = _db.AddProduct(product.Clone());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id;
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            try
            {
                return _db.GetProducts(offset, limit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
        }

        public Product? GetProductWithID(long id)
        {
            return _db.GetProductWithID(id);
        }

        public Product? GetProductWithName(string name)
        {
            return _db.GetProductWithName(name);
        }

        public bool RemoveProductWithID(long id)
        {
            bool result = false;
            try
            {
                _db.RemoveProductWithID(id);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void UpdateProductWithID(long id, Product product)
        {
            try
            {
                _db.UpdateProductWithID(id, product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




/*
        public long AddTicket(Ticket ticket)
        {
            try
            {
                _database.BeginTransaction();

                long id = _database.AddTicket(ticket.Header);
                

            }
            catch (Exception ex)
            { 
            
            }
        }
*/

        public bool AddTicketBodyWithId(long id, TicketBody body)
        {
            Line[] array = body._lines.ToArray();        
        }

        public List<Line> GetTicketLinesWithId(long id, Ticket body)
        {
            var result = new List<Line>();



        }

    }
}