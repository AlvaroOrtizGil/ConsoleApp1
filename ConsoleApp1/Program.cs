using ConsoleApp1.Controllers;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
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
                clienteController.CrearCliente("Juan Pérez", "11345278A", "123456789", "juan.peSDrez@email.com");

                // Mostrar todos los clientes
                clienteController.MostrarClientes();

                // Mostrar un cliente por su ID
                clienteController.MostrarClientePorId(1);

                // Actualizar un cliente
                clienteController.ActualizarCliente(1, "JuaDSn Pérez Actualizado", "87654321B", "987654321", "juan.perez.actualizado@email.com");

                // Eliminar un cliente
                clienteController.EliminarCliente(1);
            }

            Console.ReadLine(); // Mantener la consola abierta para ver los resultados
        }
    }
}