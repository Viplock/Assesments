using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Data
{
    internal class ReportsData
    {
        internal static LabContext _context { get; set; }

        internal static async Task CreateSampleReports()
        {
            bool isValid = false;

            var Report1 = new Entity.Report
            {
                Id = 10,
                LabTestId = 1,
                PatientId = 1,
                EnteredTime = Convert.ToDateTime("2020-01-01"),
                TimeOfTest = Convert.ToDateTime("2020-01-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-01-12"),
                Result = 101
            };

            if (await ValidateLabTest(Report1))
            {
                _context.Reports.Add(Report1);
                isValid = true;
            }

            var Report2 = new Entity.Report
            {
                Id = 1,
                LabTestId = 1,
                PatientId = 2,
                EnteredTime = Convert.ToDateTime("2020-02-01"),
                TimeOfTest = Convert.ToDateTime("2020-02-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-02-12"),
                Result = 102               
            };

            if (await ValidateLabTest(Report2))
            {
                _context.Reports.Add(Report2);
                isValid = true;
            }

            var Report3 = new Entity.Report
            {
                Id = 2,
                LabTestId = 1,
                PatientId = 3,
                EnteredTime = Convert.ToDateTime("2020-03-01"),
                TimeOfTest = Convert.ToDateTime("2020-03-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-03-12"),
                Result = 103
            };

            if (await ValidateLabTest(Report3))
            {
                _context.Reports.Add(Report3);
                isValid = true;
            }

            var Report4 = new Entity.Report
            {
                Id = 3,
                LabTestId = 1,
                PatientId = 4,
                EnteredTime = Convert.ToDateTime("2020-04-01"),
                TimeOfTest = Convert.ToDateTime("2020-04-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-04-12"),
                Result = 104
            };

            if (await ValidateLabTest(Report4))
            {
                _context.Reports.Add(Report4);
                isValid = true;
            }

            var Report5 = new Entity.Report
            {
                Id = 4,
                LabTestId = 1,
                PatientId = 5,
                EnteredTime = Convert.ToDateTime("2020-05-01"),
                TimeOfTest = Convert.ToDateTime("2020-05-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-05-12"),
                Result = 105             
            };

            if (await ValidateLabTest(Report5))
            {
                _context.Reports.Add(Report5);
                isValid = true;
            }

            var Report6 = new Entity.Report
            {
                Id = 5,
                LabTestId = 2,
                PatientId = 3,
                EnteredTime = Convert.ToDateTime("2020-06-01"),
                TimeOfTest = Convert.ToDateTime("2020-06-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-06-12"),
                Result = 106
            };

            if (await ValidateLabTest(Report6))
            {
                _context.Reports.Add(Report6);
                isValid = true;
            }

            var Report7 = new Entity.Report
            {
                Id = 6,
                LabTestId = 2,
                PatientId = 4,
                EnteredTime = Convert.ToDateTime("2020-07-01"),
                TimeOfTest = Convert.ToDateTime("2020-07-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-07-12"),
                Result = 107               
            };

            if (await ValidateLabTest(Report7))
            {
                _context.Reports.Add(Report7);
                isValid = true;
            }

            var Report8 = new Entity.Report
            {
                Id = 7,
                LabTestId = 4,
                PatientId = 5,
                EnteredTime = Convert.ToDateTime("2020-08-01"),
                TimeOfTest = Convert.ToDateTime("2020-08-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-08-12"),
                Result = 108
            };
            if (await ValidateLabTest(Report8))
            {
                _context.Reports.Add(Report8);
                isValid = true;
            }
            var Report9 = new Entity.Report
            {
                Id = 8,
                LabTestId = 3,
                PatientId = 5,
                EnteredTime = Convert.ToDateTime("2020-08-01"),
                TimeOfTest = Convert.ToDateTime("2020-08-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-08-12"),
                Result = 109
            };
            if (await ValidateLabTest(Report9))
            {
                _context.Reports.Add(Report9);
                isValid = true;
            }
            var Report10 = new Entity.Report
            {
                Id = 9,
                LabTestId = 3,
                PatientId = 4,
                EnteredTime = Convert.ToDateTime("2020-08-01"),
                TimeOfTest = Convert.ToDateTime("2020-08-10"),
                ReportCreatedOn = Convert.ToDateTime("2020-08-12"),
                Result = 110
            };
            if (await ValidateLabTest(Report10))
            {
                _context.Reports.Add(Report10);
                isValid = true;
            }

            if (isValid)
                await _context.SaveChangesAsync();
        }

        private static async Task<bool> ValidateLabTest(Report report)
        {
            var patient = await _context.Patients.FindAsync(report.PatientId);
            var labTest = await _context.LabTests.FindAsync(report.LabTestId);

            if (patient == null || labTest == null)
                return false;

            return true;
        }
    }
}
