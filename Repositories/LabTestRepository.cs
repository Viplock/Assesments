using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Data;
using API.LabTests.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.LabTests.Repositories
{
    public class LabTestRepository : ILabTestRepository
    {
        private readonly LabContext _context;
        public LabTestRepository(LabContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create lab test
        /// </summary>
        /// <param name="labTest"></param>
        /// <returns></returns>
        public async Task<LabTest> Create(LabTest labTest)
        {
            _context.LabTests.Add(labTest);

            await _context.SaveChangesAsync();
            return labTest;
        }

        /// <summary>
        /// Get all lab tests
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LabTest>> Get()
        {
            var labTests = await _context.LabTests.ToListAsync();

            if (!labTests.Any())
            {
                //create sample reports for testing
                LabTestData._context = _context;
                await LabTestData.CreateSampleTests();

                labTests = await _context.LabTests.ToListAsync(); //list for sample data
            }

            return labTests;
        }

        /// <summary>
        /// Get lab test by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LabTest> Get(int id)
        {
            var labTest = await _context.LabTests.FindAsync(id);
            return labTest;
        }

        /// <summary>
        /// Update lab test
        /// </summary>
        /// <param name="labTest"></param>
        /// <returns></returns>
        public async Task<bool> Update(LabTest labTest)
        {
            var orgLabTest = await _context.LabTests.FindAsync(labTest.Id);
            if (orgLabTest == null) //check for active
                return false;

            //map current instance with context instance
            labTestMapping(orgLabTest, labTest);
           
            _context.Entry(orgLabTest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Lab test mapping
        /// </summary>
        /// <param name="orgLabTest"></param>
        /// <param name="updatedLabTest"></param>
        private void labTestMapping(LabTest orgLabTest, LabTest updatedLabTest)
        {
            orgLabTest.SampleType = updatedLabTest.SampleType;
            orgLabTest.TestType = updatedLabTest.TestType;
            orgLabTest.Description = updatedLabTest.Description;
        }

        /// <summary>
        /// Delete lab test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var labTestToDelete = await _context.LabTests.FindAsync(id);
            if (labTestToDelete != null)
            {
                _context.LabTests.Remove(labTestToDelete);
            }
           // _context.Entry(labTestToDelete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
