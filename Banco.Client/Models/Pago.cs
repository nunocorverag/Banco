using System;
using System.Collections.Generic;

namespace Banco.Client.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal CantidadPago { get; set; }

    public int IdPrestamoPagado { get; set; }

    public long NumeroCuentaPago { get; set; }

    public virtual Prestamo IdPrestamoPagadoNavigation { get; set; } = null!;

    public virtual Cuentum NumeroCuentaPagoNavigation { get; set; } = null!;
}
