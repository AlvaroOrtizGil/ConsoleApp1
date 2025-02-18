using ConsoleApp1.Controllers;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de CORS para permitir solicitudes desde cualquier origen (�til para desarrollo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()  // Permitir solicitudes de cualquier origen
               .AllowAnyMethod()  // Permitir cualquier m�todo HTTP (GET, POST, etc.)
               .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});

// Configuraci�n de la cadena de conexi�n para MySQL en XAMPP
builder.Services.AddDbContext<CochesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // Usar la cadena de conexi�n de appsettings.json
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// A�adir controladores
builder.Services.AddControllers();

// Configuraci�n para la API Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar Swagger solo si estamos en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS usando la pol�tica configurada
app.UseCors("AllowAll");

app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();
