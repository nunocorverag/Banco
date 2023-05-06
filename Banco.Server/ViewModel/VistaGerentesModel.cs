using Banco.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Server.ViewModel
{
    public class VistaGerentesModel
    {
        public class Tablas
        {
            public List<CurpEstatus> ListCurp_Estatus { get; set; }

            public List<Cuentum> ListCuenta { get; set; }

            public List<Empleado> ListEmpleado { get; set; }

            public List<Solicitud> ListSolicitud { get; set; }

            public List<Prestamo> ListPrestamo { get; set; }

            public Gerente gerente {  get; set; }

            public Usuario usuario { get; set; }
        }
    }
}