using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.LabTests.Entity
{
    public class LabTest
    {
        /// <summary>
        /// Test id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of test 
        /// </summary>
        [Required]
        public TestTypes TestType { get; set; }

        /// <summary>
        /// Test description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Sample type 
        /// </summary>
        [Required]
        public SampleTypes SampleType { get; set; }      
    }

    public enum TestTypes
    {
        None,
        PhysicalTest,
        GlucoseTests,
        CompleteBloodCount,
        LipidPanel,
        UrinAlysis
    }

    public enum SampleTypes
    {
        None,
        BloodSample,
        UrineSample,
        StoolSample,
        SwabSample
    }
}
