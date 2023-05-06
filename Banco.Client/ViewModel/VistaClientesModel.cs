using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Client.ViewModel
{
    public class VistaClientesModel
    {
        public class Tablas
        {
            public List<Solicitud> ListSolicitud { get; set; }

            public List<Prestamo> ListPrestamo { get; set; }

            public List<Pago> ListPago { get; set; }

            public Cuentum cuenta { get; set; }

            public Usuario usuario { get; set; }

        }
    }
}