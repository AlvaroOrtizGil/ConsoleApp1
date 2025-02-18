using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Seguro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cobertura { get; set; } = null!;

    public virtual ICollection<CochesSeguro> CochesSeguros { get; set; } = new List<CochesSeguro>();
}
