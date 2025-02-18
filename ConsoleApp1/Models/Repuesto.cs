using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Repuesto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<ComprasRepuesto> ComprasRepuestos { get; set; } = new List<ComprasRepuesto>();

    public virtual ICollection<ReparacionesRepuesto> ReparacionesRepuestos { get; set; } = new List<ReparacionesRepuesto>();
}
