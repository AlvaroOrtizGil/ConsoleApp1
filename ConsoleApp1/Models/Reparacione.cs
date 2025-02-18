using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Reparacione
{
    public int Id { get; set; }

    public int IdCoche { get; set; }

    public int IdTaller { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? Costo { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Coch IdCocheNavigation { get; set; } = null!;

    public virtual Tallere IdTallerNavigation { get; set; } = null!;

    public virtual ICollection<ReparacionesRepuesto> ReparacionesRepuestos { get; set; } = new List<ReparacionesRepuesto>();
}
