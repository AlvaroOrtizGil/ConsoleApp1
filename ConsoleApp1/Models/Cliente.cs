using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }


    // Constructor sin parámetros para deserialización
    public Cliente() { }

    // Si necesitas un constructor personalizado que use DbContext
    // [JsonConstructor]
    // public Cliente(DbContext context) { _context = context; }

    // Métodos relacionados con la base de datos
    private readonly DbContext _context;

    public void CrearCliente()
    {
        _context.Set<Cliente>().Add(this);
        _context.SaveChanges();
    }

    public static List<Cliente> ObtenerClientes(DbContext context)
    {
        return context.Set<Cliente>().ToList();
    }

    public static Cliente ObtenerClientePorId(DbContext context, int id)
    {
        return context.Set<Cliente>().FirstOrDefault(c => c.Id == id);
    }

    public void ActualizarCliente()
    {
        var clienteExistente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == this.Id);
        if (clienteExistente != null)
        {
            if (clienteExistente.Nombre != this.Nombre)
                clienteExistente.Nombre = this.Nombre;
            if (clienteExistente.Dni != this.Dni)
                clienteExistente.Dni = this.Dni;
            if (clienteExistente.Telefono != this.Telefono)
                clienteExistente.Telefono = this.Telefono;
            if (clienteExistente.Email != this.Email)
                clienteExistente.Email = this.Email;

            _context.Set<Cliente>().Update(clienteExistente);
            _context.SaveChanges();
        }
    }

    public void EliminarCliente()
    {
        var cliente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == this.Id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }
}
