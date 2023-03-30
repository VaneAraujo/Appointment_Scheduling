using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Shared.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        [Display(Name = "Paciente")]  //{0}
        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string Name { get; set; } = null;

        public int DocumentNumber { get; set; }

        public string EPS { get; set; } = null;

        public DateOnly BirthDate { get; set; }
    }
}
