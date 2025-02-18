using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
