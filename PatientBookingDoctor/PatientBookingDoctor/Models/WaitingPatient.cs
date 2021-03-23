using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBookingDoctor.Models
{
    public class WaitingPatient
    {
        public Guid ID { get; set; }
        public string RegistrationDate { get; set; }

        public string PatientName { get; set; }

        public string ExaminationDept { get; set; }
        public string ClinicName { get; set; }
        
    }
}
