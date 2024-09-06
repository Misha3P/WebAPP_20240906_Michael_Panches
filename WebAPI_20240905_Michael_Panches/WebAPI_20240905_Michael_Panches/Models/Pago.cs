using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Michael_Panches.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int PrestamoId { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaPago { get; set; }

    public virtual Prestamo Prestamo { get; set; } = null!;
}
