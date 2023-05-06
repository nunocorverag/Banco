using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class CurpEstatus
{
    public string Curp { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public int IdPersona { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual InfoPersona IdPersonaNavigation { get; set; } = null!;
}
