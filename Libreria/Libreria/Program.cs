/*
Desafío para entregar el viernes

Librería Web

Una librería vende sus productos a través de Internet.  Para esto ha decidido implementar un sistema que 
permita realizar las ventas, el armado y envío de los pedidos y el manejo de inventario.
Una vez que el usuario se loguea, el sistema verifica que el usuario sea un cliente registrado y muestra 
los distintos rubros de libros existentes. Una vez que el usuario selecciona el rubro, el sistema muestra el 
catálogo de libros. El usuario selecciona el o los libros a comprar e ingresa la cantidad a comprar, 
el sistema va guardando cada uno de los libros ingresados. 
Una vez que el usuario terminó de ingresar los libros, el sistema solicita la confirmación de la compra. 
Cuando el usuario confirma, el sistema verifica que haya stock suficiente de cada uno de los libros 
elegidos para poder cumplimentar el pedido. 
Si no hay stock suficiente, el sistema solicita que se elimine el libro de la compra o se modifique 
la cantidad a comprar. Si hay stock suficiente, el sistema calcula el total de la compra, guarda la compra 
asociándola al usuario y solicita los datos de la tarjeta de crédito (número de tarjeta, fecha de 
vencimiento y código de seguridad) con la que se realizará el pago. Una vez verificada la tarjeta, el 
sistema guarda el pago asociado a la compra, descuenta la cantidad de cada libro del stock  y finaliza 
la compra.

 */
using System;
using System.Collections.Generic;
using System.Numerics;
using Libreria;
using Libreria.enums;

public class Program
{
    static void Main()
    {
        //Crear Cliente con su tarjeta y agregarlo a la lista
        Tarjeta tarjetaCliente1 = new Tarjeta(0001, 030, "1/1");
        Cliente cliente1 = new Cliente("juan", "1234", tarjetaCliente1);
        List<Tarjeta> tarjetas = new List<Tarjeta>();
        tarjetas.Add(tarjetaCliente1);
        List<Cliente> clientes = new List<Cliente>();
        clientes.Add(cliente1);

        //agregar libro e incluirlo en la Libreria
        Libro libro1 = new Libro(1, "Biblia", "Dios", Libreria.enums.Rubro.HISTORIA, 5, 10);
        List<Libro> libros = new List<Libro>();
        libros.Add(libro1);

        //login
        Console.Write("Ingrese su Usuario: ");
        string nombreTemporal = Console.ReadLine();
        Console.Write("Ingrese su Contraseña: ");
        string contraseñaTemporal = Console.ReadLine();
        Cliente clienteTemporal = null;
        foreach (Cliente cliente in clientes)
        {
            if (nombreTemporal == cliente.Nombre)
            {
                if (contraseñaTemporal == cliente.Contraseña)
                {
                    clienteTemporal = cliente;
                }
                else
                {
                    Console.WriteLine("Contraseña Incorrecta");
                    return;
                }
            }
            else
            {
                Console.WriteLine("No existe ese cliente en el sistema.");
                return;
            }
        }

        //Seleccionar rubro
        Console.WriteLine("******************************************");
        Console.WriteLine("Seleccione el rubro (indique el numero correspondiente.");
        foreach (var rubro in Enum.GetValues(typeof(Libreria.enums.Rubro)))
        {
            Console.WriteLine($"{((int)rubro) + 1} - {rubro}");
        }

        int respuesta1 = int.Parse(Console.ReadLine());
        Rubro rubroSeleccionado = Rubro.CIENCIA; //predeterminado
        switch (respuesta1)
        {
            case 1:
                rubroSeleccionado = Rubro.HISTORIA;
                break;
            case 2:
                rubroSeleccionado = Rubro.TERROR;
                break;
            case 3:
                rubroSeleccionado = Rubro.CIENCIA;
                break;
            default:
                Console.WriteLine("No ha seleccionado un rubro valido.");
                break;
        }
        foreach (Libro libro in libros)
        {
            if (rubroSeleccionado == libro.Rubro && libro != null)
            {
                libro.MostrarDetallesMenor();
            }
            else
            {
                Console.WriteLine("No hay libros de este rubro.");
            }
        }

        //seleccionar libro y cantidad
        string respuestaWhile;
        List<LineaPedido> ordenDeCompra = new List<LineaPedido>();
        decimal totalOrdenCompra = 0;
        do {
            Console.WriteLine($"Seleccione uno de los libros del rubro {rubroSeleccionado}." +
            $"\nIndique el numero correspondiente del libro");
            int respuesta3 = int.Parse(Console.ReadLine());
            LineaPedido lineaTemporal = null;
            foreach (Libro libro in libros)
            {
                if (respuesta3 == libro.Id)
                {
                    Console.WriteLine($"Ha seleccionado el libro: {libro.Titulo}.");
                    Console.WriteLine("¿Cuantas unidades del libro seleccionado desea llevar?");
                    int cantidad = int.Parse(Console.ReadLine());
                    if (cantidad <= libro.Stock)
                    {
                        lineaTemporal = new LineaPedido(libro, cantidad);
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente stock de este ejemplar. Ingrese otra cantidad menor a {libro.Stock} o '0' para no ingresar ninguno. ");
                        cantidad = int.Parse(Console.ReadLine());
                        if (cantidad > 0)
                        {
                            lineaTemporal = new LineaPedido(libro, cantidad);
                        }
                    }
                }
            }
            if (lineaTemporal != null)
            {
                ordenDeCompra.Add(lineaTemporal);
                Console.WriteLine("El libro ha sido añadido a la orden.");
                decimal totalLineaPedido = lineaTemporal.CalcularTotalLineaPedido();
                totalOrdenCompra = totalOrdenCompra + totalLineaPedido;
                Console.WriteLine($"Total en el carrito hasta el momento: ${totalOrdenCompra}");
            }
            else
            {
                Console.WriteLine("No se ha añadido ningún libro a la orden.");
            }
            Console.WriteLine("¿Desea agregar otro libro? (S/N)");
            respuestaWhile = Console.ReadLine().ToUpper();
        } while (respuestaWhile == "S");

        //efectuar compra y actualizar stock.
        Console.WriteLine("******************************************");
        Console.WriteLine($"El total del pedido a pagar es de ${totalOrdenCompra}");
        Console.WriteLine("¿Desea confirmar la compra? (S/N)");
        string respuesta2 = Console.ReadLine().ToUpper();
        if (respuesta2 == "S")
        {
            Console.WriteLine("Ingrese los datos correspondientes de su tarjeta: ");
            Console.Write("Numero de tarjeta: ");
            int numeroDeTarjetaTemporal = int.Parse(Console.ReadLine());
            Console.Write("Codigo de seguridad: ");
            int codigoSeguridadTemporal = int.Parse(Console.ReadLine());
            Console.Write("Fecha de Vencimiento: ");
            string fechaVencimientoTemporal = Console.ReadLine();
            foreach(Tarjeta tarjeta in tarjetas)
            {
                if(clienteTemporal.TarjetaCliente == tarjeta)
                {
                    if(clienteTemporal.TarjetaCliente.NumeroTarjeta == numeroDeTarjetaTemporal)
                    {
                        if(clienteTemporal.TarjetaCliente.CodigoSeguridad == codigoSeguridadTemporal)
                        {
                            if(clienteTemporal.TarjetaCliente.FechaVencimiento == fechaVencimientoTemporal)
                            {
                                Console.WriteLine("Compra Realizada - DETALLES DE LA COMPRA:");
                                foreach(LineaPedido linea in ordenDeCompra)
                                {
                                    linea.MostrarDetalles();
                                    linea.Libro.ActualizarStock(linea.Cantidad);
                                }
                                Console.WriteLine($"TOTAL: ${totalOrdenCompra}");
                                Console.WriteLine("Compra finalizada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Informacion de tarjeta incorrecta. Compra cancelada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Informacion de tarjeta incorrecta. Compra cancelada.");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Compra Cancelada.");
        }

    }
}