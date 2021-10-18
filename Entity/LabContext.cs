using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.LabTests.Entity
{
    public class LabContext : DbContext
    {
        public LabContext(DbContextOptions<LabContext> options)
            : base(options)
        {

        }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Report> Reports { get; set; }
       
           
    }
}
