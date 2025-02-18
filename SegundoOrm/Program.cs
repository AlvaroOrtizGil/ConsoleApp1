using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models; // Importa el espacio de nombres donde está tu modelo

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext para la base de datos MySQL (o el proveedor que estés usando)
builder.Services.AddDbContext<DbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Configurar servicios para la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
