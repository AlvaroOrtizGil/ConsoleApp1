using ConsoleApp1.Controladores;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace ConsoleApp1.Controllers
{
    public class ClienteController
    {
        private readonly DbContext _context;

        public ClienteController(DbContext context)
        {
            _context = context;
        }
        
        // Crear un nuevo cliente
        public void CrearCliente(string nombre, string dni, string telefono, string email)
        {
            var nuevoCliente = new Cliente(_context)
            {
                Nombre = nombre,
                Dni = dni,
                Telefono = telefono,
                Email = email
            };
            nuevoCliente.CrearCliente();
            Console.WriteLine("Cliente creado con éxito.");
        }

        // Mostrar todos los clientes
        public void MostrarClientes()
        {
            var clientes = Cliente.ObtenerClientes(_context);
            Console.WriteLine("Clientes registrados:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, DNI: {cliente.Dni}");
            }
        }

        // Mostrar un cliente por ID
        public void MostrarClientePorId(int id)
        {
            var cliente = Cliente.ObtenerClientePorId(_context, id);
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nombre}, DNI: {cliente.Dni}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        // Actualizar un cliente
        public void ActualizarCliente(int id, string nuevoNombre, string nuevoDni, string nuevoTelefono, string nuevoEmail)
        {
            var cliente = Cliente.ObtenerClientePorId(_context, id);
            if (cliente != null)
            {
                cliente.Nombre = nuevoNombre;
                cliente.Dni = nuevoDni;
                cliente.Telefono = nuevoTelefono;
                cliente.Email = nuevoEmail;
                cliente.ActualizarCliente();
                Console.WriteLine("Cliente actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        // Eliminar un cliente
        public void EliminarCliente(int id)
        {
            var cliente = Cliente.ObtenerClientePorId(_context, id);
            if (cliente != null)
            {
                cliente.EliminarCliente();
                Console.WriteLine("Cliente eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
