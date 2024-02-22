namespace TPVLib
{

    internal class RAMTPV : ITPV
    {

        private Dictionary<long, Product> _products = new();
        private Dictionary<long, TicketHeader> _ticketHeaders = new();
        private Dictionary<long, TicketLine> _ticketBodies = new();
        private IDatabase _db;

        public RAMTPV (IDatabase db)    //Inyeccion de dependencias
        {
            _db = db;
        }

        public long AddProduct(Product product)
        {
            return _db.AddProduct(product.Clone());
        }
        public List<Product> GetProducts(int offset, int limit)
        {
            return _db.GetProducts(offset, limit);
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

            return _db.RemoveProductWithID(id);
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
                    
        }

        public List<TicketLine> GetTicketLinesWithId(long id, Ticket body)
        {
            var result = new List<TicketLine>();



        }

    }
}