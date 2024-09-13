using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class LineaPedido
    {
        public Libro Libro {  get; set; } 
        public int Cantidad { get; set; }
        public LineaPedido(Libro libro, int cantidad)
        {
            Libro = libro;
            Cantidad = cantidad;
        }
        public void MostrarDetalles()
        {
            Console.WriteLine($"Libro ----------------- \n{Libro.Titulo} " +
                $"\nCantidad: {Cantidad}");
        }
        public decimal CalcularTotalLineaPedido()
        {
            return Libro.Precio * Cantidad;
        }
    }
}
