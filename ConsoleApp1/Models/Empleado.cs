using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Puesto { get; set; }

    public decimal? Salario { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
