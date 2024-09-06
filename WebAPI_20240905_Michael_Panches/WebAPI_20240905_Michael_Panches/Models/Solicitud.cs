using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Michael_Panches.Models;

public partial class Solicitud
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public decimal Monto { get; set; }

    public int Plazo { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
public class SolicitudDTO
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Monto { get; set; }
    public int Plazo { get; set; }
    public string Estado { get; set; } = null!;
    public DateTime FechaSolicitud { get; set; }
}