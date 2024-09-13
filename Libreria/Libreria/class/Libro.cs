using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Libreria.enums;

namespace Libreria
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo {  get; set; }
        public string Autor { get; set; }
        public Rubro Rubro { get; set; }
        public int Stock {  get; set; }
        public decimal Precio { get; set; }

        public Libro(int id, string titulo, string autor, Rubro rubro, int stock, decimal precio)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Rubro = rubro;
            Stock = stock;
            Precio = precio;
        }
        public void MostrarDetallesMenor()
        {
            Console.WriteLine($"ID: {Id} - Titulo: {Titulo} - " +
                $"Autor: {Autor} - " +
                $"Precio: {Precio}");
        }
        public void MostrarDetalles()
        {
            MostrarDetallesMenor();
            Console.WriteLine($" - Rubro: {Rubro} - " +
                $"Stock: {Stock}");
        }
        public void ActualizarStock(int cantidad)
        {
            Stock =+ cantidad;
        }
    }
}
