using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Banco.Server.ViewModel;
using Banco.Server.Models;

namespace BancoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly BancoContext dbContext;

        public AccountController(BancoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> RegistrarUsuario(RegisterModel registerDetails)
        {
            // Resto del código de validación de modelo

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<string> errores = new List<string>();


            CurpEstatus? check = dbContext.CurpEstatuses
            .Where(query => query.Curp.Equals(registerDetails.Curp))
            .SingleOrDefault();

            if(check != null)
            {
                errores.Add("ERROR, Un usuario con ese Curp ya existe!");
            }
            else
            {
                #region Checar si contiene un numero
                for (int i = 0; i < registerDetails.Nombre.Length; i++)
                {
                    if (Char.IsDigit(registerDetails.Nombre, i))
                    {
                        errores.Add("ERROR, el Nombre no puede contener numeros!!");
                    }
                }
                for (int i = 0; i < registerDetails.Ape_P.Length; i++)
                {
                    if (Char.IsDigit(registerDetails.Ape_P, i))
                    {
                        errores.Add("ERROR, el Apellido Paterno no puede contener numeros!!");
                    }

                }
                for (int i = 0; i < registerDetails.Ape_M.Length; i++)
                {
                    if (Char.IsDigit(registerDetails.Ape_M, i))
                    {
                        errores.Add("ERROR, el Apellido Materno no puede contener numeros!!");
                    }

                }
                #endregion

                #region Checar si la fehca es antes de 1962
                if (registerDetails.Fecha_Nacimiento.Year < 1962)
                {
                    errores.Add("ERROR, la fecha de nacimiento no puede ser antes de 1962!!");
                }
                #endregion
                #region Checar si el CURP es correcto, si lo es, crear el usuario
                if (registerDetails.Curp.Length < 18)
                {
                    errores.Add("ERROR, el curp no puede ser menor a 18 caracteres!");
                }
                else if (registerDetails.Curp.Length > 18)
                {
                    errores.Add("ERROR, el curp no puede ser mayor a 18 caracteres!");
                }
                else if (registerDetails.Curp.Length == 18)
                {
                    if (!ComprobarCurp(registerDetails.Curp, registerDetails.Nombre, registerDetails.Ape_P, registerDetails.Ape_M, registerDetails.Fecha_Nacimiento))
                    {
                        errores.Add("ERROR, El CURP no coincide con los datos ingresados!");
                    }
                }
                #endregion
            }
            if(errores.Count == 0)
            {
                //RQNF 3

                // Si llegamos aquí, la validación ha sido exitosa
                // Insertar el nuevo usuario en la base de datos
                InfoPersona infoReg  = new InfoPersona();
                CurpEstatus curpReg = new CurpEstatus();

                infoReg.Nombre = registerDetails.Nombre;
                infoReg.ApeP = registerDetails.Ape_P;
                infoReg.ApeM = registerDetails.Ape_M;
                infoReg.FechaNacimiento = registerDetails.Fecha_Nacimiento;
                
                dbContext.InfoPersonas.Add(infoReg);
                await dbContext.SaveChangesAsync();


                curpReg.Curp = registerDetails.Curp;
                curpReg.Estatus = "pendiente";
                curpReg.IdPersona = infoReg.IdPersona;
                
                dbContext.CurpEstatuses.Add(curpReg);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                // Si la respuesta no es exitosa, redirige al usuario a la página de inicio de sesión
                var response = new { Errores = errores };
                return StatusCode(401, response);
            }
        }

        public static bool ComprobarCurp(string _CURP, string _Nombre, string _Ape_P, string _Ape_M, DateTime _Fecha_Nacimiento)
        {
            //Inicial del apellido paterno
            string IAP = _Ape_P.Substring(0, 1).Replace("Ñ", "X").Replace(@"[^\u0000-\uu7F] + á,é,í,ó,ú", "X").ToUpper();
            //Vocal inicial del apellido paterno
            string VIAP = fisrtVowel(_Ape_P);
            //Inicial del apellido materno
            string IAM = _Ape_M.Substring(0, 1).Replace("Ñ", "X").Replace(@"[^\u0000-\uu7F] + á,é,í,ó,ú", "X").ToUpper();
            //Inicial del nombre
            string IN = _Nombre.Substring(0, 1).Replace("Ñ", "X").Replace(@"[^\u0000-\uu7F] + á,é,í,ó,ú", "X").ToUpper();
            string FN = _Fecha_Nacimiento.ToString("yy-MM-dd").Replace("-", "");
            // Msg = IAP + VIAP + IAM + IN + FN + "/" + _CURP;
            //Curp tomado de los datos Nombre, Appellido Paterno, Apellido Materno y Fecha de Nacimiento
            //CurpC -> Curp Caculado
            string CurpC = IAP + VIAP + IAM + IN + FN;
            //Curp tomado del campo CURP cortado para compararse con CurpC
            //CurpComp Curp Comparar
            string CurpComp = _CURP.Substring(0, 10).ToUpper();

            //Parte de fecha de nacimiento CURP
            string FNCURP = _CURP.Substring(4, 6);
            if (CurpC == CurpComp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isVowel(char c)
        {
            c = Char.ToUpper(c);
            if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                return true;
            }
            return false;
        }
        public static string fisrtVowel(string s)
        {
            //Quitar acentos
            s = s.Replace(@"[^\u0000-\uu7F] + á,é,í,ó,ú", "X").ToUpper();
            //First Vowel
            string FV;
            for (int i = 0; i < s.Length; i++)
            {
                if (isVowel(s[i]))
                {
                    FV = Char.ToString(s[i]);
                    return FV;
                }
            }
            return "-1";
        }
    }
}