using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Michael_Panches.Models;

public partial class Administrador
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Cargo { get; set; }

    public virtual User User { get; set; } = null!;
}
