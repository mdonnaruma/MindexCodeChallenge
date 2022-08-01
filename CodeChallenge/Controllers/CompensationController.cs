using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController()
        {
        }

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for 'EmployeeID: {compensation.Employee} Effective Date: {compensation.EffectiveDate} Salary: {compensation.Salary}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { id = compensation.Employee }, compensation);
        }

        [HttpGet("{employee}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String employee)
        {
            _logger.LogDebug($"Received compensation get request for '{employee}'");

            var compensation = _compensationService.GetById(employee);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}
