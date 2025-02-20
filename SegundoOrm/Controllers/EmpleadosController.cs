using ConsoleApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly CochesContext _context;

        public EmpleadoController(CochesContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> GetEmpleados()
        {
            var empleados = _context.Set<Empleado>().ToList();
            return Ok(empleados);
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public ActionResult<Empleado> GetEmpleado(int id)
        {
            var empleado = _context.Set<Empleado>().FirstOrDefault(e => e.Id == id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        // POST: api/Empleado
        [HttpPost]
        public IActionResult PostEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null) return BadRequest("Empleado no proporcionado.");

            if (string.IsNullOrEmpty(empleado.Nombre))
                return BadRequest("Nombre es un campo obligatorio.");

            // Guardar empleado en la base de datos
            _context.Set<Empleado>().Add(empleado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, [FromBody] Empleado empleado)
        {
            // 1. Comprobamos si el ID del empleado proporcionado en la URL coincide con el ID del empleado en el cuerpo de la solicitud.
            if (id != empleado.Id) return BadRequest("El ID del empleado no coincide.");

            // 2. Buscamos el empleado en la base de datos por su ID.
            var empleadoExistente = _context.Set<Empleado>().FirstOrDefault(e => e.Id == id);

            // 3. Si no encontramos el empleado con ese ID, devolvemos un error "NotFound" (404).
            if (empleadoExistente == null) return NotFound();

            // 4. Si encontramos el empleado, actualizamos sus propiedades con los valores del empleado que llega en el cuerpo de la solicitud.
            empleadoExistente.Nombre = empleado.Nombre;
            empleadoExistente.Puesto = empleado.Puesto;
            empleadoExistente.Salario = empleado.Salario;
            empleadoExistente.Telefono = empleado.Telefono;

            // 5. Marcamos el empleado actualizado para que se guarde en la base de datos.
            _context.Set<Empleado>().Update(empleadoExistente);

            // 6. Guardamos los cambios en la base de datos.
            _context.SaveChanges();

            // 7. Respondemos con un código de estado 204 No Content para indicar que la operación fue exitosa, pero no hay contenido adicional.
            return NoContent();
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            var empleado = _context.Set<Empleado>().FirstOrDefault(e => e.Id == id);
            if (empleado == null) return NotFound();

            _context.Set<Empleado>().Remove(empleado);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
