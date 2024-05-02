using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVLib
{
    internal class GuardandoCodigo
    {


        // Aca guardo codigo que tuve que borrar pero quiero conservar para otro momento


        /*
        internal class Pepe : ITPV
        {

            private Dictionary<long, Product> _products = new();
            private Dictionary<long, Ticket> _tickets = new();
            private IDatabase _db;

            public Pepe(IDatabase db)    //Inyeccion de dependencias
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


            }
        */
        }
    }

