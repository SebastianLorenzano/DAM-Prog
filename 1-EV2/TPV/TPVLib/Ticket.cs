using System.ComponentModel.DataAnnotations;
using TPVLib;

namespace TPVLib
{

    public class TicketHeader
    {
        
    }

    public class TicketBody
    {
        public List<TicketLine> _lines; 

        public void RemoveLine(TicketLine line)
        {
            _lines.Remove(line);
        }

    }

    public class TicketLine
    { 

        private int _cantidad;
        private WeakReference<TicketBody> _body;
        private Product _product;
        public int Cantidad
        {
            get => _cantidad;
            set 
            {
                if (value == 0)
                    Body.RemoveLine(this);

                if (value > 1000000)
                    throw new ArgumentOutOfRangeException("The amount is invalid.");
            }
        }

        public Product Product
        {
            get => _product.Clone();

            set => _product = value.Clone();
        }

        public TicketBody Body
        {
            get
            {
                var body = _body.TryGetTarget(out var target) ? target : null;
                return body;

            }
            set
            {
                if (value == null)
                    Body.RemoveLine(this);
            }
        }

        public TicketLine(Product product, int cantidad, TicketBody body)
        {
            Product = product;
            Cantidad = cantidad;
            Body = new WeakReference<TicketBody>(body);
        }
    }
}

    public class Ticket
    {
        public TicketHeader Header { get; set; }
        public TicketBody Body { get; set; }
        
        


    }
}
