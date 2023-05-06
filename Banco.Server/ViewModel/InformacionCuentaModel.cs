using Banco.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Server.ViewModel
{
    public class InformacionCuentaModel
    {
        public Cuentum cuenta { get; set; }
        public Usuario usuario { get; set; }

    }
}