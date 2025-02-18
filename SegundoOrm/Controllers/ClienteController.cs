using ConsoleApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly CochesContext _context;

        public ClienteController(CochesContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = Cliente.ObtenerClientes(_context);
            return Ok(clientes);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = Cliente.ObtenerClientePorId(_context, id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // POST: api/Cliente
        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest("Cliente no proporcionado.");

            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Dni))
                return BadRequest("Nombre y DNI son campos obligatorios.");

            
            // Guardar cliente en la base de datos
            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/Cliente/5
        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] Cliente cliente)
        {
            // 1. Comprobamos si el ID del cliente proporcionado en la URL coincide con el ID del cliente en el cuerpo de la solicitud.
            if (id != cliente.Id) return BadRequest("El ID del cliente no coincide.");

            // 2. Buscamos el cliente en la base de datos por su ID.
            var clienteExistente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == id);

            // 3. Si no encontramos el cliente con ese ID, devolvemos un error "NotFound" (404).
            if (clienteExistente == null) return NotFound();

            // 4. Si encontramos el cliente, actualizamos sus propiedades con los valores del cliente que llega en el cuerpo de la solicitud.
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Dni = cliente.Dni;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.Email = cliente.Email;

            // 5. Marcamos el cliente actualizado para que se guarde en la base de datos.
            _context.Set<Cliente>().Update(clienteExistente);

            // 6. Guardamos los cambios en la base de datos.
            _context.SaveChanges();

            // 7. Respondemos con un código de estado 204 No Content para indicar que la operación fue exitosa, pero no hay contenido adicional.
            return NoContent();
        }


        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Set<Cliente>().FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();

            _context.Set<Cliente>().Remove(cliente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
