using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IReportingStructureService _reportingStructureService;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IReportingStructureService reportingStructureService)
        {
            _reportingStructureService = reportingStructureService;
            _logger = logger;
        }

        public ReportingStructure GetNumberOfReportsById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _reportingStructureService.GetNumberOfReportsById(id);
            }

            return null;
        }

        public ReportingStructure GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {

            }

            return null;
        }
    }
}

