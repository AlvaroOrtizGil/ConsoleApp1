using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    public partial class Coch
    {
        public int Id { get; set; }
        public int id_modelo { get; set; }
        public string Matricula { get; set; } = null!;
        public string? Color { get; set; }
        public int? Anio { get; set; }
        public decimal? Precio { get; set; }

        // Constructor sin parámetros para deserialización
        public Coch() { }

        // Contexto de la base de datos
        private readonly DbContext _context;

        // Método para crear un coche en la base de datos
        public void CrearCoche()
        {
            _context.Set<Coch>().Add(this);
            _context.SaveChanges();
        }

        // Método estático para obtener todos los coches desde la base de datos
        public static List<Coch> ObtenerCoches(DbContext context)
        {
            return context.Set<Coch>().ToList();
        }

        // Método estático para obtener un coche por ID desde la base de datos
        public static Coch ObtenerCochePorId(DbContext context, int id)
        {
            return context.Set<Coch>().FirstOrDefault(c => c.Id == id);
        }

        // Método para actualizar un coche en la base de datos
        public void ActualizarCoche()
        {
            var cocheExistente = _context.Set<Coch>().FirstOrDefault(c => c.Id == this.Id);
            if (cocheExistente != null)
            {
                if (cocheExistente.Matricula != this.Matricula)
                    cocheExistente.Matricula = this.Matricula;
                if (cocheExistente.id_modelo != this.id_modelo)
                    cocheExistente.id_modelo = this.id_modelo;
                if (cocheExistente.Color != this.Color)
                    cocheExistente.Color = this.Color;
                if (cocheExistente.Anio != this.Anio)
                    cocheExistente.Anio = this.Anio;
                if (cocheExistente.Precio != this.Precio)
                    cocheExistente.Precio = this.Precio;

                _context.Set<Coch>().Update(cocheExistente);
                _context.SaveChanges();
            }
        }

        // Método para eliminar un coche de la base de datos
        public void EliminarCoche()
        {
            var coche = _context.Set<Coch>().FirstOrDefault(c => c.Id == this.Id);
            if (coche != null)
            {
                _context.Set<Coch>().Remove(coche);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Coche no encontrado.");
            }
        }
    }
}
