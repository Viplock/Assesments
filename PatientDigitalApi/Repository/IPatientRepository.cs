using PatientDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDigitalApi.Repository
{
    public interface IPatientRepository
    {
        IList<Patient> GetPatients(int id = 0);
        void SetPatientCache(IList<Patient> allPatients);
    }
}
