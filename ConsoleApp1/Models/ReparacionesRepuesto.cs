using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class ReparacionesRepuesto
{
    public int IdReparacion { get; set; }

    public int IdRepuesto { get; set; }

    public int Cantidad { get; set; }

    public virtual Reparacione IdReparacionNavigation { get; set; } = null!;

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
}
