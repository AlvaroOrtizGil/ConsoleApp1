using ConsoleApp1.Controllers;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la cadena de conexión para MySQL en XAMPP
            var connectionString = "Server=localhost;Database=coches;User=root;Password=";

            var options = new DbContextOptionsBuilder<CochesContext>()
                            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                            .Options;

            // Crear un contexto para interactuar con la base de datos
            using (var context = new CochesContext(options))
            {
                // Crear instancia del controlador
                var clienteController = new ClienteController(context);

                // Crear un cliente
                clienteController.CrearCliente("Juan Pérez", "11345278A", "123456789", "juan.perez@email.com");

                // Mostrar todos los clientes
                var clientes = clienteController.ObtenerClientes();
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Cliente: {cliente.Nombre}, DNI: {cliente.Dni}, Teléfono: {cliente.Telefono}, Email: {cliente.Email}");
                }

                // Mostrar un cliente por su ID
                var clientePorId = clienteController.ObtenerClientePorId(1);
                if (clientePorId != null)
                {
                    Console.WriteLine($"Cliente encontrado: {clientePorId.Nombre}, DNI: {clientePorId.Dni}, Teléfono: {clientePorId.Telefono}, Email: {clientePorId.Email}");
                }

                // Actualizar un cliente
                clienteController.ActualizarCliente(1, "Juan Pérez Actualizado", "87654321B", "987654321", "juan.perez.actualizado@email.com");

                // Eliminar un cliente
                clienteController.EliminarCliente(1);
            }

            Console.ReadLine(); // Mantener la consola abierta para ver los resultados
        }
    }

}
