using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Michael_Panches.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();

    public virtual User User { get; set; } = null!;
}
