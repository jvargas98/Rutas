using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas
{
    class Base
    {
        private string _nombre;
        private int _minutos;
        Base _siguiente = null;
        Base _anterior = null;

        public string Nombre
        {
            get { return _nombre; }
        }
        public int Minutos
        {
            get { return _minutos; }
        }
        public Base Siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }

        }
        public Base Anterior
        {
            get { return _anterior; }
            set { _anterior = value; }
        }

        public Base(string nombre, int minutos)
        {
            _nombre = nombre;
            _minutos = minutos; 
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = _nombre + " " + _minutos + Environment.NewLine;

            return cadena;
        }

    }
}
