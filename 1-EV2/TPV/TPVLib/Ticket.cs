using System.ComponentModel.DataAnnotations;
using TPVLib;

namespace TPVLib
{

    public class Ticket
    {
        public TicketHeader Header { get; set; }
        public TicketBody Body { get; set; }




    }


    public class TicketHeader
    {
        public long Id { get; set; }
        public string ScanBar { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
    }

    public class TicketBody
    {
        public List<Line> _lines; 

        public void RemoveLine(Line line)
        {
            _lines.Remove(line);
        }

    }

    public class Line
    {
        public int cantidad; 
        private WeakReference<TicketBody> _body = new WeakReference<TicketBody>(null);
        private Product _product;
        public int Cantidad
        {
            get 
            {
                return cantidad;
            }
            set 
            {
                if (value == 0)
                    Body.RemoveLine(this);

                if (value > 1000000)
                    throw new ArgumentOutOfRangeException("The amount is invalid.");
            }
        }
        /*
        public int Cantidad => Cantidad;

        public void SetCantidad(int value)
        {
            if (value == 0)
                Body.RemoveLine(this);

            if (value > 1000000)
                throw new ArgumentOutOfRangeException("The amount is invalid.");
        }
        */




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

        public Line(Product product, int cantidad, TicketBody body)
        {
            Product = product;
            Cantidad = cantidad;
            Body = body;
        }
    }
}

   

