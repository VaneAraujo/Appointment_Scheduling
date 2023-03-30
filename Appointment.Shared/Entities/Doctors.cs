using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Appointment.Shared.Entities
{
    public class Doctors
    {
        public int Id { get; set; }

        [Display(Name = "Paciente")]  //{0}
        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string Name { get; set; } = null;

        public int DocumentNumber { get; set; } 

        public string Especialidad { get; set; } = null;
        public int Tarjeta_prof { get; set; } 

        public DateTime Inicio_horario { get; set; }
        public DateTime Fin_horario { get; set; }
    }
}
