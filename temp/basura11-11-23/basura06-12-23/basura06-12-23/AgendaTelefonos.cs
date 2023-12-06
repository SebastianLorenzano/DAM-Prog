using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basura06_12_23
{
    public class AgendaTelefonos
    {
        private int maxCount;
        private List<Contacto> _contactos = new List<Contacto>();

        public List<Contacto> GetContactos()
        {
            return _contactos;
        }



        
    }



    public class Contacto
    {
        private string _nombre;
        private string _numero;


        public string GetNombre()
        {
            return _nombre;
        }

        public string GetNumero() 
        {
            return _numero;
        }

        public void SetNombre(string nombre)
        {
            if (nombre != null || nombre != "") 
                _nombre = nombre;
        }

        public void SetNumero(string numero)
        {
            if (numero.Length >= 9 && numero.Length <= 14)
                _numero = numero;
        }

    }
}
