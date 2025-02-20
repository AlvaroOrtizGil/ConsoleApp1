using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Puesto { get; set; }

        public decimal? Salario { get; set; }

        public string? Telefono { get; set; }

        // Constructor sin parámetros para deserialización
        public Empleado() { }

        // Si necesitas un constructor personalizado que use DbContext
        // [JsonConstructor]
        // public Empleado(DbContext context) { _context = context; }

        // Métodos relacionados con la base de datos
        private readonly DbContext _context;

        public void CrearEmpleado()
        {
            _context.Set<Empleado>().Add(this);
            _context.SaveChanges();
        }

        public static List<Empleado> ObtenerEmpleados(DbContext context)
        {
            return context.Set<Empleado>().ToList();
        }

        public static Empleado ObtenerEmpleadoPorId(DbContext context, int id)
        {
            return context.Set<Empleado>().FirstOrDefault(e => e.Id == id);
        }

        public void ActualizarEmpleado()
        {
            var empleadoExistente = _context.Set<Empleado>().FirstOrDefault(e => e.Id == this.Id);
            if (empleadoExistente != null)
            {
                if (empleadoExistente.Nombre != this.Nombre)
                    empleadoExistente.Nombre = this.Nombre;
                if (empleadoExistente.Puesto != this.Puesto)
                    empleadoExistente.Puesto = this.Puesto;
                if (empleadoExistente.Salario != this.Salario)
                    empleadoExistente.Salario = this.Salario;
                if (empleadoExistente.Telefono != this.Telefono)
                    empleadoExistente.Telefono = this.Telefono;

                _context.Set<Empleado>().Update(empleadoExistente);
                _context.SaveChanges();
            }
        }

        public void EliminarEmpleado()
        {
            var empleado = _context.Set<Empleado>().FirstOrDefault(e => e.Id == this.Id);
            if (empleado != null)
            {
                _context.Set<Empleado>().Remove(empleado);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }
    }
}
