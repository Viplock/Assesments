using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Data
{
    internal class PatientData
    {
        internal static LabContext _context { get; set; }
        internal static async void CreateSamplePatients()
        {
            var patient1 = new Entity.Patient
            {
                Id = 1,
                Name = "Patient1",
                DateOfBirth = Convert.ToDateTime("1977-01-06"),
                Gender = PatientGender.Male,
                ContactNumber = "(+91) 8805000000",
                Address = "Pune",
                EmailId = "patient1@atos.com"
            };
            _context.Patients.Add(patient1);

            var patient2 = new Entity.Patient
            {
                Id = 2,
                Name = "Patient2",
                DateOfBirth = Convert.ToDateTime("1978-02-07"),
                Gender = PatientGender.Female,
                ContactNumber = "(+91) 9805000000",
                EmailId = "patient2@atos.com",
                Address = "Delhi"                
            };
            _context.Patients.Add(patient2);

            var patient3 = new Entity.Patient
            {
                Id = 3,
                Name = "Patient3",
                DateOfBirth = Convert.ToDateTime("1979-03-08"),
                Gender = PatientGender.Male,
                ContactNumber = "(+91) 9806000000",
                EmailId = "patient3@gmail.com",
                Address = "Nasik"
            };
            _context.Patients.Add(patient3);

            var patient4 = new Entity.Patient
            {
                Id = 4,
                Name = "Patient4",
                DateOfBirth = Convert.ToDateTime("1980-04-09"),
                Gender = PatientGender.Female,
                ContactNumber = "(+91) 9807000000",
                EmailId = "patient4@atos.com",
                Address = "Mumbai"
            };
            _context.Patients.Add(patient4);

            var patient5 = new Entity.Patient
            {
                Id = 5,
                Name = "Patient5",
                DateOfBirth = Convert.ToDateTime("1981-05-10"),
                Gender = PatientGender.Female,
                ContactNumber = "(+91) 9809000000",
                EmailId = "patient5@atos.com",
                Address = "Aurangabad"
            };
            _context.Patients.Add(patient5);

            await _context.SaveChangesAsync();
        }
    }
}
