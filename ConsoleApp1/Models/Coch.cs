using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Coch
{
    public int Id { get; set; }

    public string Matricula { get; set; } = null!;

    public int IdModelo { get; set; }

    public string? Color { get; set; }

    public int? Anio { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Alquilere> Alquileres { get; set; } = new List<Alquilere>();

    public virtual ICollection<CochesSeguro> CochesSeguros { get; set; } = new List<CochesSeguro>();

    public virtual ICollection<Garantia> Garantia { get; set; } = new List<Garantia>();

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
