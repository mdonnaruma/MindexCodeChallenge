using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class ReportingStructureContext : DbContext
    {
        public ReportingStructureContext(DbContextOptions<ReportingStructureContext> options) : base(options)
        {

        }

        public DbSet<ReportingStructure> ReportingStructure { get; set; }
    }
}
