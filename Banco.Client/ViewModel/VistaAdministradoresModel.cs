using Banco.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Banco.Client.ViewModel
{
    public class VistaAdministradoresModel
    {
        public class Tablas
        {
            public List<Usuario> ListUsuario { get; set; }

            public List<Cuentum> ListCuenta { get; set; }

            public List<Empleado> ListEmpleado { get; set; }

            public List<Gerente> ListGerente { get; set; }

            public Administrador administrador { get; set; }

            public Usuario usuario { get; set; }

        }
    }
}