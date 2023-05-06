using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class Gerente
{
    public int IdGerente { get; set; }

    public int IdEmpleado { get; set; }

    public int DiasVacaciones { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
