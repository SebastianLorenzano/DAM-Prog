namespace TPVLib
{

    public class Ticket
    {
        public TicketHeader Header { get; set; }
        public TicketBody Body { get; set; }

    }


    public class TicketHeader
    {
        public long TicketId;
        public string ScanBar { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
    }

    public class TicketBody
    {
        public long TicketId;


        public List<TicketLine> _lines = new();
        public void RemoveLine(TicketLine line)
        {
            _lines.Remove(line);
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


