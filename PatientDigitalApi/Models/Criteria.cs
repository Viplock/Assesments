using System;

namespace PatientDigitalApi.Controllers
{
    public class Criteria
    {
        public string ReportType { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime ToDate { get; set; }
    }
}