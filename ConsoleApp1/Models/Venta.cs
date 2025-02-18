using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int IdCoche { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal PrecioFinal { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Coch IdCocheNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
