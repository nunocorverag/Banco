﻿using System;
using System.Collections.Generic;

namespace Banco.Client.Models;

public partial class Nomina
{
    public int Nomina1 { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
