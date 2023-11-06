using System;


namespace ConsoleApp1
{

    public class Cliente
    {
        private int _edad;
        private string _nome, dni, direccion;

        private List<Cuenta> cuentas = new List<Cuenta>();
    }


    public class Cuenta
    {
        private long _id;

    }



}

