using System;
using System.Collections.Generic;

namespace Banco.Server.Models;

public partial class Boleto
{
    public int IdBoleto { get; set; }

    public int FolioPrestamo { get; set; }

    public DateTime PrimeraParticipacion { get; set; }

    public bool Premiado { get; set; }

    public virtual Prestamo FolioPrestamoNavigation { get; set; } = null!;
}
