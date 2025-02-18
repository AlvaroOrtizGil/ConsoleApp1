using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class CochesSeguro
{
    public int IdCoche { get; set; }

    public int IdSeguro { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual Coch IdCocheNavigation { get; set; } = null!;

    public virtual Seguro IdSeguroNavigation { get; set; } = null!;
}
