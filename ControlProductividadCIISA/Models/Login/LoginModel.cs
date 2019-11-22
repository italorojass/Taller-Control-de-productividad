using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlProductividadCIISA.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ingrese un correo"), MaxLength(30)]
        [EmailAddress(ErrorMessage = "Email no es válido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese su clave, máximo 10 digitos"), MaxLength(10)]
        public string Password { get; set; }
    }
}