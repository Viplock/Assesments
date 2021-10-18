using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Repositories
{
    public interface ILabTestRepository
    {
        Task<LabTest> Create(LabTest labTest);
        Task<IEnumerable<LabTest>> Get();

        Task<LabTest> Get(int id);

        Task<bool> Update(LabTest labTest);

        Task Delete(int id);
    }
}
