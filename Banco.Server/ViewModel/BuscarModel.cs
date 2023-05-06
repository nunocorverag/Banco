using Banco.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Server.ViewModel
{
    public class BuscarModel
    {
        [Required]
        public string CURP { get; set; }
        public string Estatus {  get; set; }
    }
}