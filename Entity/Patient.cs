using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.LabTests.Entity
{
    public enum PatientGender
    {
        None,
        Male,
        Female, 
        Other
    }

    public class Patient
    {
        /// <summary>
        /// Patient id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Patient Name
        /// </summary>       
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Date of birth of patient
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gender 
        /// </summary>
        [Required]
        public PatientGender Gender { get; set; }

        /// <summary>
        /// Contact number
        /// </summary>
        [Required]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email id
        /// </summary>
        [Required]
        public string EmailId { get; set; } 

    }
}
