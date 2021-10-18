using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Data;
using API.LabTests.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.LabTests.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly LabContext _context;
        public PatientRepository(LabContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> Create(Patient patient)
        {
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> Get()
        {
            var patients = await _context.Patients.ToListAsync();

            if (!patients.Any())
            {
                //Create sample data for testing
                PatientData._context = _context;
                PatientData.CreateSamplePatients();

                patients = await _context.Patients.ToListAsync(); //list for sample data
            }

            return patients;
        }
        

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Patient> Get(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient;
        }

        
        /// <summary>
        /// Update patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<bool> Update(Patient patient)
        {
            var orgPatient = await _context.Patients.FindAsync(patient.Id);
            if (orgPatient == null) 
                return false;

            patientMapping(orgPatient, patient); 
            
            _context.Entry(orgPatient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Patient mapping with patient
        /// </summary>
        /// <param name="orgPatient"></param>
        /// <param name="updatedPatient"></param>
        private void patientMapping(Patient orgPatient, Patient updatedPatient)
        {
            orgPatient.Name = updatedPatient.Name;
            orgPatient.DateOfBirth = updatedPatient.DateOfBirth;
            orgPatient.Gender = updatedPatient.Gender;
            orgPatient.Address = updatedPatient.Address;
            orgPatient.ContactNumber = updatedPatient.ContactNumber;
            orgPatient.EmailId = updatedPatient.EmailId;
        }
        /// <summary>
        /// Delete patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var patientToDelete = await _context.Patients.FindAsync(id);
            if (patientToDelete != null)
            {
                _context.Patients.Remove(patientToDelete);
            }
          //  _context.Entry(patientToDelete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
