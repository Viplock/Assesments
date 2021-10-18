using System;

namespace PatientDigitalApi.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PName { get; set; }
        public DateTime DOB { get; set; }
        public Gender PGender { get; set; }
        public string ContactNumber { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
