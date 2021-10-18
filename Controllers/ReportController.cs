using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.LabTests.Entity;
using API.LabTests.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.LabTests.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILabTestRepository _labTestRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IReportRepository _labReportRepository;
       

        public ReportController(IReportRepository labReportRepository, 
            ILabTestRepository labTestRepository, IPatientRepository patientRepository)
        {
            _labReportRepository = labReportRepository;
            _labTestRepository = labTestRepository;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public async Task<IEnumerable<Report>> Get()
        {
            return await _labReportRepository.Get();
        }

        /// <summary>
        /// Get report by id
        /// </summary>
        /// <param name="id">Report id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<Report>> Get(int id)
        {
            var report = await _labReportRepository.Get(id);
            if (report == null )
                return NotFound();

            return report;
        }

        /// <summary>
        /// Get report by report created date
        /// </summary>
        /// <param name="labTestId">LabTest Id</param>
        /// <param name="fromDate">Start Date</param>
        /// <param name="toDate">End Date</param>
        /// <returns></returns>
        [HttpGet("GetByLabTest/{labTestId}/{fromDate}/{toDate}")]
        public async Task<IEnumerable<object>> GetByLabTest(int labTestId, DateTime fromDate, DateTime toDate)
        {
            return await _labReportRepository.Get(labTestId, fromDate, toDate);
        }

        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Report>> Create([FromBody] Report report)
        {
            var newReport = await _labReportRepository.Create(report);

            if (newReport == null)
                return BadRequest();

            return CreatedAtAction(nameof(Create), new { id = newReport.Id }, newReport);
        }

        /// <summary>
        /// Update report
        /// </summary>
        /// <param name="id"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Report report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            if (await _labReportRepository.Update(report))
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Delete report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var report = await _labReportRepository.Get(id);
            if (report == null)
                return NotFound();

            await _labReportRepository.Delete(report.Id);
            return NoContent();
        }

    }
}
