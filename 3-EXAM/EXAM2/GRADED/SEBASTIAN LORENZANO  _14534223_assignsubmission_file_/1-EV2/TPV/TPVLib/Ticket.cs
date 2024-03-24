namespace TPVLib
{

    public class Ticket
    {
        // Javi: Yo hubiese creado el header y el body
        public TicketHeader Header { get; set; }
        public TicketBody Body { get; set; }

    }


    public class TicketHeader
    {
        public long TicketId;
        public string ScanBar { get; set; }
        public DateTime date { get; set; }
        // Javi: Name?!?!!?!??!
        public string name { get; set; }

        public TicketHeader Clone()
        {
            return new TicketHeader()
            {
                TicketId = TicketId,
                ScanBar = ScanBar,
                date = date,
                name = name
            };
        }
    }

    public class TicketBody
    {
        public long TicketId;

        // Javi: PAra ser lo más POJO, mejor public
        internal List<TicketLine> _lines = new();

        public TicketLine[] ArrayTo()
        {
            return _lines.ToArray();
        }

        public TicketBody Clone()
        {
            return new TicketBody()
            {
                TicketId = TicketId,
                _lines = new List<TicketLine>(_lines)
            };
        }

    }

    public class TicketLine
    {
        public long TicketId;

        public Product _product;
        public int Cantidad { get; set; }

        public Product Product
        {
            get => _product.Clone();

            set => _product = value.Clone();
        }

        public TicketLine(Product product, int cantidad)
        {
            Product = product;
            Cantidad = cantidad;
        }
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


