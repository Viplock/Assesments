using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PatientDigitalApi.Models;
using PatientDigitalApi.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabReportController : ControllerBase
    {
        private readonly ILabReportRepository _labReportRepository;

        public LabReportController(ILabReportRepository labReportRepository)
        {
            this._labReportRepository = labReportRepository;
        } 


        // GET: api/<LabTestController>
        [HttpGet]
        [Authorize]
        public IEnumerable<LabTest> Get()
        {
            return _labReportRepository.GetReports();
        }

        // GET api/<LabTestController>/5
        [HttpGet("{id}")]
        public LabTest Get(int id)
        {
            return _labReportRepository.GetReports(id).FirstOrDefault();
        }

        // POST api/<LabTestController>
        [HttpPost]
        public IList<LabTest> Post([FromBody] LabTest labTest)
        {
            var allReports =_labReportRepository.GetReports();
            labTest.LabReportId = allReports.Max(d => d.LabReportId)+1;
            allReports.Add(labTest);
            _labReportRepository.SetLabReportCache(allReports);
            return allReports;
        }

        // PUT api/<LabTestController>/5
        [HttpPut("{id}")]
        public LabTest Put(int id, [FromBody] LabTest labTest)
        {
            //working with static data 
            //otherwise would have set the data by EF and updated it
            var allReports =_labReportRepository.GetReports();
            var report = allReports.FirstOrDefault(d => d.LabReportId == id);
            if (report != null)
            {
                report.Result = labTest.Result;
                report.TimeOfTest = labTest.TimeOfTest;
                report.PatientId = labTest.PatientId;
                report.EnteredTime = labTest.EnteredTime;
                report.ReportType = labTest.ReportType;
                report.ReportCenterName = labTest.ReportCenterName;
            }

            _labReportRepository.SetLabReportCache(allReports);
            return report;
        }

        // DELETE api/<LabTestController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var allReports =_labReportRepository.GetReports();
            allReports.Remove(allReports.FirstOrDefault(d => d.LabReportId == id));
            _labReportRepository.SetLabReportCache(allReports);
            return "deleted";
        }
    }
}
