using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Alquilere> Alquileres { get; set; } = new List<Alquilere>();

    public virtual ICollection<Garantia> Garantia { get; set; } = new List<Garantia>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    // Contexto para la base de datos
    private readonly DbContext _context;

    public Cliente(DbContext context)
    {
        _context = context;
    }
    // Crear un nuevo cliente
    public void CrearCliente()
    {
        _context.Set<Cliente>().Add(this);
        _context.SaveChanges();
    }

    // Obtener todos los clientes
    public static List<Cliente> ObtenerClientes(DbContext context)
    {
        return context.Set<Cliente>().ToList();
    }

    // Obtener un cliente por su ID
    public static Cliente ObtenerClientePorId(DbContext context, int id)
    {
        return context.Set<Cliente>().FirstOrDefault(c => c.Id == id);
    }

    // Actualizar un cliente
    public void ActualizarCliente()
    {
        var clienteExistente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == this.Id);
        if (clienteExistente != null)
        {
            clienteExistente.Nombre = this.Nombre;
            clienteExistente.Dni = this.Dni;
            clienteExistente.Telefono = this.Telefono;
            clienteExistente.Email = this.Email;

            _context.Set<Cliente>().Update(clienteExistente);
            _context.SaveChanges();
        }
    }

    // Eliminar un cliente
    public void EliminarCliente()
    {
        var cliente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == this.Id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
            _context.SaveChanges();
        }
    }
}














