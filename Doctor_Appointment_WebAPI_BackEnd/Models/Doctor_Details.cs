using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_Appointment_WebAPI_BackEnd.Models
{
    public class Doctor_Details
    {
        public int Id { get; set; }
        public string Doctor_Name { get; set; }
        public string Doctor_Mobile { get; set; }
        public string Doctor_Email { get; set; }
        public string Doctor_Specialization { get; set; }

    }
}
