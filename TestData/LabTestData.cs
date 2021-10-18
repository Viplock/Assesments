using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;

namespace API.LabTests.Data
{
    internal class LabTestData
    {
        internal static LabContext _context { get; set; }

        internal async static Task CreateSampleTests()
        {
            var LabTest1 = new Entity.LabTest
            {
                Id = 1,
                Description = "Blood Count",
                SampleType = SampleTypes.BloodSample,
                TestType = TestTypes.CompleteBloodCount,
            };
            _context.LabTests.Add(LabTest1);

            var LabTest2 = new Entity.LabTest
            {
                Id = 2,
                Description = "Glucose Tolerance",
                SampleType = SampleTypes.BloodSample,
                TestType = TestTypes.GlucoseTests,
            };
            _context.LabTests.Add(LabTest2);

            var LabTest3 = new Entity.LabTest
            {
                Id = 3,
                Description = "Kidney Function",
                SampleType = SampleTypes.UrineSample,
                TestType = TestTypes.UrinAlysis,
            };
            _context.LabTests.Add(LabTest3);

            var LabTest4 = new Entity.LabTest
            {
                Id = 4,
                Description = "Brain Scanning",
                SampleType = SampleTypes.None,
                TestType = TestTypes.PhysicalTest,
            };
            _context.LabTests.Add(LabTest4);

            await _context.SaveChangesAsync();
        }
    }
}
