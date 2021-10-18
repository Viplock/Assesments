using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PatientDigitalApi.Models;
using PatientDigitalApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILabReportRepository _labReportRepository;

        public PatientController(IPatientRepository patientRepository, ILabReportRepository labReportRepository)
        {
            this._patientRepository = patientRepository;
            this._labReportRepository = labReportRepository;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _patientRepository.GetPatients();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return _patientRepository.GetPatients(id).FirstOrDefault();
        }

        // POST api/<PatientController>
        [HttpPost]
        public IEnumerable<Patient> Post([FromBody] Patient patient)
        {
            var allPatients = _patientRepository.GetPatients();
            patient.PatientId = allPatients.Max(d => d.PatientId) + 1;
            allPatients.Add(patient);
            _patientRepository.SetPatientCache(allPatients);
            return allPatients;
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public Patient Put(int id, [FromBody] Patient patient)
        {
            //working with static data 
            //otherwise would have set the data by EF and updated it
            var allPatients = _patientRepository.GetPatients();
            var filteredPatient = allPatients.FirstOrDefault(d => d.PatientId == id);
            if (filteredPatient != null)
            {
                filteredPatient.PName = patient.PName;
                filteredPatient.PGender = patient.PGender;
                filteredPatient.DOB = patient.DOB;
                filteredPatient.ContactNumber = patient.ContactNumber;
            }

            _patientRepository.SetPatientCache(allPatients);
            return filteredPatient;
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var allPatients = _patientRepository.GetPatients();
            allPatients.Remove(allPatients.FirstOrDefault(d => d.PatientId == id));
            _patientRepository.SetPatientCache(allPatients);
            return "deleted";
        }

        [Route("filter")]
        [HttpPost]
        public IList<Patient> GetFileterdPatientList([FromBody] Criteria criteria)
        {
            var allpatients= _patientRepository.GetPatients();
            var allReports = _labReportRepository.GetReports();

            var filteredData = (from pat in allpatients
                               join rep in allReports on pat.PatientId equals rep.PatientId
                               where rep.ReportType.ToLower() ==  criteria.ReportType.ToLower()
                               && (rep.TimeOfTest >= criteria.Fromdate && rep.TimeOfTest <= criteria.ToDate)
                               select pat)?.ToList();
            return filteredData;
        }
    }
}
