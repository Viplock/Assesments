using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.LabTests.Entity
{
    public class Report
    {
        /// <summary>
        /// Report id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Patient id
        /// </summary>
        [Required]
        public int PatientId { get; set; }

        /// <summary>
        /// Test id
        /// </summary>
        [Required]
        public int LabTestId { get; set; }

        /// <summary>
        /// Entered Time
        /// </summary>
        [Required]
        public DateTime EnteredTime { get; set; }

        /// <summary>
        ///Time of Test
        /// </summary>
        [Required]
        public DateTime TimeOfTest { get; set; }

        /// <summary>
        /// Report cretated on
        /// </summary>
        [Required]
        public DateTime ReportCreatedOn { get; set; }

        /// <summary>
        /// Test result
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        /// Patient details
        /// </summary>
        public Patient Patient { get; internal set; }

        /// <summary>
        /// Test details
        /// </summary>
        public LabTest LabTest { get; internal set; }

    }
}
