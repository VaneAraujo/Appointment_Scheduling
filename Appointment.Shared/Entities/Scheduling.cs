using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Appointment.Shared.Entities
{
    public class Scheduling
    {
        [Display(Name = "Orden")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int order_id { get; set; }

        public int patient_id { get; set; }

        public int doctor_id { get; set; }



        [Display(Name = "Fecha")]
        public DateTime appointment_date { get; set; }



        [Display(Name = "Hora de inicio")]
        public string appointment_start_time { get; set; }



        [Display(Name = "Hora finalización")]
        public string appointment_end_time { get; set; }

    }
}
