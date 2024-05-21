using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Reserva
    {
        private string _nif = String.Empty;
        private int _numPlazas;

        public string Nif { get => _nif; set => SetNif(value);}
        public int NumPlazas { get => _numPlazas; set => SetNumPlazasValido(value); }

        public Reserva() 
        { 
        }

        public void SetNif(string nif)
        {
            if (!EsNifValido(nif))
                throw new ArgumentException();
            _nif = nif;
        }

        public void SetNumPlazasValido(int num)
        {
            if (!EsNumPlazasValido(num))
                throw new ArgumentException();
            _numPlazas = num;
        }

        public bool EsNifValido(string nif) 
        {
            if (nif == null)
                return false;
            if (nif.Length != 9)
                return false;
            string letra = nif.Substring(8);
            string numeros = nif.Substring(0, 8);
            int num;
            return !int.TryParse(letra, out num) && int.TryParse(numeros, out num);  // Si podes convertir letra a un numero, no es una letra y es invalido. Si no puedes convertir los primeros 8 lugares del _nif,
        }                                                                             // no son todos numeros, por lo cual es invalido. Para ser valido, tiene que ser valido en ambas.
        
        public bool EsNumPlazasValido(int value)
        {
            return value > 0 && value <= 50;
        }
        
    }
}
