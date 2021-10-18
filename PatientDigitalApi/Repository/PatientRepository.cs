using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PatientDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PatientDigitalApi.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly IMemoryCache _memoryCache;
        private MemoryCacheEntryOptions memCacheOptions = new MemoryCacheEntryOptions()
        {
            Priority = CacheItemPriority.High,
            AbsoluteExpiration = DateTime.Now.AddMinutes(10)
        };
        public PatientRepository(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public IList<Patient> GetPatients(int id = 0)
        {
            if (!_memoryCache.TryGetValue("reports", out List<Patient> allPatients))
            {
                var filepath = Path.Combine(Environment.CurrentDirectory + @"\Models\Patient.json");
                if (System.IO.File.Exists(filepath))
                {
                    var JsonText = System.IO.File.ReadAllText(filepath);
                    var Patients = JsonConvert.DeserializeObject<IList<Patient>>(JsonText);
                    allPatients = Patients.ToList();
                    SetPatientCache(allPatients);
                }
                else
                {
                    return new List<Patient>();
                }
            }
            if (id == 0)
            {
                return allPatients;
            }
            else
            {
                return allPatients.Where(d => d.PatientId == id)?.ToList();
            }
        }
        public void SetPatientCache(IList<Patient> allPatients)
        {
            _memoryCache.Set("patients", allPatients, memCacheOptions);
        }
    }
}
