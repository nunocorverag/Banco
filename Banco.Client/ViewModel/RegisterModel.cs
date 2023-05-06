using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Client.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es requerido.")]
        [Display(Name = "Apellido Paterno")]
        public string? Ape_P { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno es requerido.")]
        [Display(Name = "Apellido Materno")]
        public string? Ape_M { get; set; }

        [Required(ErrorMessage = "El campo CURP es requerido.")]
        [Display(Name = "CURP")]
        public string? Curp { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}