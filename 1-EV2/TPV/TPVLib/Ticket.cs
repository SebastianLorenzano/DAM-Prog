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
        public long id;
        public string ScanBar { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
    }

    public class TicketBody
    {
        public long id;


        public List<Line> _lines = new();

        public void RemoveLine(Line line)
        {
            _lines.(line);
        }

    }

    public class Line
    {
        public long _id;

        private Product _product;
        public int Cantidad { get; set; }

        public Product Product
        {
            get => _product.Clone();

            set => _product = value.Clone();
        }

        public Line(Product product, int cantidad)
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


