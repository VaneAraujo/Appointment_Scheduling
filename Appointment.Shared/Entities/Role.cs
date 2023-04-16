using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Appointment.Shared.Entities
{
    public class Role
    {
        [Display(Name = "Rol Id")]
        [Key]
        public int role_id { get; set; }

        [Display(Name = "Tipo de usuario")]
        [MaxLength(50, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string role_name { get; set; } = null;

    }
}
