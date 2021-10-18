using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Repositories
{
    public interface IPatientRepository
    {

        Task<Patient> Create(Patient patient);
        Task<IEnumerable<Patient>> Get();

        Task<Patient> Get(int id);

        Task<bool> Update(Patient patient);

        Task Delete(int id);

    }
}
