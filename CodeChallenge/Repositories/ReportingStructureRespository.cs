using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Controllers;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data;
using CodeChallenge.Services;

namespace CodeChallenge.Repositories
{
    public class ReportingStructureRepository : IReportingStructureRepository
    {
        private readonly ReportingStructureContext _reportingStructureContext;
        private readonly ILogger<IReportingStructureRepository> _logger;

        public ReportingStructureRepository(ILogger<IReportingStructureRepository> logger, ReportingStructureContext employeeContext)
        {
            _reportingStructureContext = employeeContext;
            _logger = logger;
        }

        public ReportingStructure GetById(string employee)
        {
            return new ReportingStructure();
        }

        public ReportingStructure GetNumberOfReportsById(string employee)
        {
            int countOfReports;

            countOfReports = CountOfReports(employee);

            ReportingStructure reportingStructure = new ReportingStructure();
            reportingStructure.Employee = employee;
            reportingStructure.NumberOfReports = countOfReports;
            

            return reportingStructure;
        }

        private static int CountOfReports(string employee)
        {
            int countOfReports;
            // Initialize to get Employee
            ILoggerFactory factoryService = new LoggerFactory();
            ILogger<EmployeeService> empServiceLogger = new Logger<EmployeeService>(factoryService);
            ILoggerFactory factoryController = new LoggerFactory();
            ILogger<EmployeeController> empControllerLogger = new Logger<EmployeeController>(factoryController);
            ILoggerFactory factoryRepository = new LoggerFactory();
            ILogger<IEmployeeRepository> loggerRepository = new Logger<IEmployeeRepository>(factoryRepository);
            EmployeeContext employeeContext = new EmployeeContext(new DbContextOptionsBuilder<EmployeeContext>().UseInMemoryDatabase("EmployeeDB").Options);
            IEmployeeRepository employeeRepository = new EmployeeRespository(loggerRepository, employeeContext);
            IEmployeeService employeeService = new EmployeeService(empServiceLogger, employeeRepository);
            EmployeeController empController = new EmployeeController(empControllerLogger, employeeService);
            Employee empLookup = new Employee();
            empLookup = (Employee)empController.GetEmployeeById(employee);
            // Count is just the count of direct reports in sub list
            countOfReports = empLookup.DirectReports.Count;
            return countOfReports;
        }
    }
}
