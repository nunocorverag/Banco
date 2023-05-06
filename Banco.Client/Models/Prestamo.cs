using System;
using System.Collections.Generic;

namespace Banco.Client.Models;

public partial class Prestamo
{
    public int Folio { get; set; }

    public long NumeroCuenta { get; set; }

    public int IdEmpleado { get; set; }

    public int IdSolicitud { get; set; }

    public DateTime FechaAprobacion { get; set; }

    public string CategoriaPrestamo { get; set; } = null!;

    public decimal PagoMensual { get; set; }

    public DateTime FechaUltimoPago { get; set; }

    public decimal PorcentajePagado { get; set; }

    public int Boletos { get; set; }

    public string Estado { get; set; } = null!;

    public int VecesPagado { get; set; }

    public virtual ICollection<Boleto> BoletosNavigation { get; set; } = new List<Boleto>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;

    public virtual Cuentum NumeroCuentaNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
