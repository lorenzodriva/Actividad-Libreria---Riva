using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Cliente
    {
        private string _nombre;
        private string _contraseña;
        public Tarjeta TarjetaCliente {  get; set; }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public Cliente(string nombre, string contraseña, Tarjeta tarjetaCliente)
        {
            _nombre = nombre;
            _contraseña = contraseña;
            TarjetaCliente = tarjetaCliente;
        }
    }
}
