using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class ComprasRepuesto
{
    public int Id { get; set; }

    public int IdProveedor { get; set; }

    public int IdRepuesto { get; set; }

    public int Cantidad { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? PrecioTotal { get; set; }

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;

    public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
}
