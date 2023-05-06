using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Client.ViewModel
{
    public class SolicitudModel
    {
        public class Tablas
        {
            public Solicitud solicitud { get; set; }

            public Cuentum cuenta { get; set; }

            public Usuario usuario { get; set; }

        }
    }
}