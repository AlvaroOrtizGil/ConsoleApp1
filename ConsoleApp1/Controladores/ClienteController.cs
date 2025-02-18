using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Controllers
{
    public class ClienteController
    {
        private readonly DbContext _context;

        public ClienteController(DbContext context)
        {
            _context = context;
        }

        // Método para crear un nuevo cliente
        public void CrearCliente(string nombre, string dni, string? telefono, string? email)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nombre = nombre,
                    Dni = dni,
                    Telefono = telefono,
                    Email = email
                };

                cliente.CrearCliente();  // Crear cliente usando el método de la clase Cliente
                Console.WriteLine("Cliente creado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
            }
        }

        // Método para obtener todos los clientes
        public List<Cliente> ObtenerClientes()
        {
            try
            {
                return Cliente.ObtenerClientes(_context);  // Llamada al método estático para obtener clientes
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                return new List<Cliente>(); // Retorna una lista vacía en caso de error
            }
        }

        // Método para obtener un cliente por ID
        public Cliente ObtenerClientePorId(int id)
        {
            try
            {
                var cliente = Cliente.ObtenerClientePorId(_context, id);
                if (cliente == null)
                {
                    Console.WriteLine($"Cliente con ID {id} no encontrado.");
                }
                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cliente: {ex.Message}");
                return null;
            }
        }

        // Método para actualizar un cliente
        public void ActualizarCliente(int id, string nombre, string dni, string? telefono, string? email)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = id,
                    Nombre = nombre,
                    Dni = dni,
                    Telefono = telefono,
                    Email = email
                };

                cliente.ActualizarCliente();  // Actualizar cliente usando el método de la clase Cliente
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
            }
        }

        // Método para eliminar un cliente por ID
        public void EliminarCliente(int id)
        {
            try
            {
                var cliente = new Cliente { Id = id };  // No es necesario pasar el contexto
                cliente.EliminarCliente();  // Eliminar cliente usando el método de la clase Cliente
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
            }
        }
    }
}
