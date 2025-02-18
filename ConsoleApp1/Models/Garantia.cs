using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Garantia
{
    public int Id { get; set; }

    public int IdCoche { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string Detalles { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Coch IdCocheNavigation { get; set; } = null!;
}
