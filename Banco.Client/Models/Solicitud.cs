using System;
using System.Collections.Generic;

namespace Banco.Client.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public long NumeroCuenta { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public string Situacion { get; set; } = null!;

    public int Plazo { get; set; }

    public virtual Cuentum NumeroCuentaNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
