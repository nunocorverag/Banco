using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Client.ViewModel
{
    public class PrestamosModel
    {
        [Required]
        public int Monto { get; set; }

        [Required]
        public int Plazo { get; set; }
    }
}