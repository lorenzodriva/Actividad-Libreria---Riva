using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Tarjeta
    {
        private long _numeroTarjeta;
        private int _codigoSeguridad;
        private string _fechaVencimiento;

        public long NumeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }
        public int CodigoSeguridad
        {
            get { return _codigoSeguridad; }
            set { _codigoSeguridad = value;}
        }
        public string FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }
        public Tarjeta(long numeroTarjeta, int codigoSeguridad, string fechaVencimiento)
        {
            NumeroTarjeta = numeroTarjeta;
            CodigoSeguridad = codigoSeguridad;
            FechaVencimiento = fechaVencimiento;
        }
    }
}
