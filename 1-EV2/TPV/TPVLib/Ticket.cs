using System.ComponentModel.DataAnnotations;
using TPVLib;

namespace TPVLib
{

    public class Ticket
    {
        public Header Header { get; set; }
        public Body Body { get; set; }




    }


    public class Header
    {
        public long Id { get; set; }
        public string ScanBar { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
    }

    public class Body
    {
        public List<Line> _lines; 

        public void RemoveLine(Line line)
        {
            _lines.Remove(line);
        }

    }

    public class Line
    { 

        private int _cantidad;
        private WeakReference<Body> _body = new WeakReference<Body>(null);
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

        public Body Body
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

        public Line(Product product, int cantidad, Body body)
        {
            Product = product;
            Cantidad = cantidad;
            Body = body;
        }
    }
}

   
}
