using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdUsuario { get; set; }

    public int IdPersona { get; set; }

    public int Nomina { get; set; }

    public int PrestamosAprobados { get; set; }

    public virtual ICollection<Gerente> Gerentes { get; set; } = new List<Gerente>();

    public virtual InfoPersona IdPersonaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Nomina NominaNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
