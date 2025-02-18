using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<ComprasRepuesto> ComprasRepuestos { get; set; } = new List<ComprasRepuesto>();
}
