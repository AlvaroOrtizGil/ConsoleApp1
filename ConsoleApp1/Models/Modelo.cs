using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Modelo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdMarca { get; set; }

    public virtual ICollection<Coch> Coches { get; set; } = new List<Coch>();

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
