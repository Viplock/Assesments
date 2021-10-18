using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Data;
using API.LabTests.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.LabTests.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly LabContext _context;
        public ReportRepository(LabContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public async Task<Report> Create(Report report)
        {
            if (!await ValidateLabTest(report)) 
                return null;

            var labTest = await _context.LabTests.FindAsync(report.LabTestId); 
            
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return report;
        }
        /// <summary>
        /// Get all reports
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Report>> Get()
        {
            var reports = await _context.Reports.ToListAsync();

            if (!reports.Any())
            {
                ReportsData._context = _context;
                await ReportsData.CreateSampleReports();

                reports = await _context.Reports.ToListAsync(); 
            }

            return reports; 
        }

        /// <summary>
        /// Get report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Report> Get(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            return report;
        }

        /// <summary>
        /// Get report for a given date range
        /// </summary>
        /// <param name="labTestId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<IEnumerable<object>> Get(int labTestId, DateTime from, DateTime to)
        {
            var GetReports = await _context.Reports.Include(l => l.LabTest).Include(p => p.Patient)
                .Where(x => x.LabTestId == labTestId && (x.ReportCreatedOn >= from && x.ReportCreatedOn <= to)).ToListAsync();

            var reports = FormatReport(GetReports); 
            return reports.ToList();
        }

        /// <summary>
        /// Update report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public async Task<bool> Update(Report report)
        {
            var orgReport = await _context.Reports.FindAsync(report.Id);
            if (orgReport == null) //check for active
                return false;

            if (!await ValidateLabTest(report)) //check for patient and test details
                return false;

            ReportMapping(orgReport, report); //map current instance with context instance

            var labTest = await _context.LabTests.FindAsync(report.LabTestId);
            if(labTest != null)
            {
                _context.LabTests.Remove(labTest);
            }
           
            _context.Entry(orgReport).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Map report with report in current context
        /// </summary>
        /// <param name="orgReport"></param>
        /// <param name="updatedReport"></param>
        private void ReportMapping(Report orgReport, Report updatedReport)
        {
            orgReport.LabTestId = updatedReport.LabTestId;
            orgReport.PatientId = updatedReport.PatientId;
            orgReport.ReportCreatedOn = updatedReport.ReportCreatedOn;
            orgReport.EnteredTime = updatedReport.EnteredTime;
            orgReport.TimeOfTest = updatedReport.TimeOfTest;
            orgReport.Result = updatedReport.Result;
        }

        /// <summary>
        /// Check active patient and test
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private async Task<bool> ValidateLabTest(Report report)
        {
            var patient = await _context.Patients.FindAsync(report.PatientId); //patient exists
            var labTest = await _context.LabTests.FindAsync(report.LabTestId); //test exists

           if (patient == null)
                return false; 

            return true;
        }

        /// <summary>
        /// Get formatted report
        /// </summary>
        /// <param name="GetReports"></param>
        /// <returns></returns>
        private static IEnumerable<object> FormatReport(IEnumerable<Report> GetReports)
        {
            return GetReports.Select(n => new
            {
                id = n.Id,
                labTestId = n.LabTest.Description,
                TestType = n.LabTest.TestType.ToString(),
                sampleType = n.LabTest.SampleType.ToString(),
                patientId = n.Patient.Name,
                Gender = n.Patient.Gender.ToString(),
                sampleReceivedOn = n.EnteredTime,
                sampleTestedOn = n.TimeOfTest,
                reportCreatedOn = n.ReportCreatedOn,
                testResult = n.Result,
            });
        }

        /// <summary>
        /// Delete report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var reportToDelete = await _context.Reports.FindAsync(id);
            if (reportToDelete != null)
            {
                _context.Reports.Remove(reportToDelete);
            }
            _context.Entry(reportToDelete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
