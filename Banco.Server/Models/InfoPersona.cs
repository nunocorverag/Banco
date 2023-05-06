using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class InfoPersona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApeP { get; set; } = null!;

    public string ApeM { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual ICollection<CurpEstatus> CurpEstatuses { get; set; } = new List<CurpEstatus>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
