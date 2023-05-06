using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Client.ViewModel
{
    public class VistaEmpleadosModel
    {
        public class Tablas
        {
            public List<Solicitud> ListSolicitud { get; set; }

            public Empleado empleado { get; set; }

            public Usuario usuario { get; set; }

        }
    }
}