using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PatientDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PatientDigitalApi.Repository
{
    public class LabReportRepository : ILabReportRepository
    {
        private readonly IMemoryCache _memoryCache;
        MemoryCacheEntryOptions memcachOptions = new MemoryCacheEntryOptions()
        {
            Priority = CacheItemPriority.High,
            AbsoluteExpiration = DateTime.Now.AddMinutes(10)
        };
        public LabReportRepository(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public IList<LabTest> GetReports(int id = 0)
        {
            if (!_memoryCache.TryGetValue("reports", out List<LabTest> allReports))
            {
                var filepath = Path.Combine(Environment.CurrentDirectory + @"\Models\LabTests.json");
                //var filepath = @"C:\DRIVE D\Atos docs\PD-Assesment\PatientDigitalApi\PatientDigitalApi\Models\LabTests.json";
                if (System.IO.File.Exists(filepath))
                {
                    var JsonText = System.IO.File.ReadAllText(filepath);
                    var Labtests = JsonConvert.DeserializeObject<IList<LabTest>>(JsonText);
                    allReports = Labtests.ToList();
                    SetLabReportCache(allReports);
                }
                else
                {
                    return new List<LabTest>();
                }
            }
            if (id == 0)
            {
                return allReports;
            }
            else
            {
                return allReports.Where(d => d.LabReportId == id)?.ToList();
            }
        }

        public void SetLabReportCache(IList<LabTest> allLabtests)
        {
            _memoryCache.Set("reports", allLabtests, memcachOptions);
        }
    }

}
