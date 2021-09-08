using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_Appointment_WebAPI_BackEnd.Models
{
    public class Appointment_Details
    {
        public int Id { get; set; }
        public Doctor_Details Doctor_ { get; set; }
        public Patient_Details Patient_ { get; set; }
        public DateTime Appointment { get; set; }
    }
}
