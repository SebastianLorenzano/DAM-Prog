using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Reserva
    {
        private string nif = String.Empty;
        private int numPlazas;

        public string Nif
        {
            get
            {
                return nif;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El NIF no puede estar vacío");
                nif = value;
            }
        }

        public int NumPlazas
        {
            get { return numPlazas; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El número de plazas debe ser mayor que cero");
                numPlazas = value;
            }
        }
        //public bool NifValido =>      //TODO
        //public bool NumPlazasValido =>

        /*/public bool EsNifValido
        {
        }

        */
        /*
        public bool numPlazasValido
        {

        }
        */
    }
}
