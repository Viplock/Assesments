using System;

namespace PatientDigitalApi.Models
{
    public class LabTest
    {
        public int LabReportId { get; set; }
        public string ReportType { get; set; }
        public string Result { get; set; }
        public DateTime TimeOfTest { get; set; }
        public DateTime EnteredTime { get; set; }
        public int PatientId { get; set; }
        public string ReportCenterName { get; set; }
    }
}
