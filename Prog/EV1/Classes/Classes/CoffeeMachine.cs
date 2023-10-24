using System;
using System.Security.Cryptography.X509Certificates;

namespace Classes
{
    public enum Estado
    {
        esperando,
        procesando_moneda,
        retirando_producto,
        devolviendo_cambio,
    }
    public class CoffeeMachine
    {
        private Estado _state;

        public CoffeeMachine()
        {
            _state = Estado.esperando;
        }
        public Estado GetState()
        {
            return _state;
        }
        
        public void ChangeToNextStage()
        {
            if (_state == Estado.esperando)
            {
                _state = Estado.procesando_moneda;
                return;
            }
            else if (_state == Estado.procesando_moneda)
            {
                _state = Estado.retirando_producto;
                return;
            }
            else if (_state == Estado.retirando_producto)
            {
                _state = Estado.devolviendo_cambio;
                return;
            }
                
            else
                _state = Estado.esperando;
        }
    }


}


    

