using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Controllers
{
    public class EmpleadoController
    {
        private readonly DbContext _context;

        public EmpleadoController(DbContext context)
        {
            _context = context;
        }

        // Método para crear un nuevo empleado
        public void CrearEmpleado(string nombre, string? puesto, decimal? salario, string? telefono)
        {
            try
            {
                var empleado = new Empleado
                {
                    Nombre = nombre,
                    Puesto = puesto,
                    Salario = salario,
                    Telefono = telefono
                };

                empleado.CrearEmpleado();  // Crear empleado usando el método de la clase Empleado
                Console.WriteLine("Empleado creado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear empleado: {ex.Message}");
            }
        }

        // Método para obtener todos los empleados
        public List<Empleado> ObtenerEmpleados()
        {
            try
            {
                return Empleado.ObtenerEmpleados(_context);  // Llamada al método estático para obtener empleados
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                return new List<Empleado>(); // Retorna una lista vacía en caso de error
            }
        }

        // Método para obtener un empleado por ID
        public Empleado ObtenerEmpleadoPorId(int id)
        {
            try
            {
                var empleado = Empleado.ObtenerEmpleadoPorId(_context, id);
                if (empleado == null)
                {
                    Console.WriteLine($"Empleado con ID {id} no encontrado.");
                }
                return empleado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleado: {ex.Message}");
                return null;
            }
        }

        // Método para actualizar un empleado
        public void ActualizarEmpleado(int id, string nombre, string? puesto, decimal? salario, string? telefono)
        {
            try
            {
                var empleado = new Empleado
                {
                    Id = id,
                    Nombre = nombre,
                    Puesto = puesto,
                    Salario = salario,
                    Telefono = telefono
                };

                empleado.ActualizarEmpleado();  // Actualizar empleado usando el método de la clase Empleado
                Console.WriteLine("Empleado actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
            }
        }

        // Método para eliminar un empleado por ID
        public void EliminarEmpleado(int id)
        {
            try
            {
                var empleado = new Empleado { Id = id };  // No es necesario pasar el contexto
                empleado.EliminarEmpleado();  // Eliminar empleado usando el método de la clase Empleado
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado: {ex.Message}");
            }
        }
    }
}
