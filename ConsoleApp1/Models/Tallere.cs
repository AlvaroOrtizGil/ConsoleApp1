using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Tallere
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
