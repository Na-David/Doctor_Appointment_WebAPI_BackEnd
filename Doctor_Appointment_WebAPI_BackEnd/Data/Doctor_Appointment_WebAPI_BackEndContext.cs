using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Doctor_Appointment_WebAPI_BackEnd.Models;

namespace Doctor_Appointment_WebAPI_BackEnd.Data
{
    public class Doctor_Appointment_WebAPI_BackEndContext : DbContext
    {
        public Doctor_Appointment_WebAPI_BackEndContext (DbContextOptions<Doctor_Appointment_WebAPI_BackEndContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor_Appointment_WebAPI_BackEnd.Models.Doctor_Details> Doctor_Details { get; set; }

        public DbSet<Doctor_Appointment_WebAPI_BackEnd.Models.Patient_Details> Patient_Details { get; set; }
    }
}
