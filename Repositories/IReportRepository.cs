using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Repositories
{
    public interface IReportRepository
    {
        Task<Report> Create(Report report);
        Task<IEnumerable<Report>> Get();
        Task<Report> Get(int id);
        Task<IEnumerable<object>> Get(int labTestId, DateTime from, DateTime to);
        Task<bool> Update(Report report);
        Task Delete(int id);
    }
}
