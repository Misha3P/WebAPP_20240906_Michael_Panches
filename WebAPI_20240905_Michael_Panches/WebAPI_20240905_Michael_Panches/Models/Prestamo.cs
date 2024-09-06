using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Michael_Panches.Models;

public partial class Prestamo
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public decimal Monto { get; set; }

    public decimal TasaInteres { get; set; }

    public int Plazo { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
