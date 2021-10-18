using PatientDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDigitalApi.Repository
{
    public interface ILabReportRepository
    {
        IList<LabTest> GetReports(int id = 0);
        void SetLabReportCache(IList<LabTest> allLabtests);
    }
}
