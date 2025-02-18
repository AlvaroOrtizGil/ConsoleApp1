using ConsoleApp1.Controllers;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS para permitir solicitudes desde cualquier origen (útil para desarrollo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()  // Permitir solicitudes de cualquier origen
               .AllowAnyMethod()  // Permitir cualquier método HTTP (GET, POST, etc.)
               .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});

// Configuración de la cadena de conexión para MySQL en XAMPP
builder.Services.AddDbContext<CochesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // Usar la cadena de conexión de appsettings.json
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Añadir controladores
builder.Services.AddControllers();

// Configuración para la API Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar Swagger solo si estamos en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS usando la política configurada
app.UseCors("AllowAll");

app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
