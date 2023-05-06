using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class Cuentum
{
    public long NumeroCuenta { get; set; }

    public int IdUsuario { get; set; }

    public int IdPersona { get; set; }

    public decimal Saldo { get; set; }

    public string Curp { get; set; } = null!;

    public virtual CurpEstatus CurpNavigation { get; set; } = null!;

    public virtual InfoPersona IdPersonaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
