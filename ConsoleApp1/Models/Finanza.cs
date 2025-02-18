using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Finanza
{
    public int Id { get; set; }

    public string Concepto { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateOnly Fecha { get; set; }
}
